using Dapper;
using Library.Base;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ObligAtions.Interface;
using ObligAtions.ViewModel;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ObligAtions.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        #region
        private readonly JwtViewModel _jwtAccessor;
        private readonly UserConnectSqlViewModel _userConnect;
        private readonly IDapperExec _dapper;
        #endregion
        public TokenRepository(IOptions<JwtViewModel> jwtAccessor, IOptions<UserConnectSqlViewModel> userConnect, IDapperExec dapper)
        {
            _jwtAccessor = jwtAccessor.Value;
            _userConnect = userConnect.Value;
            _dapper = dapper;
        }
        public async Task<JwtTokenViewModel> GenerateJwtToken(UserLoginViewModel request)
        {
            CheckUserInfoViewModel data = await GetUserInfo(request);
            if ((data.UserName != string.Empty && data.FullName != string.Empty) && (data.UserName != null && data.FullName != null))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtAccessor.Key);
                var claims = new List<Claim>();
                //var claims = new Claim[] {
                //    new Claim("UserName",request.UserName),
                //    new Claim("Password",request.Password),
                //};
                claims.Add(new Claim("UserName", request.UserName));
                //claims.Add(new Claim("Password", request.Password));

                DataTable dataPermission = await GetUserInfoPermission(data.UserName, data.FullName);
                if (dataPermission.Rows.Count > 0)
                {
                    for (int i = 0; i < dataPermission.Rows.Count; i++)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, dataPermission.Rows[i]["key"].ToString()));

                    }
                }
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = new JwtTokenViewModel
                {
                    RefreshToken = new RefreshTokenGenerator().GenerateRefreshToken(32),
                    Token = tokenHandler.WriteToken(token),
                    Description = ResultDescriptionViewModel.Success,
                    UserID = data.ID,
                    UserName = data.FullName
                };

                return jwtToken;
            }
            else
            {
                var jwtToken = new JwtTokenViewModel
                {
                    RefreshToken = null,
                    Token = null,
                    Description = "Tên đăng nhập không đúng"
                };

                return jwtToken;
            }
        }
        private async Task<CheckUserInfoViewModel> GetUserInfo(UserLoginViewModel user)
        {
            try
            {
                CheckUserInfoViewModel createUser = new CheckUserInfoViewModel();
                DataTable datalistUser = (await _dapper.ExecQueryAsyncDataSet("GetListUser")).Tables[0];

                for (int i = 0; i < datalistUser.Rows.Count; i++)
                {
                    if (user.UserName == datalistUser.Rows[i]["UserName"].ToString() && user.Password == Secirity.Decrypt(datalistUser.Rows[i]["Password"].ToString(), "FPT"))
                    {
                        createUser.UserName = datalistUser.Rows[i]["UserName"].ToString();
                        createUser.FullName = datalistUser.Rows[i]["FullName"].ToString();
                        createUser.ID = datalistUser.Rows[i]["ID"].ToString();
                    }
                }
                return createUser;
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// Kiểm tra đăng nhập
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task<DataTable> GetUserInfoPermission(string UserName, string FullName)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@UserName", UserName);
                param.Add("@FullName", FullName);
                DataSet dataset = await _dapper.ExecQueryAsyncDataSet("GetPermissionMenuUser", param);
                return dataset.Tables[0];
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return null;
            }
        }
    }
    public class RefreshTokenGenerator
    {
        public string GenerateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }

        public string GenerateRefreshToken(int size)
        {
            var refToken = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(refToken);

                return Convert.ToBase64String(refToken);
            }
        }
    }
}
