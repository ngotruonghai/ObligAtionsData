namespace ObligAtions.Api.Interface
{
    public interface ITicketInfo
    {
        Task<object> TicketInfo(string TicketCode);
    }
}
