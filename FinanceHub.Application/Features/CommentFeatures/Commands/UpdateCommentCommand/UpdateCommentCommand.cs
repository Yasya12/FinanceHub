using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.CommentFeatures.Commands.UpdateCommentCommand;

public record UpdateCommentCommand(Comment Comment) : IRequest<Comment>;