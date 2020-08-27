using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCC.Class
{
    public class LogInicializer
    {

        public static readonly log4net.ILog logger = log4net.LogManager.GetLogger("MBim.Log4Net");

        public static void ClearCache1()
        {
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        }
        public static void ClearCache()
        {
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetExpires(DateTime.Now);
            HttpContext.Current.Response.Cache.SetNoServerCaching();
            HttpContext.Current.Response.Cache.SetNoStore();
        }
    }
}