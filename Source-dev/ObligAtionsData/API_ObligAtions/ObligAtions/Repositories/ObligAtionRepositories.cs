using Library.Base;
using ObligAtions.Interface;
using ObligAtions.ViewModel;

namespace ObligAtions.Repositories
{
    public class ObligAtionRepositories : IInfoObligAtion
    {
        private readonly IDapperExec _dapper;
        private readonly IHistory _history;
        public ObligAtionRepositories(IDapperExec dapper, IHistory history)
        {
            _dapper = dapper;
            _history = history;
        }

        /// <summary>
        /// Thêm mới danh sách nghĩa vụ quân sự
        /// </summary>
        /// <param name="obligAtionsViewModel"></param>
        /// <returns></returns>
        public async Task<bool> InsertInfoObligAtion(ObligAtionsViewModel obligAtionsViewModel)
        {
            try
            {
                obligAtionsViewModel.TicektCode = TicketCode.RenderCode("QS");
                obligAtionsViewModel.CMND = Secirity.Encrypt(obligAtionsViewModel.CMND, "FPT");
                var list = await _dapper.ExecQueryAsyncObj("InsertObligAtion", obligAtionsViewModel);
                if (list == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                HistoryViewModel history = new HistoryViewModel()
                {
                    Desc = ex.Message,
                    ResourceName = "InsertInfoObligAtion",
                    type = 2,
                    UserID = obligAtionsViewModel.UserID
                };
                _history.CreateHistory(history);
                return false;
            }
        }
    }
}
