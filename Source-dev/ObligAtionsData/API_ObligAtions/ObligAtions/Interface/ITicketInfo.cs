using ObligAtions.Api.ViewModel;
using System.Data;

namespace ObligAtions.Api.Interface
{
    public interface ITicketInfo
    {
        Task<DataTable> TicketInfo(string TicketCode);
        Task<bool> TicketConfim(TicketViewModel model);
        Task<DataTable> TicketHistory(string TicketID);
    }
}
