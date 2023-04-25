using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using WebAppObligAtions.Attributes;
using WebAppObligAtions.Interface;
using WebAppObligAtions.Models;

namespace WebAppObligAtions.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicesAPI _api;

        public HomeController(IServicesAPI servicesAPI)
        {
            _api = servicesAPI;
        }

        public async Task<IActionResult> Index()
        {
            string token = _api.GetSession(SessionInfo.SessionToken);
            if (token.Length > 0)
            {
                int UserID = int.Parse(_api.GetSession(SessionInfo.SessionUserID).ToString());
                string html = "";
                string JsonStr = await _api.GetAPI(string.Format("api/HomeMenu/GetMenuItems?UserID={0}", UserID));
                DataSet data = JsonConvert.DeserializeObject<DataSet>(JsonStr);
                DataTable dataLevel1 = data.Tables[0];
                DataTable dataLevel2 = data.Tables[1];
                for (int i = 0; i < dataLevel1.Rows.Count; i++)
                {
                    html += "<li class=\"nav-item\">";
                    string parent = dataLevel1.Rows[i]["id"].ToString();
                    html += "<a href=\"\" class=\"nav-link with-sub\"><i data-feather=\"monitor\"></i><span>" + dataLevel1.Rows[i]["name"].ToString() + "</span></a>";
                    for (int j = 0; j < dataLevel2.Rows.Count; j++)
                    {
                        string IDparent = dataLevel2.Rows[j]["parent"].ToString();
                        if (IDparent == parent && dataLevel2.Rows[j]["link"].ToString() != "")
                        {
                            html += " <nav style=\"cursor: pointer;\" class=\"nav-sub\"><a  onclick=\"Loadpage('" + dataLevel2.Rows[j]["link"].ToString() + "')\"class=\"sub-link active\">" + dataLevel2.Rows[j]["name"].ToString() + "</a></nav>";
                        }
                    }
                    html += "</li>";
                }
                ViewData["Greeting"] = html;
                ViewData["UserName"] = _api.GetSession(SessionInfo.SessionUserName);
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<JsonResult> GetMenuItems()
        {
            int UserID = int.Parse(_api.GetSession(SessionInfo.SessionUserID).ToString());
            return Json(await _api.GetAPI(string.Format("api/HomeMenu/GetMenuItems?UserID={0}", UserID)));
        }
        [HttpGet]
        public async Task<JsonResult> GetMenuItemsUser(int UserID)
        {
            return Json(await _api.GetAPI("api/UserInfo/GetUserMenuItemsPer?UserID=" + UserID));
        }
    }

}