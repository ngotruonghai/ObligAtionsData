using Microsoft.AspNetCore.Mvc;
using WebAppObligAtions.Models;

namespace WebAppObligAtions.Interface
{
    public interface IServicesAPI
    {
        public Task<string> GetAPI(string Url);
        public Task<Boolean> GetAPILoginToken(UserInfoModel userInfo,string Url);
        public string GetSession(string SessionName);
        public void SetSessionString(string SessionName, string values);
        public void ClearAllSession();
        Task<string> PostAPI(string Url, object obj);
    }
}
