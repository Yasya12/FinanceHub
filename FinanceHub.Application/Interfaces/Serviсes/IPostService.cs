using FinanceGub.Application.DTOs.Post;
using FinanceGub.Application.Helpers;

namespace FinanceGub.Application.Interfaces.Serviсes;

public interface IPostService
{
    Task<PagedList<GetPostDto>> GetPostsPaginatedAsync(PostParams postParams);
    Task<PagedList<GetPostDto>> GetPostsWithLikesAsync(PostParams postParams, Guid userId);
    Task<GetSinglePostDto> GetPostAsync(Guid id);
    Task<GetPostDto> CreatePostAsync(CreatePostDto createPostDto);
    Task<GetPostDto> UpdatePostAsync(Guid id, UpdatePostDto updatePostDto);
    Task<string> DeletePostAsync(Guid postId);
}