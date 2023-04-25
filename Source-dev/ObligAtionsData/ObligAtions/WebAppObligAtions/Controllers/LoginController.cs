using Microsoft.AspNetCore.Mvc;
using WebAppObligAtions.Interface;
using WebAppObligAtions.Models;

namespace WebAppObligAtions.Controllers
{
    public class LoginController : Controller
    {
        private readonly IServicesAPI _api;
        public LoginController(IServicesAPI services)
        {
            _api= services;
        }
        public IActionResult Index()
        {
            _api.ClearAllSession();
            _api.SetSessionString(SessionInfo.SessionToken, "");
            return View();
        }
        [HttpPost]
        // Login/LoginToken
        public async Task<string> LoginToken(UserInfoModel user)
        {

            Boolean check= await _api.GetAPILoginToken(user, "api/UserInfo/Login");            
            if (check == true)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
    }
}
