using Dapper;
using Library.Base;
using ObligAtions.Api.Interface;
using ObligAtions.Api.ViewModel;
using ObligAtions.Interface;
using System.Data;

namespace ObligAtions.Api.Repositories
{
    public class TicketRepositories : ITicketInfo
    {
        private readonly IDapperExec _dapper;
        private readonly IHistory _history;
        public TicketRepositories(IDapperExec dapper, IHistory history)
        {
            _dapper = dapper;
            _history = history;
        }

        /// <summary>
        /// Lấy thông tin Ticket
        /// </summary>
        /// <param name="TicketCode"></param>
        /// <returns></returns>
        public async Task<DataTable> TicketInfo(string TicketCode)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@TicketCode", TicketCode);
                DataTable data = (await _dapper.ExecQueryAsyncDataSet("TicketInfo", param)).Tables[0];
                data.Rows[0]["cmnD1"] = Secirity.Decrypt(data.Rows[0]["cmnD1"].ToString(), "FPT");
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Xác nhận 1 mmã ticket
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> TicketConfim(TicketViewModel model)
        {
            try
            {
                await _dapper.ExecQueryAsyncObj("TicketConfim", model);
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
