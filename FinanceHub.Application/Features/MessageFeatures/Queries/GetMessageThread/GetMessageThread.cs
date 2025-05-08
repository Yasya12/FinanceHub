using FinanceGub.Application.DTOs.Message;
using FinanceGub.Application.Helpers;
using MediatR;

namespace FinanceGub.Application.Features.MessageFeatures.Queries.GetMessageThread;

public record GetMessageThread(string CurrentUsername, string RecipientUsername, MessageThreadParams MessageThreadParams) : IRequest<PagedList<MessageDto>>;