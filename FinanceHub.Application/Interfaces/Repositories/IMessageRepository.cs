using FinanceGub.Application.DTOs.Message;
using FinanceGub.Application.Helpers;
using FinanceHub.Core.Entities;

namespace FinanceGub.Application.Interfaces.Repositories;

public interface IMessageRepository : IGenericRepository<Message>
{
    Task MarkMessagesAsRead(string currentUsername, string senderUsername);
    Task<IEnumerable<ChatUserDto>> GetLatestMessagesPerChatUserAsync(string currentUsername);
    Task<PagedList<MessageDto>> GetMessagesForUser(MessageParams messageParams);

    Task<PagedList<MessageDto>> GetMessageThread(string currentEmail, string recipientUsername,
        MessageThreadParams messageThreadParams);
}