using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.LikeFeatures.Commands.CreateLikeCommand;

public record CreateLikeCommand(Like Like) : IRequest<Like>;