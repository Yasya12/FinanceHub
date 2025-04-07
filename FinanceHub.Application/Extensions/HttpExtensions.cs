using System.Text.Json;
using FinanceGub.Application.Helpers;
using Microsoft.AspNetCore.Http;

namespace FinanceGub.Application.Extensions;

public static class HttpExtensions
{
    /// <summary>
    /// Adds pagination details to the HTTP response headers.
    /// </summary>
    public static void AddPaginationHeader<T>(this HttpResponse response, PagedList<T> data)
    {
        var paginationHeader = new PaginationHeader(data.CurrentPage, data.PageSize, data.TotalCount, data.TotalPages);

        // Serialize pagination info to JSON with camelCase naming
        var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        response.Headers.Append("Pagination", JsonSerializer.Serialize(paginationHeader, jsonOptions));

        // Allow frontend to access the "Pagination" header
        response.Headers.Append("Access-Control-Expose-Headers", "Pagination");
    }
}