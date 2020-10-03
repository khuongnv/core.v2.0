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
    [KiemTraQuyen(Action = new long[] { Constants.Menu.QUAN_TRI_MENU })]
    public class QtMenuController : BaseController
    {
		private readonly MenuBusiness _menuBusiness = new MenuBusiness();		
        [HttpGet]        
        public ActionResult Index()
        {
            QtMenuModel model = new QtMenuModel
            {
                ListMenuParent = _menuBusiness.GetAllMenu().Data,                
            };
            return View("../HeThong/QuanTri/Menu/Index", model);
        }      
        
        private QtMenuModel InitQtMenuModel(int? id)
        {
            QtMenuModel model;
            if (id >= 0)
            {
                ViewBag.Mode = Constants.Mode.Edit;
                var result = _menuBusiness.GetAllMenuById(id.Value);
                
                Mapper.Initialize(cfg => {
                    cfg.CreateMap<DM_MENU, QtMenuModel>();
                });
                model = Mapper.Map<QtMenuModel>(result.Data);                
            }
            else
            {
                model = new QtMenuModel { ID = -1};
                ViewBag.Mode = Common.Constants.Mode.Add;
            }
            model.ListMenuParent = _menuBusiness.GetAllMenu().Data;
            return model;
        }
        [HttpGet]        
        public ActionResult AddOrEdit(int? id)
        {                     
            return PartialView("../HeThong/QuanTri/Menu/_AddOrEditPartial", InitQtMenuModel(id));            
        }
        [HttpPost]
        public JsonResult AddOrEdit(QtMenuModel model)
        {
            ResultModel<bool> result = new ResultModel<bool>();
            if (ModelState.IsValid)
            {               
                try
                {
                    var obj = _menuBusiness.GetAllMenuById(model.ID);
                    Mapper.Initialize(cfg => {
                        cfg.CreateMap<DM_MENU, QtMenuModel>();
                    });
                    
                    var objMenu = Mapper.Map<DM_MENU>(model);
                    result = _menuBusiness.InsertOrUpdateMenu(objMenu);
                    return Json("OK", JsonRequestBehavior.AllowGet);
                    //if (obj.Data != null)
                    //{
                    //    result = _menuBusiness.InsertOrUpdateMenu(model);                        
                    //    return Json(result.Message, JsonRequestBehavior.AllowGet);
                    //}                    
                    
                }
                catch (Exception ex)
                {
                    result.Message = "Lỗi: " + ex.GetBaseException().Message;
                    ModelState.AddModelError("ID", result.Message);
                }
            }
            else
            {
                result.Message = ReturnErrorMsgs(ModelState);
                ModelState.AddModelError("ID", result.Message);
            }

            return Json(result.Message, JsonRequestBehavior.AllowGet); 
        }
		
        [HttpPost]        
        public JsonResult Delete(string listId)
        {
            ResultModel<bool> result = new ResultModel<bool>();
            string deleted = string.Empty;
            string notDeleted = string.Empty;
            string[] arrayId = listId.Split('_');
            for (int i = 0; i < arrayId.Length; i++)
            {
                try
                {
                    var resultDel = _menuBusiness.DeleteMenuById(long.Parse(arrayId[i]));
                    if (resultDel.IsError == false)
                    {
                        deleted = deleted + arrayId[i] + ",";
                    }
                    else
                    {
                        notDeleted = notDeleted + arrayId[i] + ",";
                    }
                }
                catch
                {
                    notDeleted = notDeleted + arrayId[i] + ",";
                }
               
            }            
            if (deleted.Length > 0)
            {
                result.Message = "Đã xóa Ids :" + deleted;
            }
            if (notDeleted.Length > 0)
            {
                result.Message = result + "/n Lỗi xóa Ids :" + notDeleted;
            }
            return Json(result.Message, JsonRequestBehavior.AllowGet);           
        }

		[HttpPost]     
        public ActionResult Search(QtMenuModel model)
        {
            try
            {
                if (model == null)
                    model = new QtMenuModel();
                var searchModel = new SearchModel<QtMenuModel>
                {
                    Cretia = model,
                    ColumnOrder = "",
                    DirectionOrder = 1,
                    PageIndex = 1,
                    PageSize = 10000
                };

                var searchResult = _menuBusiness.Search(searchModel);
                return PartialView("../HeThong/QuanTri/Menu/_TableTongHop", searchResult);
            }
            catch (Exception e)
            {
                return Json(new { msg = e.Message });
            }

        }
    }
}

