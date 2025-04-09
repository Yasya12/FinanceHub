namespace FinanceGub.Application.Helpers;

public class MessageParams //: PaginationParams
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public required string Username { get; set; }
    public string Container { get; set; } = "Unread";
}