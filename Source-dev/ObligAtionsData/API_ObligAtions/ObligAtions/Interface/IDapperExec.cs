using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace ObligAtions.Interface
{
    public interface IDapperExec
    {
        Task<DataSet> ExecQueryAsyncDataSet(string Store, DynamicParameters? param);
        Task<object> ExecQueryAsyncObj(string Store, object obj);
        Task<DataSet> ExecQueryAsyncDataSet(string Store);
        Task<Object> ExecQueryAsyncObj(string Store);
    }
}
