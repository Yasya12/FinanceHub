namespace FinanceGub.Application.DTOs.Message;

public class ChatUserDto
{
    public string Username { get; set; }
    public string PhotoUrl { get; set; }
    public string LastMessage { get; set; }
    public DateTime LastMessageSent { get; set; }
    public bool IsRead { get; set; }
    public int UnreadCount { get; set; } 
}
