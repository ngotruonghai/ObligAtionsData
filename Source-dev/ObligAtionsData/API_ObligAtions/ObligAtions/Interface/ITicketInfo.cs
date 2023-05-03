using System.Data;

namespace ObligAtions.Api.Interface
{
    public interface ITicketInfo
    {
        Task<DataTable> TicketInfo(string TicketCode);
    }
}
