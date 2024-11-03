using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.CommentFeatures.Commands.CreateCommentCommand;

public record CreateCommentCommand(Comment Comment) : IRequest<Comment>;