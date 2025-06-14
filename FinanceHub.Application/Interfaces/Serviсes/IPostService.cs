using FinanceGub.Application.DTOs.Post;
using FinanceGub.Application.Helpers;

namespace FinanceGub.Application.Interfaces.Serviсes;

public interface IPostService
{
    Task<PagedList<GetPostDto>> GetPostsPaginatedAsync(PostParams postParams);
    Task<PagedList<GetPostDto>> GetHubPostsPaginatedAsync(PostParams postParams, Guid hubId);
    Task<PagedList<GetPostDto>> GetPostsWithLikesAsync(PostParams postParams, Guid userId);
    Task<PagedList<GetPostDto>> GetHubPostsWithLikesAsync(PostParams postParams, Guid userId, Guid hubId);

    Task<PagedList<GetPostDto>> GetPostsForSpecificUserWithLikesAsync(PostParams postParams, Guid userId,
        Guid specificUserId);

    Task<PagedList<GetPostDto>> GetLikedPostsForSpecificUserWithLikesAsync(PostParams postParams, Guid userId,
        Guid specificUserId);

    Task<GetSinglePostDto> GetPostAsync(Guid id);
    Task<GetPostDto> CreatePostAsync(CreatePostDto createPostDto);
    Task<GetPostDto> UpdatePostAsync(Guid id, UpdatePostDto updatePostDto);
    Task<string> DeletePostAsync(Guid postId);
    Task<PagedList<GetPostDto>> GetAllFollowingPostsAsync(Guid userId, PostParams postParams);
    Task<PagedList<GetPostDto>> GetAllFollowingPostsWithLikesAsync(Guid userId, PostParams postParams);
}