using Library.Base;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ObligAtions.Api.Interface;
using ObligAtions.Api.ViewModel;
using ObligAtions.Attributes;
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
            _ticket = ticketInfo;
        }

        [HttpGet("GetTicektInfo")]
        [AuthenticationValidation]
        public async Task<IActionResult> GetTicektInfo(string TicketCode)
        {
            DataResultViewModel<object> result = new DataResultViewModel<object>();
            result.StatusCode = StatusCodes.Status200OK;
            result.Description = "Success";
            result.Data = await _ticket.TicketInfo(TicketCode);
            return Ok(result);
        }


        [HttpPost("TicketConfim")]
        [AuthenticationValidation]
        public async Task<IActionResult> TicketConfim(TicketViewModel request)
        {
            DataResultViewModel<object> result = new DataResultViewModel<object>();
            result.StatusCode = StatusCodes.Status200OK;
            result.Description = "Success";
            result.Data = await _ticket.TicketConfim(request);
            return Ok(result);
        }
    }
}
