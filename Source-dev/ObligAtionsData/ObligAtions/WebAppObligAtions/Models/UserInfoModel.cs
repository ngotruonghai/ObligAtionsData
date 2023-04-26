namespace WebAppObligAtions.Models
{
    public class UserInfoModel
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
    public static class SessionInfo
    {
        public static string SessionToken = "TokenJWT";
        public static string SessionUserID = "UserID";
        public static string SessionUserName = "UserName";
    }
    public class HostInfoViewModel
    {
        public string? HostName { get; set;}
    }
    public class CreateUserInfoModel
    {
        public string? BranchCode { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
    }
    public class CreateUserPermissionModel
    {
        public int UserID { get; set; }
        public int MenuItemsID { get; set; }
        public int ParentID { get; set; }
        public int Flag { get; set; }
    }
}
