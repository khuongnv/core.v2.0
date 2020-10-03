using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Core.Models.Entities;
using Core.Models.Input;
using Core.Models.Output;
using System.Web;
using System.Web.Mvc;
namespace Core.WebAplication.Common
{
    public class Constants
    {
        public sealed class SessionKeys
        {
            public const string UserInfo = "SESSION_USER_INFO";
            public const string CultureInfo = "CURRENT_CULTURE_INFO";
        }
        public sealed class ActionReturn
        {
            public const string Error = "ERROR";
            public const string Success = "SUCCESS";

            public const int MinPageIndex = 1;
            public const int MaxPageSize = 1000;
        }
        public sealed class Mode
        {
            /// <summary>
            /// Thêm mới
            /// </summary>
            public const int Add = 1;
            /// <summary>
            /// Chỉnh sửa
            /// </summary>
            public const int Edit = 2;
        }
        public sealed class Role
        {            
            public const int SuperAdmin = 0;
            public const int Admin = 1;
            public const int Member = 2;
            
        }
        public sealed class Menu
        {  
            #region "QUAN TRI"
            public const int QUAN_TRI_MENU = 29;
            public const int QUAN_TRI_LOG_USER = 1;
            public const int QUAN_TRI_LOG_THAO_TAC = 1;
            public const int QUAN_TRI_DON_VI = 138;
            public const int QUAN_TRI_NHAN_VIEN = 3;
            #endregion "QUAN TRI"
        }
        public sealed class ChucNang
        {
            public const int DANG_NHAP = 1801;            
        }
        public sealed class SsoUrl
        {
            //public const string SsoApiUrl = "http://10.10.40.184/api/api/";
            //public const string SsoLinkUrl = "http://10.10.40.184/sso/account/SSOLogOn";
            //public const string SsoLogOutUrl = "http://10.10.40.184/SSO/account/logoff";
            public const string SsoApiUrl = "https://id.hanoi.vnpt.vn/api/api/";
            public const string SsoLinkUrl = "https://id.hanoi.vnpt.vn/account/SSOLogOn";
            public const string SsoLogOutUrl = "https://id.hanoi.vnpt.vn/account/logoff";
        }
        public static string ServerUrl => $"{HttpContext.Current.Request.Url.Scheme}://{HttpContext.Current.Request.Url.Authority}{new UrlHelper(HttpContext.Current.Request.RequestContext).Content("~")}";
    }
}
