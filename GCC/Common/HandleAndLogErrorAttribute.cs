using GCC.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GCC.Common
{
    public class HandleAndLogErrorAttribute : HandleErrorAttribute
    {
       
        public override void OnException(ExceptionContext filterContext)
        {

            LogInicializer.logger.Info(DateTime.Now + " -"+ filterContext.Controller+ "-"+ (string)filterContext.RouteData.Values["action"] + ")- ", filterContext.Exception);

            if (filterContext.HttpContext.Request.IsAjaxRequest() && filterContext.Exception != null)
            {
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        filterContext.Exception.Message,
                        filterContext.Exception.StackTrace
                    }
                };
                //filterContext.ExceptionHandled = true;

                UpdateFilterContext(filterContext);
            }
            else
            {
                base.OnException(filterContext);
            }
        }
       

        private static void UpdateFilterContext(ExceptionContext filterContext, int statusCode = (int)HttpStatusCode.InternalServerError)
        {
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = statusCode;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}