using FinanceGub.Application.DTOs.Post;
using FinanceHub.Core.Entities;

namespace FinanceGub.Application.Interfaces.Serviсes;

public interface IPostService
{
    Task<PaginatedResult<GetPostDto>> GetPostsPaginatedAsync(int pageNumber, int pageSize);
    Task<GetSinglePostDto> GetPostAsync(Guid id);
    Task<GetPostDto> CreatePostAsync(CreatePostDto createPostDto);
    Task<GetPostDto> UpdatePostAsync(Guid id, UpdatePostDto updatePostDto);
    Task<string> DeletePostAsync(Guid postId);
}