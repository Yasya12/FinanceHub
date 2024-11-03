using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.CommentFeatures.Queries.GetCommentQuery;

public record GetCommentQuery(Guid Id, string? IncludeProperties = null) : IRequest<Comment>;