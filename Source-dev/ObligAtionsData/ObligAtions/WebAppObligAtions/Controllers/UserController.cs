using Microsoft.AspNetCore.Mvc;
using WebAppObligAtions.Attributes;
using WebAppObligAtions.Interface;
using WebAppObligAtions.Models;

namespace WebAppObligAtions.Controllers
{

    public class UserController : Controller
    {
        /* /User/Index */
        private readonly IServicesAPI _api;
        public UserController(IServicesAPI servicesAPI)
        {
            _api = servicesAPI;
        }

        #region View
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserCreate()
        {
            return PartialView();
        }
        public IActionResult UserInfo()
        {
            return PartialView();
        }
        #endregion       
        #region Json
        [HttpGet]
        public async Task<JsonResult> GetInfoUser()
        {
            return Json(await _api.GetAPI("api/UserInfo/GetUserInfo"));
        }

        [HttpPost]
        public async Task<JsonResult> CreateInfoUser(CreateUserInfoModel infoModel)
        {
            return Json(await _api.PostAPI("api/UserInfo/CreateUserInfo", infoModel));
        }
        [HttpGet]
        public async Task<JsonResult> GetMenuItemsAll()
        {
            return Json(await _api.GetAPI("api/HomeMenu/GetMenuItems?UserID=0"));
        }

        /// <summary>
        /// Phân Quyền cho User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> CreateUserMenuPermission(CreateUserPermissionModel request)
        {
            return Json(await _api.PostAPI("api/UserInfo/CreateMenuItemsPer", request));
        }

        /// <summary>
        /// Lấy danh sách Branch
        /// Get: /User/GetBranch 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetBranch()
        {
            return Json(await _api.GetAPI("api/LocationBranch/GetBranch"));
        }
        #endregion
    }
}
