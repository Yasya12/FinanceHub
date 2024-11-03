using MediatR;

namespace FinanceGub.Application.Features.CommentFeatures.Commands.DeleteCommentCommand;

public record DeleteCommentCommand(Guid Id) : IRequest<string>;