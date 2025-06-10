using FinanceGub.Application.DTOs.Message;

namespace FinanceGub.Application.Interfaces.Serviсes;

public interface IMessageService
{
    Task<int> GetUnreadMessagesCount(string currentUsername);
    Task MarkMessagesAsRead(string currentUsername, string senderUsername);
    Task<IEnumerable<ChatUserDto>> GetChatUsersAsync(string currentUsername);
    Task<MessageDto> CreateMessage(CreateMessageDto createMessageDto, string senderUsername);
}