using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Core
{
    public class MyController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies == null)
            {
                filterContext.Result = new RedirectResult("~/Auth/LoginPage");
                return;
            }
            
            base.OnActionExecuting(filterContext);
        }
    }
}