using Microsoft.AspNetCore.Mvc;
using WebAppObligAtions.Interface;
using WebAppObligAtions.Models;

namespace WebAppObligAtions.Controllers
{
    public class StatisticController : Controller
    {
        // Get: Statistic/StatisticQS
        private readonly IServicesAPI _api;
        public StatisticController(IServicesAPI servicesAPI)
        {
            _api = servicesAPI;
        }

        #region View
        public IActionResult StatisticQS()
        {
            DateTime date = DateTime.Now.AddDays(-30);
            ViewData["FormDate"] = date.ToString("dd/M/yyyy");
            return View();
        }
        #endregion

        #region Json

        /// <summary>
        /// Lấy danh sách Ticket
        /// Post: Statistic/TicketObligAtionUserID
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> TicketObligAtionUserID(TicketUserIDViewModel request)
        {
            return Json(await _api.PostAPI("api/Military/TicketObligAtionUserID", request));
        }

        /// <summary>
        /// Xác nhận mã ticket
        /// Post: Statistic/TicektConfim
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> TicektConfim(TicketConfim request)
        {
            request.UserID = int.Parse(_api.GetSession(SessionInfo.SessionUserID));
            return Json(await _api.PostAPI("api/Ticket/TicketConfim", request));
        }
        #endregion
    }
}
