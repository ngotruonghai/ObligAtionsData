using Dapper;
using ObligAtions.Api.Interface;
using ObligAtions.Interface;

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
        public async Task<object> TicketInfo(string TicketCode)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@TicketCode", TicketCode);
                var result = await _dapper.ExecQueryAsyncDataSet("TicketInfo", param);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
