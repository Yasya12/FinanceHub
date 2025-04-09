namespace FinanceGub.Application.DTOs.Message;

public class MessageDto
{
    public Guid Id { get; set; }
    public Guid SenderId { get; set; }
    public required string SenderUserName { get; set; }
    public required string SenderUPhotoUrl { get; set; }
    public Guid RecipientId { get; set; }
    public required string RecipientUserName { get; set; }
    public required string RecipientUPhotoUrl { get; set; }
    public required string Content { get; set; }
    public DateTime? DateRead { get; set; }
    public DateTime MessageSent { get; set; }
}