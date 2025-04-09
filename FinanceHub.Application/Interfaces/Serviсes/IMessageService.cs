using FinanceGub.Application.DTOs.Message;

namespace FinanceGub.Application.Interfaces.Serviсes;

public interface IMessageService
{
    Task<MessageDto> CreateMessage(CreateMessageDto createMessageDto);
}