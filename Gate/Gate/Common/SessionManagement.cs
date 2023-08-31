using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPT_UniGate.Common
{
    public class CommonConstants
    {
        public static string USER_SESSION = "USER_SESSION";
    }

    [Serializable]
    public class UserLogin
    {
        public string UserName { get; set; }
    }

    public class SessionTimeoutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext httpContext = HttpContext.Current;
            if (HttpContext.Current.Session[CommonConstants.USER_SESSION] == null)
            {
                HttpContext.Current.Session["Alert"] = "Session Timeout";
                var url = filterContext.HttpContext.Request.RawUrl;
                filterContext.Controller.TempData["url"] = url;
                filterContext.Result = new RedirectResult("~/Home/Login");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}