using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ObligAtions.Api.Interface;
using ObligAtions.ViewModel;

namespace ObligAtions.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketInfo _ticket;
        public TicketController(ITicketInfo ticketInfo)
        {
            _ticket= ticketInfo;
        }

        [HttpGet("GetTicektInfo")]
        public async Task<IActionResult> GetTicektInfo(string TicketCode)
        {
            DataResultViewModel<object> result = new DataResultViewModel<object>();
            result.StatusCode = StatusCodes.Status200OK;
            result.Description = "Success";
            result.Data = await _ticket.TicketInfo(TicketCode);
            return Ok(result);
        }
    }
}
