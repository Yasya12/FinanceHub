using FinanceGub.Application.DTOs.Comment;

namespace FinanceGub.Application.Interfaces.Serviсes;

public interface ICommentService
{
    Task<IEnumerable<GetCommentDto>> GetCommentsPaginatedAsync(Guid postId, int skip, int take);
    Task<IEnumerable<GetCommentDto>> GetAllCommentsAsync(Guid postId);
    Task<GetCommentDto> GetCommentAsync(Guid id);
    Task<GetCommentDto> CreateCommentAsync(CreateCommentDto createCommentDto);
    Task<GetCommentDto> UpdateCommentAsync(Guid id, UpdateCommentDto updateCommentDto);
    Task<string> DeleteCommentAsync(Guid postId);
}