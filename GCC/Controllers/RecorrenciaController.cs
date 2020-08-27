using GCC.Class;
using GCC.Managers;
using GCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCC.Controllers
{
    public class RecorrenciaController : Controller
    {
        // GET: Recorrencia
        string con = ConnectionDB.GetDBConnectionString;
        public ActionResult Index()
        {
            using (GCCEntities db = new GCCEntities(con))
            {
                try
                {
                    var listaRecorrencia = db.tblRecorrencia.Where(a => a.Estado == true).OrderBy(a => a.ID).ToList();
                    ViewBag.listaRecorrencia = listaRecorrencia;
                }

                catch (Exception erro)
                {
                    LogInicializer.logger.Info(DateTime.Now + " -RecorrenciaController - Index)- ", erro);
                    throw erro;
                }
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            vw_Log_Recorrencia recorencia = new vw_Log_Recorrencia();
            using (GCCEntities db = new GCCEntities(con))
            {
                try
                {
                    recorencia = db.vw_Log_Recorrencia.SingleOrDefault(a=>a.ID==id);
                }

                catch (Exception erro)
                {
                    LogInicializer.logger.Info(DateTime.Now + " -RecorrenciaController - Details)- ", erro);
                    throw erro;
                }

            }
            //return View();
            return PartialView(recorencia);
        }
        public ActionResult RecorrenciaPorExecutar()
        {
            var lista = Recorrencia_Manager.GetRecorrenciaPorExecutar(con:con);
            return View("PorExecutar", lista);
        }
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [HttpPost]
        public JsonResult GetRecorrenciaChart(int Periodo, int Recorrencia = 100)
        {
            bool status = false;
            string mensagem = "";
            List<RecorrenciaChart> list = new List<RecorrenciaChart>();
            try
            {
                list = Recorrencia_Manager.GetCampanhaListChart(con, Periodo: Periodo, Recorrencia: Recorrencia);
                status = true;
                //status = list.Count > 0 ? true : false;
                
            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -RecorrenciaController - GetRecorrenciaChart)- ", erro);
                throw erro;
            }
            //return new JsonResult { Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return Json(new { status = status, data = list,msg=mensagem }, JsonRequestBehavior.AllowGet);

        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [HttpPost]
        public JsonResult GetRecorrencias(int pagina,int Periodo,int Recorrencia=100, int? Estado = 100)
        {
            bool status = false;
            List<vw_Log_Recorrencia> list = new List<vw_Log_Recorrencia>();
            List<vw_Log_Recorrencia> lista = new List<vw_Log_Recorrencia>();
            Pagination page = new Pagination();
            try
            {
                list = Recorrencia_Manager.GetCampanhaList(con, Periodo: Periodo, Recorrencia: Recorrencia, Estado: Estado);
                status = list.Count > 0 ? true : false;
                page.PageIndex = pagina;
                page.PageSize = 5;
                page.RecordCount = list.Count;
                int startIndex = (pagina - 1) * page.PageSize;
                lista = list
                                .OrderByDescending(a => a.ID)
                                .Skip(startIndex)
                                .Take(page.PageSize).ToList();
            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -RecorrenciaController - GetRecorrencia)- ", erro);
                throw erro;
            }
            //return new JsonResult { Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return Json(new { status = status, data = lista, pagina = page }, JsonRequestBehavior.AllowGet);


        }
    }
}