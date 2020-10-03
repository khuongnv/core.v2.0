using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core.WebAplication.Controllers
{
    
    public class BaseController : Controller
    {
        public BaseController()
        {
        }
        #region Helpers

        protected ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        #endregion Helpers
        protected string ReturnErrorMsgs(ModelStateDictionary m)
        {
            string msgErr = "";
            if (m.IsValid) return msgErr;
            try
            {
                int dem = 1;
                //Mặc định là convert to HTML, sau này nếu thêm thì bổ sung biến sau.
                msgErr = "Dữ liệu không tồn tại:<br/> ";
                var lstInvalid = ModelState.Values.Where(o => o.Errors.Count > 0);
                foreach (var err in lstInvalid)
                {
                    foreach (var errMsg in err.Errors)
                    {
                        msgErr += dem + @". " + errMsg.ErrorMessage + @";<br/>";
                        dem++;
                    }
                }
            }
            catch (Exception)
            {
                msgErr = "Dữ liệu không tồn tại."; ;
            }
            return msgErr;
        }
    }
    
}
