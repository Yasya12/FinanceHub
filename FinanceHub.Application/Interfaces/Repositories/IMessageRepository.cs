using FinanceGub.Application.DTOs.Message;
using FinanceGub.Application.Helpers;
using FinanceHub.Core.Entities;

namespace FinanceGub.Application.Interfaces.Repositories;

public interface IMessageRepository : IGenericRepository<Message>
{
    Task<PagedList<MessageDto>> GetMessagesForUser(MessageParams messageParams);
    Task<PagedList<MessageDto>> GetMessageThread(string currentEmail, string recipientUsername, MessageThreadParams messageThreadParams);
}