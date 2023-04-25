using Microsoft.AspNetCore.Mvc;
using WebAppObligAtions.Attributes;
using WebAppObligAtions.Interface;
using WebAppObligAtions.Models;

namespace WebAppObligAtions.Controllers
{

    public class UserController : Controller
    {
        private readonly IServicesAPI _api;
        public UserController(IServicesAPI servicesAPI)
        {
            _api = servicesAPI;
        }
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

        [HttpPost]
        public async Task<JsonResult> CreateUserMenuPermission(CreateUserPermissionModel request)
        {
            return Json(await _api.PostAPI("api/UserInfo/CreateMenuItemsPer", request));
        }
        #endregion
    }
}
