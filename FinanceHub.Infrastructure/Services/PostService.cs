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

public class PostService(
    IMapper mapper,
    IPostRepository postRepository,
    IUserRepository userRepository,
    ICategoryRepository categoryRepository,
    IMediator mediator,
    IAzureBlobStorageService azureBlobStorageService,
    IFollowingRepository followingRepository)
    : IPostService
{
    public async Task<PagedList<GetPostDto>> GetPostsPaginatedAsync(PostParams postParams)
    {
        var postsQuey = await mediator.Send(
            new GetAllPostQuery("Author,PostCategory,PostCategory.Category,Comments,Likes,PostImages,Hub"));

        var dtoQuery = postsQuey
            .OrderByDescending(x => x.CreatedAt)
            .ProjectTo<GetPostDto>(mapper.ConfigurationProvider);

        return await PagedList<GetPostDto>.CreateAsync(dtoQuery, postParams.PageNumber, postParams.PageSize);
    }
    
    public async Task<PagedList<GetPostDto>> GetPostsForSpecificUserPaginatedAsync(PostParams postParams, Guid specificUserId)
    {
        var postsQuey = await mediator.Send(
            new GetAllPostQuery("Author,PostCategory,PostCategory.Category,Comments,Likes,PostImages,Hub"));

        var dtoQuery = postsQuey
            .Where(x => x.AuthorId == specificUserId)
            .OrderByDescending(x => x.CreatedAt)
            .ProjectTo<GetPostDto>(mapper.ConfigurationProvider);

        return await PagedList<GetPostDto>.CreateAsync(dtoQuery, postParams.PageNumber, postParams.PageSize);
    }
    
    public async Task<PagedList<GetPostDto>> GetPostsForSpecificUserWithLikesAsync(PostParams postParams, Guid userId, Guid specificUserId)
    {
        var paginatedPosts = await GetPostsForSpecificUserPaginatedAsync(postParams, specificUserId);

        foreach (var post in paginatedPosts)
        {
            var like = await mediator.Send(new GetSingleLikeQuery(post.Id, userId));
            post.IsLiked = like != null;
        }

        return paginatedPosts;
    }
    
    public async Task<PagedList<GetPostDto>> GetLikedPostsForSpecificUserWithLikesAsync(PostParams postParams, Guid userId, Guid specificUserId)
    {
        // Отримуємо всі пости з включеннями
        var allPosts = await mediator.Send(new GetAllPostQuery("Author,PostCategory,PostCategory.Category,Comments,Likes,PostImages,Hub"));

        // Фільтруємо тільки ті пости, які лайкнув specificUser
        var likedBySpecificUser = allPosts
            .Where(post => post.Likes.Any(like => like.UserId == specificUserId))
            .OrderByDescending(p => p.CreatedAt);

        // Проєктуємо в DTO
        var dtoQuery = likedBySpecificUser
            .AsQueryable()
            .ProjectTo<GetPostDto>(mapper.ConfigurationProvider);

        // Пагінація
        var paginated = await PagedList<GetPostDto>.CreateAsync(dtoQuery, postParams.PageNumber, postParams.PageSize);

        // Проставляємо IsLiked для залогіненого користувача
        foreach (var postDto in paginated)
        {
            var currentUserLike = allPosts
                .First(p => p.Id == postDto.Id)
                .Likes.Any(l => l.UserId == userId);

            postDto.IsLiked = currentUserLike;
        }

        return paginated;
    }

    public async Task<PagedList<GetPostDto>> GetHubPostsPaginatedAsync(PostParams postParams, Guid hubId)
    {
        var postsQuey = await mediator.Send(
            new GetAllPostQuery("Author,PostCategory,PostCategory.Category,Comments,Likes,PostImages,Hub"));

        var dtoQuery = postsQuey
            .Where(x => x.HubId == hubId)
            .OrderByDescending(x => x.CreatedAt)
            .ProjectTo<GetPostDto>(mapper.ConfigurationProvider);

        return await PagedList<GetPostDto>.CreateAsync(dtoQuery, postParams.PageNumber, postParams.PageSize);
    }

    public async Task<PagedList<GetPostDto>> GetAllFollowingPostsAsync(Guid userId, PostParams postParams)
    {
        // Отримання ID користувачів та хабів, на які підписаний
        var followingIdsTuples = await followingRepository.GetFollowingIdsAsync(userId);

        var followingUserIds = followingIdsTuples
            .Where(tuple => tuple.UserId.HasValue)
            .Select(tuple => tuple.UserId.Value)
            .ToList();

        var followingHubIds = followingIdsTuples
            .Where(tuple => tuple.HubId.HasValue)
            .Select(tuple => tuple.HubId.Value)
            .ToList();

        // Отримання постів користувачів та хабів без проєкції
        var userPostsQuery = postRepository.GetPostsByUserIds(followingUserIds);
        var hubPostsQuery = postRepository.GetPostsByHubIds(followingHubIds);

        // Об'єднуємо два запити до застосування проєкції
        var combinedPostsQuery = userPostsQuery
            .Union(hubPostsQuery)
            .OrderByDescending(post => post.CreatedAt);
        
        // Застосовуємо проєкцію до GetPostDto перед пагінацією
        var projectedQuery = combinedPostsQuery.Select(post => new GetPostDto
        {
            Id = post.Id,
            UserName = post.Author.UserName,
            ProfilePictureUrl = post.Author.ProfilePictureUrl,
            HubName = post.Hub.Name,
            Content = post.Content,
            CreatedAt = post.CreatedAt,
            LikesCount = post.Likes.Count
            // або будь-яке інше мапування, що тобі потрібно
        });

        // Пагінуємо результат
        return await PagedList<GetPostDto>.CreateAsync(projectedQuery, postParams.PageNumber, postParams.PageSize);
    }


    public async Task<PagedList<GetPostDto>> GetAllFollowingPostsWithLikesAsync(Guid userId, PostParams postParams)
    {
        var paginatedPosts = await GetAllFollowingPostsAsync(userId, postParams);

        foreach (var post in paginatedPosts)
        {
            var like = await mediator.Send(new GetSingleLikeQuery(post.Id, userId));
            post.IsLiked = like != null;
        }

        return paginatedPosts;
    }


    public async Task<PagedList<GetPostDto>> GetPostsWithLikesAsync(PostParams postParams, Guid userId)
    {
        var paginatedPosts = await GetPostsPaginatedAsync(postParams);

        foreach (var post in paginatedPosts)
        {
            var like = await mediator.Send(new GetSingleLikeQuery(post.Id, userId));
            post.IsLiked = like != null;
        }

        return paginatedPosts;
    }

    public async Task<PagedList<GetPostDto>> GetHubPostsWithLikesAsync(PostParams postParams, Guid userId, Guid hubId)
    {
        var paginatedPosts = await GetHubPostsPaginatedAsync(postParams, hubId);

        foreach (var post in paginatedPosts)
        {
            var like = await mediator.Send(new GetSingleLikeQuery(post.Id, userId));
            post.IsLiked = like != null;
        }

        return paginatedPosts;
    }


    public async Task<GetSinglePostDto> GetPostAsync(Guid id)
    {
        var posts = await mediator.Send(new GetPostQuery(id,
            "Author,PostCategory.Category,Comments,Likes,PostImages"));

        var postDtos = mapper.Map<GetSinglePostDto>(posts);

        return postDtos;
    }

    public async Task<GetPostDto> CreatePostAsync(CreatePostDto createPostDto)
    {
        var user = await userRepository.GetByEmailAsync(createPostDto.UserEmail);
        if (user == null)
        {
            throw new Exception("User with the specified email not found.");
        }

        var existingCategories = await categoryRepository.GetCategoriesByNamesAsync(createPostDto.CategoryNames);

        var categoryNames = createPostDto.CategoryNames ?? Enumerable.Empty<string>();
        var invalidCategoryNames = categoryNames
            .Where(name => !existingCategories.Any(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            .ToList();


        if (invalidCategoryNames.Any())
        {
            throw new Exception($"The following categories do not exist: {string.Join(", ", invalidCategoryNames)}");
        }

        var post = mapper.Map<Post>(createPostDto);
        post.AuthorId = user.Id;

        post.PostCategory = existingCategories.Select(c => new PostCategory
        {
            PostId = post.Id,
            CategoryId = c.Id,
            Category = c
        }).ToList();

        await mediator.Send(new CreatePostCommand(post));

        //uploading and creating image urls 
        if (createPostDto.Images != null && createPostDto.Images.Any())
        {
            foreach (var file in createPostDto.Images)
            {
                var imageUrl = await azureBlobStorageService.AddPostPhotoAsync(file);

                var postImage = new PostImage()
                {
                    PostId = post.Id,
                    ImageUrl = imageUrl,
                };

                await mediator.Send(new CreatePostImageCommand(postImage));
            }
        }

        var responsePost = mapper.Map<GetPostDto>(post);
        return responsePost;
    }

    public async Task<GetPostDto> UpdatePostAsync(Guid id, UpdatePostDto updatePostDto)
    {
        var existingPost = await postRepository.GetByIdAsync(id, "Author,PostCategory");
        if (existingPost == null)
        {
            throw new ValidationException($"Post with ID {id} does not exist.");
        }

        mapper.Map(updatePostDto, existingPost);

        if (existingPost.PostCategory != null && existingPost.PostCategory.Any())
        {
            await mediator.Send(new RemoveRangePostCategoryCommand(existingPost.PostCategory));
        }

        var existingCategories = await categoryRepository.GetCategoriesByNamesAsync(updatePostDto.CategoryNames);

        var categoryNames = updatePostDto.CategoryNames ?? Enumerable.Empty<string>();
        var invalidCategoryNames = categoryNames
            .Where(name => !existingCategories.Any(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            .ToList();

        if (invalidCategoryNames.Any())
        {
            throw new Exception($"The following categories do not exist: {string.Join(", ", invalidCategoryNames)}");
        }

        await mediator.Send(new AddRangePostCategoryCommand(existingPost, existingCategories));

        await mediator.Send(new UpdatePostCommand(existingPost));

        var responsePost = mapper.Map<GetPostDto>(existingPost);
        return responsePost;
    }


    public async Task<string> DeletePostAsync(Guid postId)
    {
        var post = await postRepository.GetByIdAsync(postId);
        if (post == null)
        {
            throw new Exception("Post not found.");
        }

        return await mediator.Send(new DeletePostCommand(postId));
    }
}