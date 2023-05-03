using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using ObligAtions.Repositories;
using ObligAtions.ViewModel;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;

namespace ObligAtions.Attributes
{
    public class AuthenticationValidationAttribute : ActionFilterAttribute
    {
        private readonly string Key = "!@123ABCTICKET456DEF!@";

        public override async void OnActionExecuting(ActionExecutingContext context)
        {
            var token = context.HttpContext.Request.Headers["ObligAtions"].FirstOrDefault()?.Split(" ").Last();
            var service = context.HttpContext.RequestServices.GetService<UserRepositories>();
            // Authentication - xác minh Token User truyền vào hợp lệ hay không
            if (token != null)
            {
                var check = true;
                if (!check)
                {
                    context.Result = new UnauthorizedObjectResult(
                      new LoginResponseViewModel
                      {
                          StatusCode = (int)HttpStatusCode.Unauthorized,
                          Description = "Lỗi Token sai",
                          Data = "Unauthorized, login or re-login again."
                      });
                }
                ValidateToken(token, context);
            }
            else
            {
                context.Result = new UnauthorizedObjectResult(
                       new LoginResponseViewModel
                       {
                           StatusCode = (int)HttpStatusCode.Unauthorized,
                           Description = "Chưa có Token",
                           Data = "Unauthorized, login or re-login again."
                       });
            }

            base.OnActionExecuting(context);
        }
        public void ValidateToken(string Token, ActionExecutingContext context)
        {
            try
            {                
                //var test = service.UserInfo();
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Key);
                var a = tokenHandler.ValidateToken(Token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                //var accountId = int.Parse(jwtToken.Claims.First(x => x.role == "role").Value);
                var roles = jwtToken.Claims.Where(c => c.Type == "role").Select(c => c.Value).ToList();

                foreach(var i in roles)
                {
                    string asd = i.ToString();
                }

                // attach user to context on successful jwt validation

            }
            catch (Exception ex)
            {
                context.Result = new UnauthorizedObjectResult(
                    new LoginResponseViewModel
                    {
                        StatusCode = (int)HttpStatusCode.Unauthorized,
                        Description = "Lỗi Token sai",
                        Data = ex.Message.ToString()
                    }); ;
            }
        }
    }
}
