namespace ObligAtions.ViewModel
{
    public class UserConnectSqlViewModel
    {
        public string? ConnectionString { get; set; }
    }
    public class UserLoginViewModel
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
    public class JwtTokenViewModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Description { get; set; }
        public string? UserID { get; set; }
        public string? UserName { get; set; }

    }
    public class JwtViewModel
    {
        public string? Key { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string? Subject { get; set; }
    }
    public class LoginResponseViewModel
    {
        public int StatusCode { get; set; }
        public string Description { get; set; }
        public object Data { get; set; }
    }
    public class CreateUserInfoViewModel
    {
        public string? UserName { get; set; }
        public string? FullName { get; set; }
    }
    public class CheckUserInfoViewModel
    {
        public string? ID { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
    }
    public class CreateUserPermission
    {
        public int UserID { get; set; }
        public int MenuItemsID { get; set; }
        public int ParentID { get; set; }
        public int Flag { get; set; }
    }
    public class ResultDescriptionViewModel
    {
        public const string Success = "Success";
        public const string NotFound = "NotFound";
    }
}
