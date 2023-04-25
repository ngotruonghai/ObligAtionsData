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
        #endregion

        #region JSON
        [HttpPost]
        public async Task<IActionResult> CreateMilitary(ObligAtionsModel request)
        {
            return Json("");
        }
        #endregion
    }
}
