using MediatR;

namespace FinanceGub.Application.Features.LikeFeatures.Commands.DeleteLikeCommand;

public record DeleteLikeCommand(Guid Id) : IRequest<string>;