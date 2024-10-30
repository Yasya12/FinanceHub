using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.PostFeatures.Queries.GetAllPostQuery;

public record GetAllPostQuery (string? IncludeProperties = null) : IRequest<IEnumerable<Post>> { }