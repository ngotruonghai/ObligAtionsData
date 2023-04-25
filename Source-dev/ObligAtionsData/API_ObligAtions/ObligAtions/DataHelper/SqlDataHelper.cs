using Dapper;
using Microsoft.AspNetCore.Connections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ObligAtions.DataHelper
{
    public static class SqlDataHelper
    {
        #region private

        #endregion

        /// <summary>
        /// QueryAsync
        /// </summary>
        /// <param name="ConnectionString">Chuỗi Connect</param>
        /// <param name="stored">Lệnh thực thi</param>
        /// <returns></returns>
        public static async Task<object> QueryAsync(string ConnectionString, string stored)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = string.Format("Exec {0}", stored);
                var data = await connection.QueryAsync(sql);
                return data;
            }
        }

        public static async Task<DataTable> QueryParameterAsyncObj(string ConnectionString, DynamicParameters parm)
        {
            //using (var connection = new SqlConnection(ConnectionString))
            //{
            //    var sql = string.Format("Exec {0}", stored);
            //    var results = (await connection.QueryAsync(sql, objects));
            //    var dataset = ConvertDataReaderToDataSet(results);
            //    return results;
            //}
            try
            {
                var connection = new SqlConnection(ConnectionString);
                var param = new DynamicParameters();
                param.Add("@UserID", 5);
                //var param = new DynamicParameters();
                //param.Add("@UserID", param);
                var list = await SqlMapper.ExecuteReaderAsync(connection, "GetMenuItems", parm, commandType: CommandType.StoredProcedure);
                var dataset = ConvertDataReaderToDataSet(list);
                return dataset.Tables[0];
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return null;
            }
        }

        public static async Task<dynamic> QueryParameterAsync(string ConnectionString, string stored, object objects)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = string.Format("Exec {0}", stored);
                List<dynamic> results = (await connection.QueryAsync(sql, objects)).ToList();
                return results;
            }
        }

        public static dynamic QueryParameter(string ConnectionString, string stored, object objects)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = string.Format("Exec {0}", stored);
                List<dynamic> results = (connection.Query(sql, objects)).ToList();
                return results;
            }
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



    }
}
