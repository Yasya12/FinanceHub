namespace FinanceGub.Application.DTOs.Message;

public class CreateMessageDto
{
    public required string SenderUsername { get; set; }
    public required string RecipientUsername { get; set; }
    public required string Content { get; set; }
}