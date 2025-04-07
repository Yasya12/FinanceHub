using AutoMapper;
using AutoMapper.QueryableExtensions;
using FinanceGub.Application.DTOs.Post;
using FinanceGub.Application.Features.LikeFeatures.Queries.GetSingleLikeQuery;
using FinanceGub.Application.Features.PostCategoryFeatures.Commands.AddRangePostCategoryCommand;
using FinanceGub.Application.Features.PostCategoryFeatures.Commands.RemoveRangePostCategoryCommand;
using FinanceGub.Application.Features.PostFeatures.Commands.CreatePostCommand;
using FinanceGub.Application.Features.PostFeatures.Commands.DeletePostCommand;
using FinanceGub.Application.Features.PostFeatures.Commands.UpdatePostCommand;
using FinanceGub.Application.Features.PostFeatures.Queries.GetAllPostQuery;
using FinanceGub.Application.Features.PostFeatures.Queries.GetPostQuery;
using FinanceGub.Application.Features.PostImageFeatures.Commands.CreatePostImageCommand;
using FinanceGub.Application.Helpers;
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
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMediator _mediator;
    private readonly IAzureBlobStorageService _azureBlobStorageService;

    public PostService(IMapper mapper, IPostRepository postRepository, IUserRepository userRepository,
        ICategoryRepository categoryRepository, IMediator mediator, IAzureBlobStorageService azureBlobStorageService)
    {
        _mapper = mapper;
        _postRepository = postRepository;
        _userRepository = userRepository;
        _categoryRepository = categoryRepository;
        _mediator = mediator;
        _azureBlobStorageService = azureBlobStorageService;
    }

    public async Task<PagedList<GetPostDto>> GetPostsPaginatedAsync(PostParams postParams)
    {
        var postsQuey = await _mediator.Send(
            new GetAllPostQuery("Author,Author.Profile,PostCategory,PostCategory.Category,Comments,Likes,PostImages"));

        var dtoQuery = postsQuey
            .OrderByDescending(x => x.CreatedAt)
            .ProjectTo<GetPostDto>(_mapper.ConfigurationProvider); 
        
        return await PagedList<GetPostDto>.CreateAsync(dtoQuery, postParams.PageNumber, postParams.PageSize);
    }
    
    public async Task<PagedList<GetPostDto>> GetPostsWithLikesAsync(PostParams postParams, Guid userId)
    {
        var paginatedPosts = await GetPostsPaginatedAsync(postParams);
        
        foreach (var post in paginatedPosts)
        {
            var like = await _mediator.Send(new GetSingleLikeQuery(post.Id, userId));
            post.IsLiked = like != null; 
        }
        
        return paginatedPosts;
    }


    public async Task<GetSinglePostDto> GetPostAsync(Guid id)
    {
        var posts = await _mediator.Send(new GetPostQuery(id,
            "Author,Author.Profile,PostCategory.Category,Comments,Likes,PostImages"));

        var postDtos = _mapper.Map<GetSinglePostDto>(posts);

        return postDtos;
    }

    public async Task<GetPostDto> CreatePostAsync(CreatePostDto createPostDto)
    {
        var user = await _userRepository.GetByEmailAsync(createPostDto.UserEmail);
        if (user == null)
        {
            throw new Exception("User with the specified email not found.");
        }

        var existingCategories = await _categoryRepository.GetCategoriesByNamesAsync(createPostDto.CategoryNames);

        var categoryNames = createPostDto.CategoryNames ?? Enumerable.Empty<string>();
        var invalidCategoryNames = categoryNames
            .Where(name => !existingCategories.Any(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            .ToList();


        if (invalidCategoryNames.Any())
        {
            throw new Exception($"The following categories do not exist: {string.Join(", ", invalidCategoryNames)}");
        }

        var post = _mapper.Map<Post>(createPostDto);
        post.AuthorId = user.Id;

        post.PostCategory = existingCategories.Select(c => new PostCategory
        {
            PostId = post.Id,
            CategoryId = c.Id,
            Category = c
        }).ToList();

        await _mediator.Send(new CreatePostCommand(post));

        //uploading and creating image urls 
        if (createPostDto.Images != null && createPostDto.Images.Any())
        {
            foreach (var file in createPostDto.Images)
            {
                var imageUrl = await _azureBlobStorageService.UploadPostImageAsync(file);

                var postImage = new PostImage()
                {
                    PostId = post.Id,
                    ImageUrl = imageUrl,
                };

                await _mediator.Send(new CreatePostImageCommand(postImage));
            }
        }

        var responsePost = _mapper.Map<GetPostDto>(post);
        return responsePost;
    }

    public async Task<GetPostDto> UpdatePostAsync(Guid id, UpdatePostDto updatePostDto)
    {
        var existingPost = await _postRepository.GetByIdAsync(id, "Author,PostCategory");
        if (existingPost == null)
        {
            throw new ValidationException($"Post with ID {id} does not exist.");
        }

        _mapper.Map(updatePostDto, existingPost);

        if (existingPost.PostCategory != null && existingPost.PostCategory.Any())
        {
            await _mediator.Send(new RemoveRangePostCategoryCommand(existingPost.PostCategory));
        }

        var existingCategories = await _categoryRepository.GetCategoriesByNamesAsync(updatePostDto.CategoryNames);

        var categoryNames = updatePostDto.CategoryNames ?? Enumerable.Empty<string>();
        var invalidCategoryNames = categoryNames
            .Where(name => !existingCategories.Any(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            .ToList();

        if (invalidCategoryNames.Any())
        {
            throw new Exception($"The following categories do not exist: {string.Join(", ", invalidCategoryNames)}");
        }

        await _mediator.Send(new AddRangePostCategoryCommand(existingPost, existingCategories));

        await _mediator.Send(new UpdatePostCommand(existingPost));

        var responsePost = _mapper.Map<GetPostDto>(existingPost);
        return responsePost;
    }


    public async Task<string> DeletePostAsync(Guid postId)
    {
        var post = await _postRepository.GetByIdAsync(postId);
        if (post == null)
        {
            throw new Exception("Post not found.");
        }

        return await _mediator.Send(new DeletePostCommand(postId));
    }
}