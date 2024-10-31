using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.CategoryFeatures.Queries.GetCategoryQuery;

public record GetCategoryQuery(Guid Id, string? IncludeProperties = null) : IRequest<Category>;