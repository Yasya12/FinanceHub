using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.CategoryFeatures.Queries.GetAllCategoryQuery;

public record GetAllCategoryQuery(string? IncludeProperties = null) : IRequest<IEnumerable<Category>>;