using FinanceGub.Application.DTOs.Hub;
using FinanceGub.Application.DTOs.Post;
using FinanceGub.Application.DTOs.User;

namespace FinanceGub.Application.DTOs;

public class SearchResultDto
{
    public List<GetUserDto> Users { get; set; } = new();
    public List<GetPostDto> Posts { get; set; } = new();
    public List<GetHubDto> Hubs { get; set; } = new();
}