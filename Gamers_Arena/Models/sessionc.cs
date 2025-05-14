using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gamers_Arena.Models
{

    class CheckSession : ActionFilterAttribute
    {


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;

            if (session["admin"] != null)
            {

                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
            {

                {"Controller","Home"},
                {"Action","adminlogin" }


            });

            }



        }
    }
}