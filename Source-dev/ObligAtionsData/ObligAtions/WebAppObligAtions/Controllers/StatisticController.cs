using Microsoft.AspNetCore.Mvc;

namespace WebAppObligAtions.Controllers
{
    public class StatisticController : Controller
    {
        // Get: Statistic/StatisticQS
        #region View
        public IActionResult StatisticQS()
        {
            return View();
        }
        #endregion
    }
}
