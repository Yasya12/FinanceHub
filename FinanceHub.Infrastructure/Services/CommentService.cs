using AutoMapper;
using FinanceGub.Application.DTOs.Comment;
using FinanceGub.Application.Features.CommentFeatures.Commands.CreateCommentCommand;
using FinanceGub.Application.Features.CommentFeatures.Commands.DeleteCommentCommand;
using FinanceGub.Application.Features.CommentFeatures.Commands.UpdateCommentCommand;
using FinanceGub.Application.Features.CommentFeatures.Queries.GetAllCommentQuery;
using FinanceGub.Application.Features.CommentFeatures.Queries.GetCommentQuery;
using FinanceGub.Application.Features.PostFeatures.Queries.GetPostQuery;
using FinanceGub.Application.Features.UserFeatures.Queries.GetUserQuery;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Core.Entities;
using FinanceHub.Core.Exceptions;
using MediatR;

namespace FinanceHub.Infrastructure.Services;

public class CommentService(IMapper mapper, IMediator mediator) : ICommentService
{
    public async Task<IEnumerable<GetCommentDto>> GetCommentsPaginatedAsync(Guid postId, int pageNumber, int pageSize,
        string filter)
    {
        var post = await mediator.Send(new GetPostQuery(postId));
        if (post == null)
        {
            throw new Exception("Post with the specified Id not found.");
        }

        // Fetch all comments for the post, including replies
        var allComments =
            await mediator.Send(
                new GetAllCommentQuery("Post,Author,Replies,Replies.Author"));
        var commentList = allComments.Where(c => c.PostId == postId).ToList();

        // Step 1: Get only parent comments for pagination
        if (filter == "oldest")
        {
            commentList = commentList.OrderBy(c => c.CreatedAt).ToList();
        }
        else
        {
            commentList = commentList.OrderByDescending(c => c.CreatedAt).ToList();
        }
        
        var parentComments = commentList
            .Where(c => c.ParentId == null)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        // Step 2: Recursively build the reply tree
        foreach (var parent in parentComments)
        {
            parent.Replies = GetRepliesRecursive(parent.Id, commentList, filter);
        }

        return mapper.Map<IEnumerable<GetCommentDto>>(parentComments);
    }

    // Recursive function to fetch all nested replies
    private List<Comment> GetRepliesRecursive(Guid parentId, List<Comment> allComments, string filter)
    {
        var replies = allComments
            .Where(c => c.ParentId == parentId)
            .ToList();

        replies = filter == "oldest"
            ? replies.OrderBy(c => c.CreatedAt).ToList()
            : replies.OrderByDescending(c => c.CreatedAt).ToList();
        
        foreach (var reply in replies)
        {
            reply.Replies = GetRepliesRecursive(reply.Id, allComments, filter);
        }

        return replies;
    }


    public async Task<GetCommentDto> GetCommentAsync(Guid id)
    {
        var comments = await mediator.Send(new GetCommentQuery(id, "Post,Author"));

        var commentDtos = mapper.Map<GetCommentDto>(comments);

        return commentDtos;
    }

    public async Task<GetCommentDto> CreateCommentAsync(CreateCommentDto createCommentDto)
    {
        var post = await mediator.Send(new GetPostQuery(createCommentDto.PostId));
        if (post == null)
        {
            throw new Exception("Post with the specified Id not found.");
        }

        var user = await mediator.Send(new GetUserQuery(createCommentDto.AuthorId));
        if (user == null)
        {
            throw new Exception("User with the specified Id not found.");
        }

        var comment = mapper.Map<Comment>(createCommentDto);

        await mediator.Send(new CreateCommentCommand(comment));

        var responseComment = mapper.Map<GetCommentDto>(comment);
        responseComment.AuthorName = user.Username;

        return responseComment;
    }

    public async Task<GetCommentDto> UpdateCommentAsync(Guid id, UpdateCommentDto updateCommentDto)
    {
        var existingComment = await mediator.Send(new GetCommentQuery(id));
        if (existingComment == null)
        {
            throw new ValidationException($"Comment with ID {id} does not exist.");
        }

        mapper.Map(updateCommentDto, existingComment);

        await mediator.Send(new UpdateCommentCommand(existingComment));

        var responseComment = mapper.Map<GetCommentDto>(existingComment);
        var post = await mediator.Send(new GetPostQuery(existingComment.PostId));
        var user = await mediator.Send(new GetUserQuery(existingComment.AuthorId));
        responseComment.AuthorName = user.Username;

        return responseComment;
    }

    public async Task<string> DeleteCommentAsync(Guid commentId)
    {
        var comment = await mediator.Send(new GetCommentQuery(commentId));
        ;
        if (comment == null)
        {
            throw new Exception("Comment not found.");
        }

        return await mediator.Send(new DeleteCommentCommand(commentId));
    }
}