using System.Data;

namespace ObligAtions.Interface
{
    public interface  IMenuItems
    {
        Task<DataSet> GetMenu(int UserID);
    }
}
