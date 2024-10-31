using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Exceptions;
using MediatR;

namespace FinanceGub.Application.Features.CategoryFeatures.Commands.DeleteCategoryCommand;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, string>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    
    public async Task<string> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);

        if (category == null)
        {
            throw new NotFoundException($"Category with ID {request.Id} not found.");
        }
        
        var message = await _categoryRepository.DeleteAsync(request.Id);
        return message;
    }
}