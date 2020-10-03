using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Core.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
namespace Core.Extension
{
    public class LogInExtension : BaseExtension
    {
        public ApiResultModel<UserModel> ValidateTokenKey(string key)
        {
            //Gọi API để validate key
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl.MainApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // New code:
                //var response = client.GetAsync("Authentication/ValidateTokenKeySSO?tokenkey=" + HttpUtility.UrlEncode(key)).Result;
                //Nếu sử dụng API để get phân quyền thì truyền thêm tham số
                var response = client.PostAsync("Authentication/ValidateTokenKeySSO", new TokenKeyInfoModel { TokenKey = key, IsGetPrivilege = false, ModuleId = 0 }, new JsonMediaTypeFormatter()).Result;
                if (!response.IsSuccessStatusCode) return null;
                var result = response.Content.ReadAsAsync<ApiResultModel<UserModel>>().Result;
                return result;
            }

        }
    }
}
