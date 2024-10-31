using FinanceGub.Application.DTOs.Category;
using FinanceGub.Application.Interfaces.Serviсes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : BaseController
{
    private readonly  ICategoryService _categoryService;
    
    public CategoryController(IMediator mediator, ILogger<BaseController> logger, ICategoryService categoryService): base(mediator, logger)
    {
        this._categoryService = categoryService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetCategoryDto>>> GetAllCategory()
    {
        var categories = await _categoryService.GetAllCategoryAsync();
        return Ok(categories); 
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetCategoryDto>> GetCategory(Guid id)
    { 
        var category = await _categoryService.GetCategoryAsync(id);
        return Ok(category); 
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto)
    {
        var category = await _categoryService.CreateCategoryAsync(categoryDto);
        return Created(string.Empty, category);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateCategory(Guid id, UpdateCategoryDto categoryDto)
    {
        var category = await _categoryService.UpdateCategoryAsync(id, categoryDto);
        return Ok(category);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        var message = await _categoryService.DeleteCategoryAsync(id);
        return Content(message); 
    }
}