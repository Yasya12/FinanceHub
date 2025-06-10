using AutoMapper;
using FinanceGub.Application.DTOs;
using FinanceGub.Application.DTOs.Hub;
using FinanceGub.Application.DTOs.Post;
using FinanceGub.Application.DTOs.User;
using FinanceGub.Application.Interfaces.Repositories;
using FinanceGub.Application.Interfaces.Serviсes;

namespace FinanceHub.Infrastructure.Services;

public class SearchService(IUserRepository userRepository, IHubRepository hubRepository, IPostRepository postRepository, 
    IMapper mapper) : ISearchService
{
    public async Task<SearchResultDto> PerformSearchAsync(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return new SearchResultDto();
        }

        var normalizedQuery = query.ToLower().Trim();

        var users = await  userRepository.SearchUsersAsync(normalizedQuery, 5);
        var hubs  = await  hubRepository.SearchHubsAsync(normalizedQuery, 5);
        var posts  = await  postRepository.SearchPostsAsync(normalizedQuery, 10);

        var userDtos = mapper.Map<List<GetUserDto>>(users);
        var hubDtos = mapper.Map<List<GetHubDto>>(hubs );
        var postDtos = mapper.Map<List<GetPostDto>>(posts );

        return new SearchResultDto
        {
            Users = userDtos,
            Hubs = hubDtos,
            Posts = postDtos
        };
    }
}