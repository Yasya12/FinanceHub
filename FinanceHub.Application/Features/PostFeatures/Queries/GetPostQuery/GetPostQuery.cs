using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.PostFeatures.Queries.GetPostQuery;

public record GetPostQuery(Guid Id, string? IncludeProperties = null) : IRequest<Post>;