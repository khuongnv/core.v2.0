using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Core.Models;
using Core.Models.Input;
using Core.Models.Output;
using Core.Models.Entities;
using Core.Business;
using Newtonsoft.Json;
using AutoMapper;
using Core.WebAplication.Common;
namespace Core.WebAplication.Controllers
{    
    public class LogController : BaseController
    {
		private readonly LogBusiness _logBusiness = new LogBusiness();
        [KiemTraQuyen(Action = new long[] { Constants.Menu.QUAN_TRI_LOG_USER })]
        [HttpGet]
        public ActionResult LogDangNhap()
        {
            return View("../HeThong/QuanTri/LogDangNhap/Index");
        }
        [KiemTraQuyen(Action = new long[] { Constants.Menu.QUAN_TRI_LOG_USER })]
        [HttpPost]
        public ActionResult LogUserDangNhap()
        {
            try
            {
                var searchResult = _logBusiness.LogUserDangNhap();
                return PartialView("../HeThong/QuanTri/LogDangNhap/_TableTongHop", searchResult);
            }
            catch (Exception e)
            {
                return Json(new { msg = e.Message });
            }

        }
        [KiemTraQuyen(Action = new long[] { Constants.Menu.QUAN_TRI_LOG_THAO_TAC })]
        [HttpGet]
        public ActionResult LogThaoTac()
        {
            return View("../HeThong/QuanTri/LogThaoTac/Index");
        }
        [KiemTraQuyen(Action = new long[] { Constants.Menu.QUAN_TRI_LOG_THAO_TAC })]
        [HttpPost]
        public ActionResult LogUserThaoTac()
        {
            try
            {
                var searchResult = _logBusiness.LogUserThaoTac();
                return PartialView("../HeThong/QuanTri/LogThaoTac/_TableTongHop", searchResult);
            }
            catch (Exception e)
            {
                return Json(new { msg = e.Message });
            }

        }
    }
}

