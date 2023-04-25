using ObligAtions.ViewModel;
using System.Data;

namespace ObligAtions.Interface
{
    public interface IInfoUser
    {
        Task<object> UserInfo();
        Task<Boolean> CreateUserInfo(CreateUserInfoViewModel createUserInfo);
        Task<DataSet> GetUserMenuItemsPer(int UserID);
        Task<Boolean> CreateUserItemsPer(CreateUserPermission model);
    }
}
