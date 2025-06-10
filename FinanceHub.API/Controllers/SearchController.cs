using FinanceGub.Application.Interfaces.Serviсes;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SearchController(ISearchService searchService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Search([FromQuery] string q)
    {
        var results = await searchService.PerformSearchAsync(q);
        return Ok(results);
    }
}