using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using WebAppObligAtions.Interface;
using WebAppObligAtions.Models;

namespace WebAppObligAtions.Repositories
{
    public class ServicesAPIRepositorie : IServicesAPI
    {
        private readonly string _headers = "ObligAtions";
        private readonly IHttpContextAccessor _httpContext;
        private readonly HostInfoViewModel _hostname;
        public ServicesAPIRepositorie(IHttpContextAccessor httpContext, IOptions<HostInfoViewModel> HostName)
        {
            _httpContext = httpContext;
            _hostname = HostName.Value;
        }

        #region Session
        public string GetSession(string sessionname)
        {
            return _httpContext.HttpContext.Session.GetString(sessionname).ToString();
        }
        public void SetSessionString(string sessionname, string values)
        {
            _httpContext.HttpContext.Session.SetString(sessionname, values);
        }
        public void ClearAllSession()
        {
            _httpContext.HttpContext.Session.Clear();
        }
        #endregion

        public async Task<string> GetAPI(string Url)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient httpClient = new HttpClient(clientHandler);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add(_headers, GetSession(SessionInfo.SessionToken));
            var response = await httpClient.GetAsync($"{_hostname.HostName + Url}");


            var responseObject = await response.Content.ReadAsStringAsync();
            var obj = JObject.Parse(responseObject);
            if(obj["statusCode"].ToString()!="200")
            {
                return obj["statusCode"].ToString();
            }
            else
            {
                return obj["data"].ToString();
            }
        }
        public async Task<string> PostAPI(string Url,object obj)
        {
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                HttpClient httpClient = new HttpClient(clientHandler);
                StringContent JsonUserInfo = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add(_headers, GetSession(SessionInfo.SessionToken));
                var response = await httpClient.PostAsync($"{_hostname.HostName + Url}", JsonUserInfo);
                var responseObject = await response.Content.ReadAsStringAsync();
                var result = JObject.Parse(responseObject);
                if (result["statusCode"].ToString() != "200")
                {
                    return result["statusCode"].ToString();
                }
                else
                {
                    return result["data"].ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Login lấy token
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="Url"></param>
        /// <returns></returns>
        public async Task<Boolean> GetAPILoginToken(UserInfoModel userInfo, string Url)
        {
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                HttpClient httpClient = new HttpClient(clientHandler);
                StringContent JsonUserInfo = new StringContent(JsonConvert.SerializeObject(userInfo), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(_hostname.HostName + Url, JsonUserInfo);

                var token = await response.Content.ReadAsStringAsync();
                var obj = JObject.Parse(token.ToString());
                var tokenString = obj["data"]["token"].ToString();
                if (tokenString == null || tokenString == string.Empty || tokenString == "")
                {
                    return false;
                }
                SetSessionString(SessionInfo.SessionToken, tokenString);
                SetSessionString(SessionInfo.SessionUserID, obj["data"]["userID"].ToString());
                SetSessionString(SessionInfo.SessionUserName, obj["data"]["userName"].ToString());
                return true;
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return false;
            }
        }
    }
}
