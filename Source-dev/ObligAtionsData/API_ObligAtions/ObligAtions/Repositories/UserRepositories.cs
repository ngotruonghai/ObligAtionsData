using Dapper;
using Library.Base;
using Microsoft.Extensions.Options;
using ObligAtions.Interface;
using ObligAtions.ViewModel;
using System.Data;

namespace ObligAtions.Repositories
{
    public class UserRepositories : IInfoUser
    {
        private readonly UserConnectSqlViewModel _userConnect;
        private readonly IDapperExec _dapper;
        public UserRepositories(IOptions<UserConnectSqlViewModel> userConnect, IDapperExec dapper)
        {
            _userConnect = userConnect.Value;
            _dapper = dapper;
        }

        /// <summary>
        /// Lấy danh sách UserInfo
        /// </summary>
        /// <returns></returns>
        public async Task<object> UserInfo()
        {
            try
            {
                return await _dapper.ExecQueryAsyncObj("GetInfoUser");
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return null;
            }
        }
        public async Task<Boolean> CreateUserInfo(CreateUserInfoViewModel createUserInfo)
        {
            try
            {
                string Password = createUserInfo.UserName + "123456789";
                var param = new DynamicParameters();
                param.Add("@UserName", createUserInfo.UserName);
                param.Add("@FullName", createUserInfo.FullName);
                param.Add("@Password", Secirity.Encrypt(Password,"FPT"));
                await _dapper.ExecQueryAsyncObj("CreateUserInfo", param);
                return true;
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return false;
            }
        }
        public async Task<DataSet> GetUserMenuItemsPer(int UserID)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@UserID", UserID);
                DataSet data = await _dapper.ExecQueryAsyncDataSet("GetCheckUserMenuItems", param);
                return data;
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// thêm quyền cho User menu
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Boolean> CreateUserItemsPer(CreateUserPermission model)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@UserID", model.UserID);
                param.Add("@MenuID", model.MenuItemsID);
                param.Add("@ParentID", model.ParentID);
                param.Add("@Flang", model.Flag);
                DataSet data = await _dapper.ExecQueryAsyncDataSet("CreatePermissionUserMenuItems", param);
                return true;
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return false;
            }
        }

    }
}
