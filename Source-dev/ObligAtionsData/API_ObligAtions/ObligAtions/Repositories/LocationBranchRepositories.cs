using ObligAtions.Api.Interface;
using ObligAtions.Interface;

namespace ObligAtions.Api.Repositories
{
    public class LocationBranchRepositories : ILocationBranch
    {
        private readonly IDapperExec _dapper;
        public LocationBranchRepositories(IDapperExec dapper)
        {
            _dapper = dapper;
        }

        /// <summary>
        /// Lấy danh sách Branch
        /// </summary>
        /// <returns></returns>
        public async Task<object> GetBranch()
        {
            return await _dapper.ExecQueryAsyncObj("GetBranch");
        }
    }
}
