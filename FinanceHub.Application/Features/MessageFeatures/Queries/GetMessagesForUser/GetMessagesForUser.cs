using FinanceGub.Application.DTOs.Message;
using FinanceGub.Application.Helpers;
using MediatR;

namespace FinanceGub.Application.Features.MessageFeatures.Queries.GetMessagesForUser;

public record GetMessagesForUser(MessageParams MessageParams) : IRequest<PagedList<MessageDto>>;