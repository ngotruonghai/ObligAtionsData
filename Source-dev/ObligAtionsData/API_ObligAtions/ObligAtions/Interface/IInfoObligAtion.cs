using ObligAtions.ViewModel;

namespace ObligAtions.Interface
{
    public interface IInfoObligAtion
    {
        Task<bool> InsertInfoObligAtion(ObligAtionsViewModel obligAtionsViewModel);
        Task<object> TicketObligAtionUserID(TicketUserIDViewModel model);
    }
}
