using GCC.Class;
using GCC.Common;
using GCC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GCC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //GlobalFilters.Filters.Add(new AuthorizeAttribute());
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            log4net.Config.XmlConfigurator.Configure();
        }
        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    var httpContext = ((MvcApplication)sender).Context;
        //    var currentController = " ";
        //    var currentAction = " ";
        //    var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));

        //    if (currentRouteData != null)
        //    {
        //        if (currentRouteData.Values["controller"] != null && !String.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
        //        {
        //            currentController = currentRouteData.Values["controller"].ToString();
        //        }

        //        if (currentRouteData.Values["action"] != null && !String.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
        //        {
        //            currentAction = currentRouteData.Values["action"].ToString();
        //        }
        //    }

        //    var ex = Server.GetLastError();
        //    //var controller = new ErrorController();
        //    var routeData = new RouteData();
        //    var action = "GenericError";

        //    if (ex is HttpException)
        //    {
        //        //LogInicializer.logger.Info(DateTime.Now + " -Global()- ", ex);
        //        var httpEx = ex as HttpException;

        //        switch (httpEx.GetHttpCode())
        //        {
        //            case 404:
        //                // page not found
        //                action = "HttpError404";
        //                break;
        //            case 500:
        //                // server error
        //                action = "HttpError500";
        //                break;
        //            default:
        //                action = "General";
        //                break;
        //        }
        //    }
        //    LogInicializer.logger.Info(DateTime.Now + " -Global()- ", ex);
        //    httpContext.ClearError();
        //    httpContext.Response.Clear();
        //    httpContext.Response.StatusCode = ex is HttpException ? ((HttpException)ex).GetHttpCode() : 500;
        //    httpContext.Response.TrySkipIisCustomErrors = true;

        //    routeData.Values["controller"] = "Error";
        //    routeData.Values["action"] = action;
        //    routeData.Values["exception"] = new HandleErrorInfo(ex, currentController, currentAction);

        //    IController errormanagerController = new ErrorController();
        //    HttpContextWrapper wrapper = new HttpContextWrapper(httpContext);
        //    var rc = new RequestContext(wrapper, routeData);
        //    errormanagerController.Execute(rc);

        //}
    }
}
