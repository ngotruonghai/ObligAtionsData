using Dapper;
using Microsoft.Extensions.Options;
using ObligAtions.Interface;
using ObligAtions.ViewModel;
using System.Data;

namespace ObligAtions.Repositories
{
    public class MenuItemsRepository : IMenuItems
    {
        private readonly UserConnectSqlViewModel _userConnect;
        private readonly IDapperExec _dapper;
        public MenuItemsRepository(IOptions<UserConnectSqlViewModel> userConnect, IDapperExec dapper)
        {
            _userConnect = userConnect.Value;
            _dapper= dapper;
        }
        public async Task<DataSet> GetMenu(int UserID)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@UserID", UserID);
                var result = await _dapper.ExecQueryAsyncDataSet("GetMenuItems", param);
                return result;
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return null;
            }
        }
    }
}
