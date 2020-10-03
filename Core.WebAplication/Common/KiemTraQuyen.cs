using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.ComponentModel;
using Core.Business;
using Core.Models;
using Core.Models.Entities;
using Core.Models.Input;
using Core.Models.Output;
namespace Core.WebAplication.Common
{    
    public class KiemTraQuyen : AuthorizeAttribute
    {
        //public bool IsMenu;
        /// <summary>
        /// Thông tin Action cần check phân quyền
        /// </summary>
        public long[] Action { get; set; }
        private bool _HasPermission = false;
        private bool _IsLogged = false;
        private readonly string _ssoApi = Constants.SsoUrl.SsoApiUrl;
        private readonly string _ssoUrl  = Constants.SsoUrl.SsoLinkUrl;
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = (UserInfoModel)httpContext.Session[Constants.SessionKeys.UserInfo];
            if (user == null)
            {
                _IsLogged = false;
            }
            else
            {
                _IsLogged = true;
                //Neu yeu cau check accion
                if (user.ROLE == Constants.Role.SuperAdmin || Action == null)
                {
                    _HasPermission = true;
                }
                else
                {
                    _HasPermission = Action.Any(t => 
                                                     (
                                                         (user.ListMenu != null)
                                                         &&
                                                         (user.ListMenu.Where(x => x.ID == t).ToList().Count > 0)
                                                     )                                                     
                    );
                }
                if(_HasPermission && Action != null)
                {
                    LogBusiness log = new LogBusiness();
                    log.LogThaoTac(user.USER_NAME, httpContext.Request.Url.LocalPath, httpContext.Request.Url.OriginalString, Action[0]);
                }
                return _HasPermission;
            }
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (_IsLogged == false)
            {                
                //Kiểm tra có phải đăng nhập qua SSO hay không
                if (filterContext.HttpContext.Request.Url != null)
                {
                    var url = filterContext.HttpContext.Request.Url.AbsoluteUri;
                    var key = filterContext.HttpContext.Request.QueryString["tokenkey"];
                    var idx = url.ToLower().IndexOf("tokenkey", StringComparison.Ordinal);
                    if (idx > 0)
                        url = url.Substring(0, idx - 1);

                    if (!String.IsNullOrEmpty(key))
                    {
                        var userIdQueryString = filterContext.HttpContext.Request.QueryString["userid"];
                        long userId = 0;
                        if (!string.IsNullOrWhiteSpace(userIdQueryString) && long.TryParse(userIdQueryString, out userId))
                        {
                            var result = ValidateTokenKey(key);
                            if (result?.Data != null)
                            {
                                _IsLogged = true;
                                UserInfoModel userInfoModel = new UserInfoModel();
                                //userInfoModel.USER_NAME = "abcasdasd";
                                userInfoModel.USER_NAME = result.Data.TenDangNhap;
                                //_IsLogged = LogOn(0, result.Data, filterContext.HttpContext);
                                QuanTriBusiness qt = new QuanTriBusiness();
                                LogBusiness log = new LogBusiness();
                                var user = new ResultModel<DM_NHAN_VIEN>();
                                //user = qt.LoginSuccess("abc");                               
                                user = qt.LoginSuccess(result.Data.TenDangNhap);
                                //Log đăng nhập
                                if (filterContext.HttpContext.Request.ServerVariables["LOCAL_ADDR"] != "127.0.0.1"
                                    && filterContext.HttpContext.Request.ServerVariables["LOCAL_ADDR"] != "::1"
                                    )
                                {
                                    log.LogDangNhap(result.Data.TenDangNhap, HttpContext.Current.Session.SessionID, 1,
                                    filterContext.HttpContext.Request.ServerVariables["LOCAL_ADDR"],
                                    filterContext.HttpContext.Request.ServerVariables["REMOTE_ADDR"],
                                    filterContext.HttpContext.Request.Browser.Browser,
                                    1);
                                }    
                                if (!user.IsError)
                                {
                                    userInfoModel.ID = user.Data.ID;
                                    userInfoModel.ROLE = user.Data.ROLE;
                                    userInfoModel.DON_VI_ID = user.Data.DON_VI_ID;
                                    //Lấy danh sách quyền Menu                
                                    //userInfoModel.ListMenu = qt.GetMenuByNhanvien(user.Data.ID).Data;
                                    if (userInfoModel.ROLE == Constants.Role.SuperAdmin)
                                    {
                                        userInfoModel.ListMenu = qt.GetAllMenu().Data;
                                    }
                                    else
                                    {
                                        userInfoModel.ListMenu = qt.GetMenuByNhanvien(user.Data.ID).Data;
                                    }                                                                    
                                    
                                }
                                userInfoModel.HeThongId = 1;
                                //Gán vào CommonLib.UserInfo <-> MySession.UserInfo.
                                SessionInfo.UserInfo = userInfoModel;
                            }
                            //Kiểm tra lại xem đã đăng nhập thành công hay chưa
                            if (_IsLogged)
                            {
                                filterContext.Result = new RedirectResult(url);
                                return;
                            }
                        }

                        filterContext.Result = new RedirectToRouteResult(
                            new RouteValueDictionary
                            {
                                { "action", "UnAuthorized" },
                                { "controller", "ErrorsHandler" },
                                { "Area", String.Empty }
                            });
                        return;
                    }
                    else
                    {
                        if (filterContext.HttpContext.Request.IsAjaxRequest())
                        {
                            UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
                            filterContext.HttpContext.Response.StatusCode = 401;
                            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                            filterContext.HttpContext.Response.ContentType = "application/json";
                            filterContext.Result = new JsonResult
                            {
                                Data = new
                                {
                                    ErrorCode = "-1",
                                    ErrorMessage = "NotAuthorized",
                                    Url = urlHelper.Action("Index", "Home", new { returnUrl = url, area = "" })
                                },
                                JsonRequestBehavior = JsonRequestBehavior.AllowGet
                            };
                        }
                        else
                        {                           
                                filterContext.Result = new RedirectResult($"{_ssoUrl}?returnUrl={url}");
                        }
                    }
                }
            }
            else
            {
                if (_HasPermission == false)
                {
                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
                        filterContext.Result = new JsonResult
                        {
                            Data = new
                            {
                                ErrorCode = "-2",
                                ErrorMessage = "NotPermission",
                                Url = urlHelper.Action("Index", "Home")
                            },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                    }
                    else
                    {
                        filterContext.Result = new RedirectToRouteResult(
                                               new RouteValueDictionary
                                   {
                                       { "action", "Index" },
                                       { "controller", "Home" }
                                   });
                    }
                }
                else
                {
                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
                        filterContext.Result = new JsonResult
                        {
                            Data = new
                            {
                                ErrorCode = "-1",
                                ErrorMessage = "NotAuthorized",
                                Url = urlHelper.Action("Index", "Home")
                            },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                    }
                    else
                    {
                        filterContext.Result = new RedirectToRouteResult(
                                           new RouteValueDictionary
                                   {
                                       { "action", "Index" },
                                       { "controller", "Home" },
                                       { "returnUrl", filterContext.HttpContext.Request.RawUrl }
                                   });
                    }
                }
            }
        }
        #region SSO        
             
        
        private ApiResultModel<UserModel> ValidateTokenKey(string key)
        {

            //Gọi API để validate key

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_ssoApi);
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

        #endregion SSO
        public class CustomResultFilter : ActionFilterAttribute
        {
            public override void OnResultExecuted(ResultExecutedContext filterContext)
            {
                var rd = filterContext.RouteData;
                rd.GetRequiredString("controller");
                rd.GetRequiredString("action");
                //string tg = filterContext.RequestContext.HttpContext.
            }
        }
    }
}