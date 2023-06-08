using Microsoft.AspNetCore.Mvc;
using WebAppObligAtions.Interface;
using WebAppObligAtions.Models;

namespace WebAppObligAtions.Controllers
{
    public class MilitaryController : Controller
    {
        private readonly IServicesAPI _api;
        public MilitaryController(IServicesAPI servicesAPI)
        {
            _api = servicesAPI;
        }
        #region view
        /// <summary>
        /// Military/MilitaryCreate
        /// Tạo quân sự
        /// </summary>
        /// <returns></returns>
        public IActionResult MilitaryCreate()
        {
            return View();
        }

        /// <summary>
        /// Xem danh sách Quân Sự
        /// Military/MilitaryList
        /// </summary>
        /// <returns></returns>
        public IActionResult MilitaryList()
        {
            DateTime date = DateTime.Now.AddDays(-30);

            ViewData["FormDate"] = date.ToString("dd/M/yyyy");
            return View();
        }

        /// <summary>
        /// Xem thông tin ticket
        /// Military/MilitaryInfo?TicketCode=dsads
        /// </summary>
        /// <returns></returns>
        public IActionResult MilitaryInfo(string TicketCode)
        {
            ViewData["TicketCode"] = TicketCode;
            return View();
        }

        /// <summary>
        /// Xem thông tin và duyệt
        /// Military/MilitaryInfo?MilitaryConfirm=dsads
        /// </summary>
        /// <param name="TicketCode"></param>
        /// <returns></returns>
        public IActionResult MilitaryConfirm(string TicketCode)
        {
            ViewData["TicketCode"] = TicketCode;
            return View();
        }
        #endregion

        #region JSON
        [HttpPost]
        public async Task<IActionResult> CreateMilitary(ObligAtionsModel request)
        {
            request.UserID = _api.GetSession(SessionInfo.SessionUserID);
            return Json(await _api.PostAPI("api/Military/InsertObligAtion", request));
        }

        /// <summary>
        /// Lấy danh sach quân sự theo UserID
        /// Post: Military/TicketObligAtionUserID
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> TicketObligAtionUserID(TicketUserIDViewModel request)
        {
            request.UserID = _api.GetSession(SessionInfo.SessionUserID);
            return Json(await _api.PostAPI("api/Military/TicketObligAtionUserID", request));
        }

        /// <summary>
        /// Lấy thông tin mã tikcet
        /// Get: Military/TicketInfo?TicketCode=test
        /// </summary>
        /// <param name="TicketCode"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> TicketInfo(string TicketCode)
        {
            return Json(await _api.GetAPI($"api/Ticket/GetTicektInfo?TicketCode={TicketCode}"));
        }

        /// <summary>
        /// Danh sách lịch sử ticket
        /// Get: Military/TicketHistory?TicketID=66
        /// </summary>
        /// <param name="TicketID"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> TicketHistory(string TicketID)
        {
            return Json(await _api.GetAPI($"api/Ticket/TicketHistory?TicketID={TicketID}"));
        }
        #endregion
    }
}
