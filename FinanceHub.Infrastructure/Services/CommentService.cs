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

public class CommentService : ICommentService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public CommentService(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<IEnumerable<GetCommentDto>> GetCommentsPaginatedAsync(Guid postId, int pageNumber, int pageSize,
        string filter)
    {
        var post = await _mediator.Send(new GetPostQuery(postId));
        if (post == null)
        {
            throw new Exception("Post with the specified Id not found.");
        }

        // Fetch all comments for the post, including replies
        var allComments =
            await _mediator.Send(
                new GetAllCommentQuery("Post,Author,Author.Profile,Replies,Replies.Author,Replies.Author.Profile"));
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
            parent.Replies = GetRepliesRecursive(parent.Id, commentList);
        }

        return _mapper.Map<IEnumerable<GetCommentDto>>(parentComments);
    }

    // Recursive function to fetch all nested replies
    private List<Comment> GetRepliesRecursive(Guid parentId, List<Comment> allComments)
    {
        var replies = allComments.Where(c => c.ParentId == parentId).ToList();
        foreach (var reply in replies)
        {
            reply.Replies = GetRepliesRecursive(reply.Id, allComments);
        }

        return replies;
    }


    public async Task<GetCommentDto> GetCommentAsync(Guid id)
    {
        var comments = await _mediator.Send(new GetCommentQuery(id, "Post,Author,Author.Profile"));

        var commentDtos = _mapper.Map<GetCommentDto>(comments);

        return commentDtos;
    }

    public async Task<GetCommentDto> CreateCommentAsync(CreateCommentDto createCommentDto)
    {
        var post = await _mediator.Send(new GetPostQuery(createCommentDto.PostId));
        if (post == null)
        {
            throw new Exception("Post with the specified Id not found.");
        }

        var user = await _mediator.Send(new GetUserQuery(createCommentDto.AuthorId));
        if (user == null)
        {
            throw new Exception("User with the specified Id not found.");
        }

        var comment = _mapper.Map<Comment>(createCommentDto);

        await _mediator.Send(new CreateCommentCommand(comment));

        var responseComment = _mapper.Map<GetCommentDto>(comment);
        responseComment.AuthorName = user.Username;

        return responseComment;
    }

    public async Task<GetCommentDto> UpdateCommentAsync(Guid id, UpdateCommentDto updateCommentDto)
    {
        var existingComment = await _mediator.Send(new GetCommentQuery(id));
        if (existingComment == null)
        {
            throw new ValidationException($"Comment with ID {id} does not exist.");
        }

        _mapper.Map(updateCommentDto, existingComment);

        await _mediator.Send(new UpdateCommentCommand(existingComment));

        var responseComment = _mapper.Map<GetCommentDto>(existingComment);
        var post = await _mediator.Send(new GetPostQuery(existingComment.PostId));
        var user = await _mediator.Send(new GetUserQuery(existingComment.AuthorId));
        responseComment.AuthorName = user.Username;

        return responseComment;
    }

    public async Task<string> DeleteCommentAsync(Guid commentId)
    {
        var comment = await _mediator.Send(new GetCommentQuery(commentId));
        ;
        if (comment == null)
        {
            throw new Exception("Comment not found.");
        }

        return await _mediator.Send(new DeleteCommentCommand(commentId));
    }
}