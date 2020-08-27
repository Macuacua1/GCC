using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCC.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return RedirectToAction("GenericError", new HandleErrorInfo(new HttpException(403, "Dont allow access the error pages"), "ErrorController", "Index"));
        }
        public ViewResult General(HandleErrorInfo exception)
        {
            return View("Error", exception);
        }

        public ViewResult HttpError404(HandleErrorInfo exception)
        {
            ViewBag.Title = "Página não Encontrada";
            return View("Error", exception);
        }
        public ViewResult HttpError500(HandleErrorInfo exception)
        {
            ViewBag.Title = "Erro Interno";
            return View("Error", exception);
        }
    }
}