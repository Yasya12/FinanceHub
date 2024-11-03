using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.CommentFeatures.Queries.GetAllCommentQuery;

public record GetAllCommentQuery(string? IncludeProperties = null) : IRequest<IEnumerable<Comment>>;