using FinanceGub.Application.DTOs.Message;
using MediatR;

namespace FinanceGub.Application.Features.MessageFeatures.Queries.GetMessageThread;

public record GetMessageThread(string CurrentUsername, string RecipientUsername) : IRequest<IEnumerable<MessageDto>>;