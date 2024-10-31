using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.CategoryFeatures.Queries.GetAllCategoryQuery;

public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, IEnumerable<Category>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    
    public async Task<IEnumerable<Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        return await _categoryRepository.GetAllAsync(request.IncludeProperties);
    }
}