using FinanceGub.Application.DTOs.Post;

namespace FinanceGub.Application.Interfaces.Serviсes;

public interface IPostService
{
    Task<IEnumerable<GetPostDto>> GetAllPostAsync();
    Task<GetPostDto> GetPostAsync(Guid id);
    Task<GetPostDto> CreatePostAsync(CreatePostDto createProfileDto);
    Task<GetPostDto> UpdateProfileAsync(Guid id, UpdatePostDto updatePostDto);
    Task<string> DeletePostAsync(Guid postId);
}