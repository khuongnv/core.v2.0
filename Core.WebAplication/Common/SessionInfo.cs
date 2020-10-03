using Core.Models;
using System.Web;
namespace Core.WebAplication.Common
{
    public class SessionInfo
    {
        public static UserInfoModel UserInfo
        {
            get { return (UserInfoModel)HttpContext.Current.Session[Constants.SessionKeys.UserInfo]; }
            set { HttpContext.Current.Session[Constants.SessionKeys.UserInfo] = value; }
        }
    }
}
