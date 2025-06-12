namespace FinanceHub.SignalR.Pag;

public class PaginatedResultSig<T> where T : class
{
    public List<T> Items { get; set; }
    public PaginationHeaderSig Pagination { get; set; }
}
