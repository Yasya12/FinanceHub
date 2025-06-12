using FinanceGub.Application.DTOs.Message;
using FinanceGub.Application.Helpers;
using FinanceHub.Core.Entities;

namespace FinanceGub.Application.Interfaces.Repositories;

public interface IMessageRepository : IGenericRepository<Message>
{
    Task<int> GetUnreadMessagesCountForUser(string recipientUsername, string senderUsername);
    Task MarkMessagesAsReadByIds(IEnumerable<string> messageIds);
    Task<int> GetUnreadMessagesCountAsync(string username);
   // Task MarkMessagesAsRead(string currentUsername, string senderUsername);
   Task<IEnumerable<Message>> MarkMessagesAsRead(string currentUsername, string senderUsername);
   Task<IEnumerable<ChatUserDto>> GetLatestMessagesPerChatUserAsync(string currentUsername, string currentEmail);
    Task<PagedList<MessageDto>> GetMessagesForUser(MessageParams messageParams);

    Task<PagedList<MessageDto>> GetMessageThread(string currentUsername, string recipientUsername,
        MessageThreadParams messageThreadParams);

    void AddGroup(Group group);
    void RemoveConnection(Connection connection);
    Task<Connection?> GetConnection(string connectionId);
    Task<Group?> GetMessageGroup(string groupName);
}