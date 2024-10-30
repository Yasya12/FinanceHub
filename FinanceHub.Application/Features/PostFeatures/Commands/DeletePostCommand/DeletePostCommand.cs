using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.PostFeatures.Commands.DeletePostCommand;

public record DeletePostCommand (Guid Id) : IRequest<string> { }