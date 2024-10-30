using AutoMapper;
using FinanceGub.Application.DTOs.Post;
using FinanceGub.Application.Features.PostFeatures.Commands.CreatePostCommand;
using FinanceGub.Application.Features.PostFeatures.Commands.DeletePostCommand;
using FinanceGub.Application.Features.PostFeatures.Commands.UpdatePostCommand;
using FinanceGub.Application.Features.PostFeatures.Queries.GetAllPostQuery;
using FinanceGub.Application.Features.PostFeatures.Queries.GetPostQuery;
using FinanceGub.Application.Interfaces.Repositories;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Core.Entities;
using FinanceHub.Core.Exceptions;
using MediatR;

namespace FinanceHub.Infrastructure.Services;

public class PostService : IPostService
{
    private readonly IMapper _mapper;
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMediator _mediator;

    public PostService(IMapper mapper, IPostRepository postRepository, IUserRepository userRepository, IMediator mediator)
    {
        _mapper = mapper;
        _postRepository = postRepository;
        _userRepository = userRepository;
        _mediator = mediator;
    }
    
    public async Task<IEnumerable<GetPostDto>> GetAllPostAsync()
    {
        var posts = await _mediator.Send(new GetAllPostQuery("Author"));

        var postDtos = _mapper.Map<IEnumerable<GetPostDto>>(posts);

        return postDtos;
    }
    
    public async Task<GetPostDto> GetPostAsync(Guid id)
    {
        var posts = await _mediator.Send(new GetPostQuery(id, "Author"));
        
        var postDtos = _mapper.Map<GetPostDto>(posts);
        
        return postDtos; 
    }

    public async Task<GetPostDto> CreatePostAsync(CreatePostDto createPostDto)
    {
        var post = _mapper.Map<Post>(createPostDto);

        var user = await _userRepository.GetByEmailAsync(createPostDto.UserEmail);
        if (user == null)
        {
            throw new Exception("User with the specified email not found.");
        }

        post.AuthorId = user.Id;

        await _mediator.Send(new CreatePostCommand(post));

        var responseProfile = _mapper.Map<GetPostDto>(post);
        return responseProfile;
    }
    
    public async Task<GetPostDto> UpdateProfileAsync(Guid id, UpdatePostDto updatePostDto)
    {
        var existingPost = await _postRepository.GetByIdAsync(id, "Author");
        if (existingPost == null)
        {
            throw new ValidationException($"Post with ID {id} does not exist.");
        }
        
        _mapper.Map(updatePostDto, existingPost);
        
        await _mediator.Send(new UpdatePostCommand(existingPost));
        
        var responsePost = _mapper.Map<GetPostDto>(existingPost);
        return responsePost;
    }
    
    public async Task<string> DeletePostAsync(Guid postId)
    {
        var post = await _postRepository.GetByIdAsync(postId);
        if (post == null)
        {
            throw new Exception("Profile not found.");
        }

        return await _mediator.Send(new DeletePostCommand(postId));
    }
}