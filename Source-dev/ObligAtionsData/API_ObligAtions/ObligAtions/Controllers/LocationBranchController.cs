using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ObligAtions.Api.Interface;
using ObligAtions.Attributes;
using ObligAtions.Repositories;
using ObligAtions.ViewModel;

namespace ObligAtions.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationBranchController : ControllerBase
    {
        private ILocationBranch _locationBranch;

        
        public LocationBranchController(ILocationBranch locationBranch)
        {
            _locationBranch = locationBranch;
        }

        [HttpGet("GetBranch")]
        [AuthenticationValidation]
        public async Task<IActionResult> GetBranch()
        {
            DataResultViewModel<object> result = new DataResultViewModel<object>();
            result.StatusCode = StatusCodes.Status200OK;
            result.Description = ResultDescriptionViewModel.Success;
            result.Data = await _locationBranch.GetBranch();
            return Ok(result);
        }
    }
}
