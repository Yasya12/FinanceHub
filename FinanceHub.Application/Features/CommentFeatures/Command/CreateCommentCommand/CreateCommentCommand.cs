using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.CommentFeatures.Command.CreateCommentCommand;

public record CreateCommentCommand(Comment Comment) : IRequest<Comment>;