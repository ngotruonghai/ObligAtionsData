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
                    HistoryViewModel history = new HistoryViewModel()
                    {
                        Desc = "Thêm không thành công",
                        ResourceName = "InsertInfoObligAtion",
                        type = 2,
                        UserID = obligAtionsViewModel.UserID
                    };
                    await _history.CreateHistory(history);
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
                await _history.CreateHistory(history);
                return false;
            }
        }

        /// <summary>
        /// Lấy danh sách quân sự theo UserID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<object> TicketObligAtionUserID(TicketUserIDViewModel model)
        {
            try
            {
                var list = await _dapper.ExecQueryAsyncObj("TicketObligAtionUserID", model);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
