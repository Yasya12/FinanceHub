using FinanceGub.Application.DTOs;

namespace FinanceGub.Application.Interfaces.Serviсes;

public interface ISearchService
{
    Task<SearchResultDto> PerformSearchAsync(string query);
}