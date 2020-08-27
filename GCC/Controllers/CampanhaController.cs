using GCC.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using GCC.Managers;
using GCC.Class;

using GCC.CatalogoProduto;
using System.Collections.Generic;

namespace GCC.Controllers
{
    public class CampanhaController : Controller
    {
        // GET: Campanha
        string con = ConnectionDB.GetDBConnectionString;
        public ActionResult Index()
        {
            return View();
        }

        // GET: Campanha/Details/5
      
        public ActionResult Details(int id)
        {
            Campanha campanha = new Campanha();
            using (GCCEntities db = new GCCEntities(con))
            {
                try
                {
                    List<Product> lista = new List<Product>();
                   
                    Session["lista"] = null;
                    Session["ListaProduto"] = null;
                    //@Session["PaginaCampanha"] = pagina;
                     campanha = Campanha_Manager.GetCampanha(ID:id,con:con);
                    var listaProvincia = db.tblProvincia.Where(a => a.Estado == true).OrderBy(a => a.ID).ToList();
                    //listaProvincia.Add(new tblProvincia { ID = 0, Provincia = "Todas", Estado = true });
                    ViewBag.listaProvincia = listaProvincia;

                    var listaPrioridade = db.tblPrioridade.Where(a => a.Estado == true).OrderBy(a => a.ID).ToList();
                    ViewBag.listaPrioridade = listaPrioridade;

                    var listaRede = db.tblRede.Where(a => a.Estado == true).OrderBy(a => a.ID).ToList();
                    //listaRede.Add(new tblRede { ID = 0, Rede = "Todas", Estado = true });
                    ViewBag.listaRede = listaRede;

                    var listaRecorrencia = db.tblRecorrencia.Where(a => a.Estado == true).OrderBy(a => a.ID).ToList();
                    ViewBag.listaRecorrencia = listaRecorrencia;

                    var listaCanal = db.tblCanal.Where(a => a.Estado == true).OrderBy(a => a.ID).ToList();
                    ViewBag.listaCanal = listaCanal;

                    var listaRazaoContacto = db.tblRazaoContacto.Where(a => a.Estado == true).OrderBy(a => a.ID).ToList();
                    ViewBag.listaRazaoContacto = listaRazaoContacto;

                    lista = Campanha_Manager.GetProductRootList();
                    Session["ListaProduto"] = lista;
                    Session["CampanhaID"] = campanha.CampanhaID;
                    var listaProduto = lista.Where(a => a.ProductLevel == 0).ToList();
                    ViewBag.listaProduto = listaProduto;
                    //string.Join(",", yourListVariableHere);
                    ViewBag.provincias = string.Join(",",campanha.provincia.Select(a => a.ProvinciaID).ToList());
                    ViewBag.redes = string.Join(",", campanha.rede.Select(a => a.RedeID).ToList());
                    ViewBag.semanas = getSemanaList();



                }

                catch (Exception erro)
                {
                    LogInicializer.logger.Info(DateTime.Now + " -CampanhaController - Details)- ", erro);
                    throw erro;
                }

            }
            return View("Manutencao",campanha);
            //return PartialView("Details",campanha);
        }
        public List<Semana> getSemanaList()
        {
            List<Semana> lista = new List<Semana>();
            lista.Add(new Semana { Value=1,Text="Domingo"});
            lista.Add(new Semana { Value = 2, Text = "Segunda" });
            lista.Add(new Semana { Value = 3, Text = "Terça" });
            lista.Add(new Semana { Value = 4, Text = "Quarta" });
            lista.Add(new Semana { Value = 5, Text = "Quinta" });
            lista.Add(new Semana { Value = 6, Text = "Sexta" });
            lista.Add(new Semana { Value = 7, Text = "Sábado" });

            return lista;
        }
        // GET: Campanha/Create
        public ActionResult Create()
        {
            using (GCCEntities db = new GCCEntities(con))
            {
                try
                {
                    List<Product> lista = new List<Product>();
                    Session["lista"] = null;
                    Session["ListaProduto"] = null;
                    
                    var listaProvincia = db.tblProvincia.Where(a => a.Estado == true).OrderBy(a => a.ID).ToList();
                   
                    ViewBag.listaProvincia = listaProvincia;

                    var listaPrioridade = db.tblPrioridade.Where(a => a.Estado == true).OrderBy(a => a.ID).ToList();
                    ViewBag.listaPrioridade = listaPrioridade;

                    var listaRede = db.tblRede.Where(a => a.Estado == true).OrderBy(a => a.ID).ToList();
                   
                    ViewBag.listaRede = listaRede;

                    var listaRecorrencia = db.tblRecorrencia.Where(a => a.Estado == true).OrderBy(a => a.ID).ToList();
                    ViewBag.listaRecorrencia = listaRecorrencia;

                    var listaCanal = db.tblCanal.Where(a => a.Estado == true).OrderBy(a => a.ID).ToList();
                    ViewBag.listaCanal = listaCanal;

                    var listaRazaoContacto = db.tblRazaoContacto.Where(a => a.Estado == true).OrderBy(a => a.ID).ToList();
                    ViewBag.listaRazaoContacto = listaRazaoContacto;

                    lista = Campanha_Manager.GetProductRootList();
                    Session["ListaProduto"] = lista;
                    var listaProduto= lista.Where(a => a.ProductLevel == 0).ToList();
                    ViewBag.listaProduto = listaProduto;
                    ViewBag.listaCampanha = Campanha_Manager.GetCampanhaList(con); ;

                }

                catch (Exception erro)
                {
                    LogInicializer.logger.Info(DateTime.Now + " -CampanhaController - Create)- ", erro);
                    throw erro;
                }
                
            }
            return View();
        }
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [HttpPost]
        public JsonResult SetProdutoStatus(int pagina, int estado,int ID)
        {
            bool result = false;
            string mensagem = "";
            string customMsg = "";
            try
            {
                if ((estado == 0 || estado == 1) && ID > 0 )
                {
                    result = Campanha_Manager.UpdateProdutoStatus(estado: estado,ID: ID,con: con);
                    customMsg = estado == 1 ? "Produto Activado com Sucesso!" : "Produto Desactivado com Sucesso!";
                    mensagem = result == false ? "" : customMsg;
                }

                return Json(new { status = result, msg = mensagem }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -CampanhaController- SetProdutoStatus(ID=" + ID + "))- ", erro);
                throw erro;
            }
        }
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [HttpPost]
        public JsonResult SetCampanhaStatus(int pagina, int estado, int campanhaID)
        {
            bool result = false;
            string mensagem = "";
            string customMsg = "";
            try
            {
                if ((estado==0 || estado ==1) && campanhaID >0)
                {
                    result = Campanha_Manager.UpdateCampanhaStatus(estado: estado ,campanhaID: campanhaID ,con:con);
                    customMsg = estado == 1 ? "Campanha activada com Sucesso!" : "Campanha desactivada com Sucesso!";
                    mensagem = result == false ? "" : customMsg;
                }

                return Json(new { status = result, msg = mensagem }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -CampanhaController - SetCampanhaStatus(campanhaID=" + campanhaID + "))- ", erro);
                throw erro;
            }

        }
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [HttpPost]
        public JsonResult RemoveProduct(int ID)
        {
            bool result = false;
            string mensagem = "";
            try
            {
                if (ID > 0)
                {
                    result = Campanha_Manager.DeleteProdutoCampanha(ID: ID, con: con);
                    mensagem = result == false ? "" : "Removido com Sucesso!";
                }

                return Json(new { status = result, msg = mensagem }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -CampanhaController - RemoveProduct(ID=" + ID + "))- ", erro);
                throw erro;
            }

        }

        public JsonResult Manutencao(Campanha campanha)
        {
            try
            {
                bool status = false;
                Int32 resultado = 0;
                string mensagem = "";
             
                if (campanha != null)
                {
                   resultado = Campanha_Manager.UpdateCampanha(campanha, con, Session["UserID"].ToString());
                       

                        if (resultado > 0)
                        {
                            status = true;
                            Session["CampanhaID"] = resultado;
                            mensagem = "Actualizado com Sucesso!";
                        }
                
                    
                }

                return Json(new { status = status, IDcampanha = campanha.CampanhaID, msg = mensagem }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -CampanhaController - Manutencao(campanhaID=" + campanha.CampanhaID + "))- ", erro);
                throw erro;
            }
        }
        // POST: Campanha/Create
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Create(Campanha campanha)
        {
            
            try
            {
                bool status = false;
                Int32 resultado = 0;
                string mensagem = "";
                tblCampanha camp = new tblCampanha();
                if (campanha != null)
                {
                    camp = Campanha_Manager.GetCampanha(campanha.CodCampanha,con);

                    if (camp == null)
                    {
                       
                            resultado = Campanha_Manager.SaveCampanha(campanha, con, Session["UserID"].ToString());
                     
                    if (resultado > 0)
                    {
                            status = true;
                            Session["CampanhaID"] = resultado;
                            mensagem = "Registado com Sucesso,Adicione os Produtos da Campanha!";
                        }
                    }
                    else
                    {
                        mensagem = "Existe um registo com este Codigo!";
                    }
                }

                return Json(new { status = status, IDcampanha = resultado,msg = mensagem }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -CampanhaController - Create(campanhaID=" + campanha.CampanhaID + "))- ", erro);
                throw erro;
            }
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult CreateProduto(Models.Produto produto)
        {
            int ProdutoID = 0;
            Product prod = new Product();
            tblAssunto product = new tblAssunto();
            try
            {
                bool status = false;
                Int32 resultado = 0;
               string mensagem = "";
                if (produto != null)
                {
                    ProdutoID = produto.ProdutoNivel3 > 0 ? produto.ProdutoNivel3 : (produto.ProdutoNivel2 > 0 ? produto.ProdutoNivel2 : (produto.ProdutoNivel1 > 0 ? produto.ProdutoNivel1 : (produto.ProdutoRaiz > 0 ? produto.ProdutoRaiz : ProdutoID)));
                    int CampanhaID= int.Parse(Session["CampanhaID"].ToString());
                    product = Campanha_Manager.GetProduto(CampanhaID,ProdutoID,con);
                    if (product == null )
                    { 
                    prod = getProduct(ProdutoID);
                    produto.CodProduto = prod.ProductCod.ToString().Trim();
                    produto.ProdutoID = ProdutoID;
                    produto.Nome = prod.ProductName.ToString().Trim();
                    produto.CampanhaID = CampanhaID;
                    resultado = Campanha_Manager.SaveProduto(produto, con, Session["UserID"].ToString());

                        if (resultado > 0)
                        {
                            status = true;
                            mensagem = "Produto/Serviço adicionado com Sucesso!";
                        }
                        else
                        {
                            mensagem = "Ocorreu um erro no Registo!";
                        }
                    }
                    else
                    {
                        mensagem = "Existe um registo para este Produto/Serviço nesta Campanha!";
                    }
                }

                return Json(new { status = status, IDcampanha = produto.CampanhaID,msg = mensagem }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -CampanhaController - CreateProduto(CampanhaID=" + produto.CampanhaID + "))- ", erro);
                throw erro;
            }
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [HttpPost]
        public JsonResult GetCampanhas(int pagina)
        {
            bool status = false;
            List<VW_Campanha> list = new List<VW_Campanha>();
            List<VW_Campanha> lista = new List<VW_Campanha>();
            Pagination page = new Pagination();
            try
            {
                list = Campanha_Manager.GetCampanhaList(con);
                status = list.Count > 0 ? true : false;
                page.PageIndex = pagina;
                page.PageSize = 5;
                page.RecordCount = list.Count;
                int startIndex = (pagina - 1) * page.PageSize;
                lista = list
                                .OrderBy(a => a.ID)
                                .Skip(startIndex)
                                .Take(page.PageSize).ToList();
            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -CampanhaController - GetCampanhas)- ", erro);
                throw erro;
            }
            //return new JsonResult { Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return Json(new { status = status, data = list, pagina = page }, JsonRequestBehavior.AllowGet);


        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [HttpPost]
        public JsonResult BuscaProdutoCampanha(int campanhaID, int pagina)
        {
            bool status = false;
            List<vw_Assunto> list = new List<vw_Assunto>();
            List<vw_Assunto> lista = new List<vw_Assunto>();
            Pagination page = new Pagination();
            try
            {
                list = Campanha_Manager.GetcampanhaProductList(campanhaID,con);
                status = list.Count > 0 ? true : false;
                page.PageIndex = pagina;
                page.PageSize = 5;
                page.RecordCount = list.Count;
                int startIndex = (pagina - 1) * page.PageSize;
                lista = list
                                .OrderBy(a => a.ID)
                                .Skip(startIndex)
                                .Take(page.PageSize).ToList();
            }
            catch(Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -CampanhaController - BuscaProdutoCampanha(CampanhaID=" + campanhaID + "))- ", erro);
                throw erro;
            }
            //return new JsonResult { Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return Json(new { status = status, data = lista ,pagina= page}, JsonRequestBehavior.AllowGet);


        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [HttpPost]
        public JsonResult GetProductRootList()
        {
            
           
            WSCatalogoProdutosClient catalogo = new WSCatalogoProdutosClient();

           List<Product> lista = new List<Product>();
            List<Product> rootList = new List<Product>();
            bool status = false;
            try
            {
                

                lista = catalogo.GetAllProductList();
                Session["ListaProduto"] = lista;
                rootList = lista.Where(a=>a.ProductLevel==0).ToList();
                status = true;
              
            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -CampanhaController - GetProductRootList)- ", erro);
                throw erro;
            }

           //return new JsonResult { Data = rootList, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return Json(new { status = status, data = rootList }, JsonRequestBehavior.AllowGet);

        }
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [HttpPost]
        public JsonResult GetProductByParentID(string pid)
        {

            List<Product> lista = new List<Product>();
            List<Product> rootList = new List<Product>();
            bool status = false;
           
            try
            {
                lista = (List<Product>)Session["ListaProduto"];
                if (lista !=null)
                {
                    rootList = lista.Where(a => a.ParentProductID == Int32.Parse(pid)).ToList();
                    status = true;
                }
                else { }
                

            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -CampanhaController - GetProductByParentID(pid=" + pid + "))- ", erro);
                throw erro;
            }
            //return new JsonResult { Data = rootList, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return Json(new { status = status, data = rootList }, JsonRequestBehavior.AllowGet);

        }

        public Product getProduct(int ProductID)
        {
            List<Product> lista = new List<Product>();
            Product prod = new Product();
            try
            {
                lista = (List<Product>)Session["ListaProduto"];
                if (lista != null)
                {
                    prod = lista.SingleOrDefault(a => a.ProductID == ProductID);
                    
                }
                else { }
                return prod;

            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -CampanhaController - getProduct(ProductID=" + ProductID + "))- ", erro);
                throw erro;
            }

        }
       
    }
}
