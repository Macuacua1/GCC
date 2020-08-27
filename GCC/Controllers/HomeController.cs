using GCC.ActiveDirectoryGroupUsers;
using GCC.Class;
using GCC.Managers;
using GCC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GCC.Controllers
{
    public class HomeController : Controller
    {
        string con = ConnectionDB.GetDBConnectionString;
        // GET: Home
        [AllowAnonymous]
        public ActionResult Index()
        {
            var UserID = string.Empty;
            var UserIDd = Session["UserID"];
            //return View(lista);
            if (Session["UserID"] != null && User.Identity.IsAuthenticated)
            {
                getUserPermissions();
                //return View(lista);
            }
            else

            {
                if (GetQueryStringUserInfo().userId == null)
                {
                    string AppName = ConfigurationManager.AppSettings["AppName"];
                    string ReturnURL = new Helper().getURL(AppName);
                    FormsAuthentication.SignOut();
                    return Redirect("http://" + ReturnURL + "?Info=1");
                }
                else
                {
                    Session["Perfil"] = Request.QueryString["Perfil"];
                    Session["UserID"] = Request.QueryString["UserID"];
                    Session["UserName"] = Request.QueryString["UserName"];


                    FormsAuthentication.SetAuthCookie(Session["UserID"].ToString(), false);
                    Users DadosUtilizadores = Session["UserID"].ToString().GetUserActiveDirectory();

                    string cc = DadosUtilizadores.UnidadeOrganica.Substring(0, 5);

                    Session["CentroCusto"] = cc;
                    Session["XnucName"] = DadosUtilizadores.XnucName;
                    Session["UnidadeOrganicaDescricao"] = DadosUtilizadores.UnidadeOrganicaDescricao;
                    Session["UnidadeOrganica"] = DadosUtilizadores.UnidadeOrganica;
                    Session["EmailAddress"] = DadosUtilizadores.EmailAddress;


                    UserImage();
                    getUserPermissions();


                    //return View(lista);
                }
            }
            return View();
        }

        public JsonResult checkSession()
        {
            sessionClass s = new sessionClass();
            if (Session["UserID"] != null)
            {
                s.sessionValue = true;
            }
            else
            {
                s.sessionValue = false;

            }
            return Json(s, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Parametrizacao()
        {
            
            return View();
        }

        public void UserImage()
        {
            // string NUMUnico = new Home_Manager().getNUMUNICO("x140213");

            string NUMUnico = new Helper().getNUMUNICO(Session["UserID"].ToString());
            //string NUMUnico = "1817973";

            try
            {
                using (var client = new WebClient())
                {

                    string url = "http://xlti.bcpcorp.net/foto/" + NUMUnico + ".jpg";
                    // fine, no content downloaded
                    string s1 = client.DownloadString(url);
                    Session["UserImage"] = url;
                }
            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -HomeController - UserImage)- ", erro);
                Session["UserImage"] = null;
                throw erro;
            }
        }
        private void getUserPermissions()
        {
            try
            {
                List<string> roles = new List<string>();
                var x = new Permissoes.Service1SoapClient();

                UserPermission up = new UserPermission()
                {
                    //ACESSO = x.wsValUsr(Session["UserID"].ToString(), "GCC_ACESSO")
                    GCC_CONSULTA = x.wsValUsr(Session["UserID"].ToString(), "GCC_CONSULTA"),
                    GCC_REGISTO_CAMPANHA = x.wsValUsr(Session["UserID"].ToString(), "GCC_REGISTO_CAMPANHA"),

                };

                //if (up.ACESSO) roles.Add("ACESSO");
                if (up.GCC_CONSULTA) roles.Add("GCC_CONSULTA");
                if (up.GCC_REGISTO_CAMPANHA) roles.Add("GCC_REGISTO_CAMPANHA");


                Session["UserPermission"] = up;
                Session["UserRoles"] = roles;
            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -HomeController - getUserPermissions)- ", erro);
                throw erro;
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["UserID"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult ClearCache()
        {
            LogInicializer.ClearCache1();
            return RedirectToAction("Index", "Home");
        }
        private UserVM GetQueryStringUserInfo()
        {
            UserVM userVM = new UserVM(); ;
            if (!(Request.ServerVariables["QUERY_STRING"] == ""))
            {
                string QryString = Request.ServerVariables["QUERY_STRING"];
                string[] QryStringArr = QryString.Split('&');
                string[] QryStringItemArr;

                if (QryStringArr.Length > 0)
                {
                    foreach (var item in QryStringArr)
                    {
                        QryStringItemArr = item.Split('=');

                        if (QryStringItemArr.Length >= 1)
                        {
                            if (QryStringItemArr[0].ToUpper() == "PERFIL")
                            {
                                userVM.userRole = QryStringItemArr[1];
                            }
                            else if (QryStringItemArr[0].ToUpper() == "USERID")
                            {
                                userVM.userId = QryStringItemArr[1];
                            }
                        }
                    }
                }
            }

            return userVM;
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [HttpPost]
        public JsonResult UpdateParametrizacao(int estado,int ID,string Tipo)
        {
            bool status = false;
            string mensagem = "";
            try
            {
                if ((estado ==0 || estado==1) && ID >0 && (Tipo !="" || Tipo !=null))
                {
                    switch (Tipo)
                    {
                        case "Razao":
                            status = Home_Manager.ActualizaRazao(status:estado,ID:ID,con:con);
                            mensagem = estado == 1 ? "Activada com Sucesso!" : "Desctivada com Sucesso!";
                            break;

                        case "Prioridade":
                            status = Home_Manager.ActualizaPrioridade(status: estado, ID: ID, con: con);
                            mensagem = estado == 1 ? "Activada com Sucesso!" : "Desctivada com Sucesso!";
                            break;
                        case "Canal":
                            status = Home_Manager.ActualizaCanal(status: estado, ID: ID, con: con);
                            mensagem = estado == 1 ? "Activado com Sucesso!" : "Desctivado com Sucesso!";
                            break;
                        case "Rede":
                            status = Home_Manager.ActualizaRede(status: estado, ID: ID, con: con);
                            mensagem = estado == 1 ? "Activada com Sucesso!" : "Desctivada com Sucesso!";
                            break;
                    }
                }
            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -HomeController - UpdateParametrizacao(ID=" + ID + "))- ", erro);
                throw erro;
            }

            return Json(new { status = status, msg = mensagem}, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [HttpPost]
        public JsonResult CreateParametrizacao(string texto,string Tipo,int ID)
        {
            bool status = false;
            string mensagem = "";
           
            try
            {
                using (GCCEntities db=new GCCEntities(con))
                {
                   
                    if ((texto != "" || texto != null) && (Tipo != "" || Tipo != null))
                    {
                       
                       status = Home_Manager.CreateParamtrizacao(ref mensagem, texto: texto, Tipo: Tipo, UserID: Session["UserID"].ToString(), con: con,ID:ID);

                    }else { mensagem = "Preencha o Campo!"; }
                }
                    
            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -HomeController - CreateParametrizacao(ID=" + ID + "))- ", erro);
                throw erro;
            }

            return Json(new { status = status, msg = mensagem }, JsonRequestBehavior.AllowGet);
        }
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [HttpPost]
        public JsonResult GetRazaoContacto(int pagina)
        {
            bool status = false;
           List<tblRazaoContacto> lista = new List<tblRazaoContacto>();
            Pagination page = new Pagination();
            try
            {
               var list = Home_Manager.GetRazaoList(con);
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
                LogInicializer.logger.Info(DateTime.Now + " -HomeController - GetRazaoContacto)- ", erro);
                throw erro;
            }
            
            return Json(new { status = status, data = lista, pagina = page }, JsonRequestBehavior.AllowGet);
        }
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [HttpPost]
        public JsonResult GetPrioridade(int pagina)
        {
            bool status = false;
            List<tblPrioridade> lista = new List<tblPrioridade>();
            Pagination page = new Pagination();
            try
            {
                var list = Home_Manager.GetPrioridadeList(con);
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
                LogInicializer.logger.Info(DateTime.Now + " -HomeController - GetPrioridade)- ", erro);
                throw erro;
            }

            return Json(new { status = status, data = lista, pagina = page }, JsonRequestBehavior.AllowGet);
        }
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [HttpPost]
        public JsonResult GetCanal(int pagina)
        {
            bool status = false;
            List<tblCanal> lista = new List<tblCanal>();
            Pagination page = new Pagination();
            try
            {
                var list = Home_Manager.GetCanalList(con);
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
                LogInicializer.logger.Info(DateTime.Now + " -HomeController - GetCanal)- ", erro);
                throw erro;
            }

            return Json(new { status = status, data = lista, pagina = page }, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [HttpPost]
        public JsonResult GetRede(int pagina)
        {
            bool status = false;
            List<tblRede> lista = new List<tblRede>();
            Pagination page = new Pagination();
            try
            {
                var list = Home_Manager.GetRedeList(con);
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
                LogInicializer.logger.Info(DateTime.Now + " -HomeController - GetRede)- ", erro);
                throw erro;
            }

            return Json(new { status = status, data = lista, pagina = page }, JsonRequestBehavior.AllowGet);
        }
        public FileResult DownloadUserManual()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath("~/Documents/Manual/Manual_do_Utilizador_GCC.docx"));
            string fileName = "Manual de Utilizador do Gestor de Campanhas.doc";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

    }
}
