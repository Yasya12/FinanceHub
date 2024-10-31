using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Core.Exceptions;
using MediatR;

namespace FinanceGub.Application.Features.CategoryFeatures.Commands.UpdateCategoryCommand;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Category>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    
    public async Task<Category> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Category.Id);

        if (category == null)
        {
            throw new NotFoundException($"Category with ID {request.Category.Id} not found.");
        }
        
        await _categoryRepository.UpdateAsync(request.Category);
        return request.Category;
    }
}