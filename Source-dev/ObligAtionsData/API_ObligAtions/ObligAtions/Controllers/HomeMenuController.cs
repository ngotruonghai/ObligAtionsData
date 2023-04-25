using Microsoft.AspNetCore.Mvc;
using ObligAtions.Attributes;
using ObligAtions.Interface;
using ObligAtions.ViewModel;

namespace ObligAtions.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeMenuController : ControllerBase
    {
        private readonly IMenuItems _menuItemsRepository;
        public HomeMenuController(IMenuItems menuItemsRepository)
        {
            _menuItemsRepository = menuItemsRepository;
        }
        [HttpGet("GetMenuItems")]
        //[AuthenticationValidation]
        public async Task<IActionResult> GetMenuItems(int UserID)
        {
            DataResultViewModel<object> result = new DataResultViewModel<object>();
            result.StatusCode = StatusCodes.Status200OK;
            result.Description = ResultDescriptionViewModel.Success;
            result.Data = await _menuItemsRepository.GetMenu(UserID);
            return Ok(result);
        }
    }
}
