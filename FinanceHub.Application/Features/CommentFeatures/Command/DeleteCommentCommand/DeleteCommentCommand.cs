using MediatR;

namespace FinanceGub.Application.Features.CommentFeatures.Command.DeleteCommentCommand;

public record DeleteCommentCommand(Guid Id) : IRequest<string>;