using Dapper;
using Microsoft.Extensions.Options;
using ObligAtions.Interface;
using ObligAtions.ViewModel;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace ObligAtions.Repositories
{
    public class DapperRepositories : IDapperExec
    {
        private readonly UserConnectSqlViewModel _userConnect;
        private static string key = "ObligAtionsAPI";

        public DapperRepositories(IOptions<UserConnectSqlViewModel> userConnectSql)
        {
            _userConnect = userConnectSql.Value;
        }

        private static DataSet ConvertDataReaderToDataSet(IDataReader data)
        {
            DataSet ds = new DataSet();
            int i = 0;
            while (!data.IsClosed)
            {
                ds.Tables.Add("Table" + (i + 1));
                ds.EnforceConstraints = false;
                ds.Tables[i].Load(data);
                i++;
            }
            return ds;
        }

        public async Task<DataSet> ExecQueryAsyncDataSet(string Store, DynamicParameters? param)
        {
            DataTable data;
            try
            {
                var connection = new SqlConnection(_userConnect.ConnectionString);
                var list = await SqlMapper.ExecuteReaderAsync(connection, Store, param, commandType: CommandType.StoredProcedure);
                var dataset = ConvertDataReaderToDataSet(list);
                return dataset;
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// Thực thi store truyền param
        /// </summary>
        /// <param name="Store">Tên Store</param>
        /// <param name="obj">Object</param>
        /// <returns></returns>
        public async Task<object> ExecQueryAsyncObj(string Store, object obj)
        {
            try
            {
                var connection = new SqlConnection(_userConnect.ConnectionString);
                var list = await connection.QueryAsync(Store, obj, commandType: CommandType.StoredProcedure);
                return list;
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return null;
            }
        }

        public async Task<DataSet> ExecQueryAsyncDataSet(string Store)
        {
            DataTable data;
            try
            {
                var connection = new SqlConnection(_userConnect.ConnectionString);
                var list = await SqlMapper.ExecuteReaderAsync(connection, Store, commandType: CommandType.StoredProcedure);
                var dataset = ConvertDataReaderToDataSet(list);
                return dataset;
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return null;
            }
        }

        public async Task<Object> ExecQueryAsyncObj(string Store)
        {
            try
            {
                using (var connection = new SqlConnection(_userConnect.ConnectionString))
                {
                    var sql = string.Format("Exec {0}", Store);
                    var data = await connection.QueryAsync(sql);
                    return data;
                }
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return null;
            }
        }
    }
}
