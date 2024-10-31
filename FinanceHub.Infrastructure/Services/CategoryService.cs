using AutoMapper;
using FinanceGub.Application.DTOs.Category;
using FinanceGub.Application.Features.CategoryFeatures.Commands.CreateCategoryCommand;
using FinanceGub.Application.Features.CategoryFeatures.Commands.DeleteCategoryCommand;
using FinanceGub.Application.Features.CategoryFeatures.Commands.UpdateCategoryCommand;
using FinanceGub.Application.Features.CategoryFeatures.Queries.GetAllCategoryQuery;
using FinanceGub.Application.Features.CategoryFeatures.Queries.GetCategoryQuery;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Core.Entities;
using FinanceHub.Core.Exceptions;
using MediatR;

namespace FinanceHub.Infrastructure.Services;

public class CategoryService: ICategoryService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public CategoryService(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }
    
    public async Task<IEnumerable<GetCategoryDto>> GetAllCategoryAsync()
    {
        var categories = await _mediator.Send(new GetAllCategoryQuery("PostCategory,PostCategory.Post"));

        var categoryDtos = _mapper.Map<IEnumerable<GetCategoryDto>>(categories);

        return categoryDtos;
    }
    
    public async Task<GetCategoryDto> GetCategoryAsync(Guid id)
    {
        var categories = await _mediator.Send(new GetCategoryQuery(id, "PostCategory,PostCategory.Post"));
        
        var categoryDto = _mapper.Map<GetCategoryDto>(categories);
        
        return categoryDto; 
    }
    
    public async Task<CreateCategoryDto> CreateCategoryAsync(CreateCategoryDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        await _mediator.Send(new CreateCategoryCommand(category));
        return categoryDto;
    }
    
    public async Task<UpdateCategoryDto> UpdateCategoryAsync(Guid id, UpdateCategoryDto categoryDto)
    {
        var existingCategory = await _mediator.Send(new GetCategoryQuery(id));
        if (existingCategory == null)
        {
            throw new ValidationException($"Category with ID {id} does not exist.");
        }
        
        _mapper.Map(categoryDto, existingCategory);
        await _mediator.Send(new UpdateCategoryCommand(existingCategory));
        return categoryDto;
    }
    
    public async Task<string> DeleteCategoryAsync(Guid categoryId)
    {
        var category = await _mediator.Send(new GetCategoryQuery(categoryId));
        if (category == null)
        {
            throw new Exception("Category not found.");
        }
    
        return await _mediator.Send(new DeleteCategoryCommand(categoryId));
    }
}