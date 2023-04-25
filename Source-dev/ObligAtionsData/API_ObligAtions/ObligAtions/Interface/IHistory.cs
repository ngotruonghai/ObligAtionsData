using ObligAtions.ViewModel;
using System.Data;

namespace ObligAtions.Interface
{
    public interface IHistory
    {
        Task<object> CreateHistory(HistoryViewModel history);
    }
}
