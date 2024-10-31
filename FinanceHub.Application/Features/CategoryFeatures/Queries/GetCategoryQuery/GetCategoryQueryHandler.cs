using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.CategoryFeatures.Queries.GetCategoryQuery;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, Category>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    
    public async Task<Category> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        return await _categoryRepository.GetByIdAsync(request.Id, request.IncludeProperties);
    }
}