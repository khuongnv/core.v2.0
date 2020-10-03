using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.WebAplication.Common;
using Core.Models;
using Core.Models.Input;
using Core.Models.Entities;
using Core.Business;

namespace Core.WebAplication.Controllers
{
    [KiemTraQuyen]
    public class HomeController : BaseController
	{        
        public HomeController()
        {

        }        
        public ActionResult Index()
        {            
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login(string redirectUrl)
        {
            return View(new LoginModel() { RedirectUrl = redirectUrl });
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Logout()
        {
            SessionInfo.UserInfo = null;
            Session.Clear();
            Session.Abandon();
            string returnurl = "";
            if (Request.Url != null)
            {
                returnurl = Request.Url.GetLeftPart(UriPartial.Authority) + Url.Content("~");                
            }
            return Redirect(Constants.SsoUrl.SsoLogOutUrl + "?returnUrl="+ returnurl);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]

        public ActionResult Login(LoginModel model)
        {

            MenuBusiness _menu = new MenuBusiness();
            UserInfoModel userInfoModel = new UserInfoModel();
            userInfoModel.USER_NAME = model.UserName;
            userInfoModel.ID = 1;
            userInfoModel.ROLE = Constants.Role.SuperAdmin;
            userInfoModel.ListMenu = _menu.GetAllMenu().Data;
            userInfoModel.HeThongId = 1;
            //Xac thuc user
            //QuanTriBusiness qt = new QuanTriBusiness();
            //var user = new ResultModel<DM_NHAN_VIEN>();
            //user = qt.CheckAccount(model.UserName, model.Password);
            //if (user.IsError == true)
            //{
            //    ViewData["ActionReturn"] = Json(new ActionReturn { Code = Constants.ActionReturn.Error, Message = user.Message}, JsonRequestBehavior.AllowGet);;
            //    return View();
            //}
            //else
            //{                
            //    UserInfoModel userInfoModel = new UserInfoModel();
            //    userInfoModel.USER_NAME = user.Data.USER_NAME;
            //    userInfoModel.ID = user.Data.ID;
            //    userInfoModel.ROLE = user.Data.ROLE;
            //    //Lấy danh sách quyền Menu                
            //    //userInfoModel.ListMenu = qt.GetMenuByNhanvien(user.Data.ID).Data;
            //    if (userInfoModel.ROLE == Constants.Role.SuperAdmin)
            //    {
            //        userInfoModel.ListMenu = qt.GetAllMenu().Data;
            //    }
            //    else
            //    {
            //        userInfoModel.ListMenu = qt.GetMenuByNhanvien(user.Data.ID).Data;
            //    }
            //    //Lấy các quyền nghiệp vụ (tương tự)   
            //    userInfoModel.HeThongId = 1;
            //    //Gán vào CommonLib.UserInfo <-> MySession.UserInfo.
            SessionInfo.UserInfo = userInfoModel;
            if (!string.IsNullOrEmpty(model.RedirectUrl))
            {
                return Redirect(model.RedirectUrl);
            }
            return Redirect(Constants.ServerUrl);

        }    
    }
}