using ObligAtions.Interface;
using ObligAtions.ViewModel;
using System.Data;

namespace ObligAtions.Repositories
{
    public class HistoryRepositories : IHistory
    {
        private readonly IDapperExec _dapper;
        public HistoryRepositories(IDapperExec dapper)
        {
            _dapper= dapper;
        }
        public Task<object> CreateHistory(HistoryViewModel history)
        {
            var data=_dapper.ExecQueryAsyncObj("CreateHistory",history);
            return data;
        }
    }
}
