using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.MessageFeatures.Queries.GetMessageById;

public record GetMessageById(Guid Id) : IRequest<Message>;