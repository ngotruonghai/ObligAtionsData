using Microsoft.AspNetCore.Mvc;
using ObligAtions.Attributes;
using ObligAtions.Interface;
using ObligAtions.ViewModel;

namespace ObligAtions.Controllers
{
    [ApiController]
    //[ApiVersion("2.0")]
    [Route("api/[controller]")]
    public class UserInfoController : ControllerBase
    {
        #region private

        private readonly IInfoUser _infoUser;
        private readonly ITokenRepository _token;

        #endregion

        public UserInfoController(IInfoUser infoUser, ITokenRepository token)
        {
            _infoUser = infoUser;
            _token = token;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginViewModel login)
        {
            DataResultViewModel<object> result = new DataResultViewModel<object>();
            result.StatusCode = StatusCodes.Status200OK;
            result.Description = "Success";
            result.Data = await _token.GenerateJwtToken(login);
            return Ok(result);
        }

        [HttpGet("GetUserInfo")]
        //[AuthorizationValidationAttribute(Roles = "USI")]
        [AuthenticationValidation]
        public async Task<IActionResult> GetUserInfo()
        {
            try
            {
                DataResultViewModel<object> result = new DataResultViewModel<object>();
                result.StatusCode = StatusCodes.Status200OK;
                result.Description = ResultDescriptionViewModel.Success;
                result.Data = await _infoUser.UserInfo();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("CreateUserInfo")]
        [AuthorizationValidationAttribute(Roles = "USC")]
        public async Task<IActionResult> CreateUserInfo(CreateUserInfoViewModel viewModel)
        {
            try
            {
                DataResultViewModel<object> result = new DataResultViewModel<object>();
                result.StatusCode = StatusCodes.Status200OK;
                result.Description = ResultDescriptionViewModel.Success;
                result.Data = await _infoUser.CreateUserInfo(viewModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetUserMenuItemsPer")]
        [AuthenticationValidation]
        public async Task<IActionResult> GetUserMenuItemsPer(int UserID)
        {
            try
            {
                DataResultViewModel<object> result = new DataResultViewModel<object>();
                result.StatusCode = StatusCodes.Status200OK;
                result.Description = ResultDescriptionViewModel.Success;
                result.Data = await _infoUser.GetUserMenuItemsPer(UserID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("CreateMenuItemsPer")]
        [AuthorizationValidation(Roles = "USU")]
        public async Task<IActionResult> CreateMenuItemsPer(CreateUserPermission model)
        {
            try
            {
                DataResultViewModel<object> result = new DataResultViewModel<object>();
                result.StatusCode = StatusCodes.Status200OK;
                result.Description = ResultDescriptionViewModel.Success;
                result.Data = await _infoUser.CreateUserItemsPer(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
