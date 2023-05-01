using Microsoft.AspNetCore.Mvc;
using ObligAtions.Attributes;
using ObligAtions.Interface;
using ObligAtions.Repositories;
using ObligAtions.ViewModel;

namespace ObligAtions.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MilitaryController : ControllerBase
    {
        private readonly IInfoObligAtion _infoOblig;
        public MilitaryController(IInfoObligAtion obligAtion)
        {
            _infoOblig = obligAtion;
        }

        [HttpPost("InsertObligAtion")]
        [AuthorizationValidation(Roles = "AUSC")]
        public async Task<IActionResult> InsertObligAtion(ObligAtionsViewModel request)
        {
            DataResultViewModel<object> result = new DataResultViewModel<object>();
            result.StatusCode = StatusCodes.Status200OK;
            result.Description = ResultDescriptionViewModel.Success;
            result.Data = await _infoOblig.InsertInfoObligAtion(request);
            return Ok(result);
        }

        [HttpPost("TicketObligAtionUserID")]
        [AuthorizationValidation(Roles = "AUSV")]
        public async Task<IActionResult> TicketObligAtionUserID(TicketUserIDViewModel request)
        {
            DataResultViewModel<object> result = new DataResultViewModel<object>();
            result.StatusCode = StatusCodes.Status200OK;
            result.Description = ResultDescriptionViewModel.Success;
            result.Data = await _infoOblig.TicketObligAtionUserID(request);
            return Ok(result);
        }
    }
}
