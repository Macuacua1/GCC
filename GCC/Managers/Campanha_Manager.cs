using GCC.CatalogoProduto;
using GCC.Class;
using GCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCC.Managers
{
    public class Campanha_Manager
    {
       //public static List<int> province = new List<int>();
       // public static List<int> redes = new List<int>();
        public static int SaveCampanha(Campanha campanha,string con,string UserID)
        {
            Int32 Result = 0;
            tblCampanha campan = new tblCampanha();
           
            try
            {
                using (GCCEntities db =new GCCEntities(con))
                {
                     //Save Campanha 
                    campan.CanalID = campanha.CanalID;
                    campan.CodCampanha = campanha.CodCampanha;
                    campan.DataInicio = campanha.DataInicio;
                    campan.DataFim = campanha.DataFim;
                    campan.MaxAlvosBalcao = campanha.MaxAlvosBalcao;
                    campan.MaxAlvosGestor = campanha.MaxAlvosGestor;
                    campan.NomeCampanha = campanha.NomeCampanha;
                    campan.PrioridadeID = campanha.PrioridadeID;
                    campan.RazaoContactoID = campanha.RazaoContactoID;
                    campan.RecorrenciaID = campanha.RecorrenciaID;
                    if (campanha.RecorrenciaID==3)
                    campan.DataRecorrMensal = campanha.DataRecorrMensal;
                    if (campanha.RecorrenciaID == 2)
                        campan.DataRecorrSemanal = campanha.DataRecorrSemanal;
                    campan.Estado = true;
                    campan.UserRegisto = UserID;
                    campan.DataRegisto = DateTime.Now;
                    db.AddTotblCampanha(campan);
                    db.SaveChanges();
                    Result = campan.ID;

                    //Save CampanhaProvince 
                    if (campanha.provincia != null)
                    {
                        foreach (Provincia item in campanha.provincia)
                        {
                            if (item.ProvinciaID > 0 && item.NomeProvincia != null && item.NomeProvincia != "")
                            {

                                tblCampanha_Por_Provincia campProv = new tblCampanha_Por_Provincia();
                                campProv.ProvinciaID = item.ProvinciaID;
                                campProv.Provincia = item.NomeProvincia.ToString();
                                campProv.CampanhaID = campan.ID;
                                campProv.UserRegisto = UserID;
                                campProv.Estado = true;
                                campProv.DataRegisto = DateTime.Now;
                                db.AddTotblCampanha_Por_Provincia(campProv);
                                db.SaveChanges();
                            }
                          
                        }

                        
                    }

                    //Save CampanhaRede
                    if (campanha.rede != null)
                    {
                        foreach (Rede item in campanha.rede)
                        {
                            if (item.RedeID > 0 && item.NomeRede != null && item.NomeRede != "")
                            {

                                Rede_da_Campanha rede = new Rede_da_Campanha();
                                rede.RedeID = item.RedeID;
                                rede.Rede = item.NomeRede.ToString();
                                rede.CampanhaID = campan.ID;
                                rede.UserRegisto = UserID;
                                rede.Estado = true;
                                rede.DataRegisto = DateTime.Now;
                                db.AddToRede_da_Campanha(rede);
                                db.SaveChanges();
                            }

                        }


                    }
                }
            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Campanha_Manager - SaveCampanha(CampanhaID=" + campanha.CampanhaID + "))- ", erro);
                throw erro;
            }
            
            return Result;
        }
        public static int UpdateCampanha(Campanha campanha, string con, string UserID)
        {
            Int32 Result = 0;
            tblCampanha campan = new tblCampanha();
            List<int> province = new List<int>();
            List<int> redes = new List<int>();
            try
            {
                using (GCCEntities db = new GCCEntities(con))
                {
                    campan = db.tblCampanha.FirstOrDefault(a=>a.ID==campanha.CampanhaID);
                    if (campan !=null)
                    {
                        //Update Campanha 
                    campan.CanalID = campanha.CanalID;
                    campan.CodCampanha = campanha.CodCampanha;
                    campan.DataInicio = campanha.DataInicio;
                    campan.DataFim = campanha.DataFim;
                    campan.MaxAlvosBalcao = campanha.MaxAlvosBalcao;
                    campan.MaxAlvosGestor = campanha.MaxAlvosGestor;
                    campan.NomeCampanha = campanha.NomeCampanha;
                    campan.PrioridadeID = campanha.PrioridadeID;
                    campan.RazaoContactoID = campanha.RazaoContactoID;
                    campan.RecorrenciaID = campanha.RecorrenciaID;
                    //if (campanha.RecorrenciaID == 3)
                         campan.DataRecorrMensal = campanha.DataRecorrMensal;
                     //if (campanha.RecorrenciaID == 2)
                        campan.DataRecorrSemanal = campanha.DataRecorrSemanal;
                        campan.UserRegisto = UserID;
                    campan.DataRegisto = DateTime.Now;
                    db.SaveChanges();
                    Result = campanha.CampanhaID;

                    //Save CampanhaProvince 
                    if (campanha.provincia != null)
                    {
                        foreach (Provincia item in campanha.provincia)
                        {
                               
                            if (item.ProvinciaID > 0 && item.NomeProvincia != null && item.NomeProvincia != "")
                            {

                                    SaveListas(ref province, ref redes,con:con,CampanhaID:campanha.CampanhaID,UserID:UserID,prov:item);
                            }

                        }


                    }

                    //Save CampanhaRede
                    if (campanha.rede != null)
                    {
                        foreach (Rede item in campanha.rede)
                        {
                            if (item.RedeID > 0 && item.NomeRede != null && item.NomeRede != "")
                            {

                                    SaveListas(ref province, ref redes,con: con, CampanhaID: campanha.CampanhaID, UserID: UserID, red: item);

                                }

                        }


                    }
                }
                    if (province.Count >0)
                    {
                        UpdateListas(list:province,con:con,tipo:"provincia",CampanhaID:campanha.CampanhaID);
                    }

                    if (redes.Count > 0)
                    {
                        UpdateListas(list: redes, con: con, tipo: "redes", CampanhaID: campanha.CampanhaID);
                    }

                }

            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Campanha_Manager - UpdateCampanha(CampanhaID=" + campanha.CampanhaID + "))- ", erro);
                throw erro;
            }

            return Result;
        }

                            
        public static void SaveListas(ref List<int> province, ref List<int> redes, string con,int CampanhaID, string UserID, Provincia prov = null, Rede  red = null)
        {
            try
            {
                using (GCCEntities db=new GCCEntities(con))
                {
                    if (prov != null)
                    {
                        tblCampanha_Por_Provincia campProv = new tblCampanha_Por_Provincia();
                        var camp = db.tblCampanha_Por_Provincia.FirstOrDefault(a => a.ProvinciaID == prov.ProvinciaID && a.CampanhaID == CampanhaID);
                        if (camp != null)
                        {
                           camp.Estado = true;
                            camp.UserRegisto = UserID;
                           db.SaveChanges();
                            province.Add(prov.ProvinciaID);
                        }
                        else
                        {
                            campProv.ProvinciaID = prov.ProvinciaID;
                            campProv.Provincia = prov.NomeProvincia.ToString();
                            campProv.CampanhaID = CampanhaID;
                            campProv.UserRegisto = UserID;
                            campProv.Estado = true;
                            campProv.DataRegisto = DateTime.Now;
                            db.AddTotblCampanha_Por_Provincia(campProv);
                            db.SaveChanges();
                            province.Add(campProv.ProvinciaID);
                        }
                    }
                    else 
                    if(red !=null)
                    {
                        Rede_da_Campanha rede = new Rede_da_Campanha();

                        var redeCamp = db.Rede_da_Campanha.FirstOrDefault(a => a.RedeID == red.RedeID && a.CampanhaID == CampanhaID);
                        if (redeCamp != null)
                        {
                            redeCamp.Estado = true;
                            redeCamp.UserRegisto = UserID;
                           
                            db.SaveChanges();
                            redes.Add(red.RedeID);
                        }
                        else
                        {
                            rede.RedeID = red.RedeID;
                            rede.Rede = red.NomeRede.ToString();
                            rede.CampanhaID = CampanhaID;
                            rede.UserRegisto = UserID;
                            rede.Estado = true;
                            rede.DataRegisto = DateTime.Now;
                            db.AddToRede_da_Campanha(rede);
                            db.SaveChanges();
                            redes.Add(rede.RedeID);
                        }
                    }
                }

            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Campanha_Manager - SaveListas(CampanhaID=" + CampanhaID + "))- ", erro);
                throw erro;
            }
        }

        public static void UpdateListas(List<int> list,string con,string tipo,int CampanhaID)
        {
            try
            {
                using (GCCEntities db= new GCCEntities(con))
                {
                    if (tipo=="provincia")
                    {
                        var lista = db.tblCampanha_Por_Provincia.Where(a => !list.Contains(a.ProvinciaID) && a.CampanhaID == CampanhaID && a.Estado==true).ToList();
                        foreach (tblCampanha_Por_Provincia item in lista)
                        {
                            var prov = db.tblCampanha_Por_Provincia.FirstOrDefault(a => a.ID == item.ID);
                            if (prov != null)
                            {
                                prov.Estado = false;
                                db.SaveChanges();
                            }
                        }
                    }else
                    {
                        var lista = db.Rede_da_Campanha.Where(a => !list.Contains(a.RedeID) && a.CampanhaID == CampanhaID && a.Estado==true).ToList();
                        foreach (Rede_da_Campanha item in lista)
                        {
                            var red = db.Rede_da_Campanha.FirstOrDefault(a => a.ID == item.ID);
                            if (red != null)
                            {
                                red.Estado = false;
                                db.SaveChanges();
                            }
                        }
                    }

                }
            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Campanha_Manager - UpdateListas(CampanhaID=" + CampanhaID + "))- ", erro);
                throw erro;
            }
        }
        public static int SaveProduto(Models.Produto prod, string con, string UserID)
        {
            Int32 Result = 0;
            //int ProdutoID = 0;
            tblAssunto produto = new tblAssunto();

            try
            {
                using (GCCEntities db = new GCCEntities(con))
                {

                    if (prod.ProdutoID > 0 && prod.CampanhaID > 0 && prod.CodProduto !=null && prod.Nome !=null)
                    { 
                        //Save Assunto 
                    produto.CodProduto = prod.CodProduto;
                    produto.CampanhaID = prod.CampanhaID;
                    produto.ProdutoID = prod.ProdutoID;
                    produto.NomeProduto = prod.Nome;
                    produto.UserRegisto = UserID;
                    produto.Estado = true;
                    produto.DataRegisto = DateTime.Now;
                    db.AddTotblAssunto(produto);
                    db.SaveChanges();
                    Result = produto.ID;
                    }

                }
            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Campanha_Manager - SaveProduto(prodID=" + prod.ProdutoID + "))- ", erro);
                throw erro;
            }

            return Result;
        }
        public static List<Product> GetProductRootList()
        {

            WSCatalogoProdutosClient catalogo = new WSCatalogoProdutosClient();

            List<Product> lista = new List<Product>();
            List<Product> rootList = new List<Product>();
           
            try
            {


                lista = catalogo.GetAllProductList();
              
            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Campanha_Manager - GetProductRootList()- ", erro);
                throw erro;
            }
            return lista;
        }
        public static tblCampanha GetCampanha(string Codigo,string con)
        {
            tblCampanha campanha = new tblCampanha();
            try
            {

                using (GCCEntities db= new GCCEntities(con))
                {
                    campanha = db.tblCampanha.FirstOrDefault(a=>a.CodCampanha ==Codigo);
                }
            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Campanha_Manager - GetCampanha(Codigo="+ Codigo + ")- ", erro);
                throw erro;
            }
            return campanha;
        }
        public static Campanha GetCampanha(int ID, string con)
        {
            tblCampanha campanh = new tblCampanha();
            List<tblAssunto> listaprod = new List<tblAssunto>();
            List<tblCampanha_Por_Provincia> listaprov = new List<tblCampanha_Por_Provincia>();
            List<Rede_da_Campanha> listared = new List<Rede_da_Campanha>();
            List<Provincia> listaprovincia = new List<Provincia>();
            List<Rede> listarede = new List<Rede>();
           

            Campanha campanha = new Campanha();

            try
            {

                using (GCCEntities db = new GCCEntities(con))
                {
                    campanh = db.tblCampanha.FirstOrDefault(a => a.ID == ID);
                    listaprov = db.tblCampanha_Por_Provincia.Where(a=>a.CampanhaID==ID && a.Estado==true).ToList();
                    listared = db.Rede_da_Campanha.Where(a => a.CampanhaID == ID && a.Estado == true).ToList();
                    listaprod = db.tblAssunto.Where(a => a.CampanhaID == ID).ToList();


                    foreach (Rede_da_Campanha item in listared)
                    {
                        Rede rede = new Rede();
                        rede.RedeID = item.RedeID;
                        rede.NomeRede = item.Rede;
                        listarede.Add(rede);
                        
                    }
                    foreach (tblCampanha_Por_Provincia item in listaprov)
                    {
                        Provincia provincia = new Provincia();
                        provincia.ProvinciaID = item.ProvinciaID;
                        provincia.NomeProvincia = item.Provincia;
                        listaprovincia.Add(provincia);
                        
                    }

                    campanha.produtos = listaprod;
                    campanha.provincia = listaprovincia;
                    campanha.rede = listarede;
                    campanha.CampanhaID = campanh.ID;
                    campanha.CodCampanha = campanh.CodCampanha;
                    campanha.NomeCampanha = campanh.NomeCampanha;
                    campanha.DataInicio = campanh.DataInicio;
                    campanha.DataFim = campanh.DataFim;
                    campanha.MaxAlvosGestor = campanh.MaxAlvosGestor;
                    campanha.MaxAlvosBalcao = campanh.MaxAlvosBalcao;
                    campanha.Estado = campanh.Estado;
                    campanha.RazaoContactoID = campanh.RazaoContactoID;
                    campanha.CanalID = campanh.CanalID;
                    campanha.RecorrenciaID = campanh.RecorrenciaID;
                    campanha.PrioridadeID = campanh.PrioridadeID;
                    campanha.DataRecorrSemanal = campanh.DataRecorrSemanal;
                    campanha.DataRecorrMensal = campanh.DataRecorrMensal;

                   
    }
            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Campanha_Manager - GetCampanha(ID=" + ID + ")- ", erro);
                throw erro;
            }
            return campanha;
        }
        public static bool UpdateProdutoStatus(int estado,int ID, string con)
        {
            bool result = false;
            tblAssunto produto = new tblAssunto();
            try
            {
                using (GCCEntities db = new GCCEntities(con))
                {
                    produto = db.tblAssunto.FirstOrDefault(a => a.ID == ID);
                    if (produto != null)
                    {
                        produto.Estado = estado == 1 ? true : false;
                        db.SaveChanges();
                        result = true;
                    }

                }

            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Campanha_Manager - UpdateProdutoStatus(ID=" + ID + ")- ", erro);
                throw erro;
            }

            return result;
        }
        public static bool UpdateCampanhaStatus(int estado, int campanhaID, string con)
        {
            bool result = false;
            tblCampanha campanha = new tblCampanha();
            try
            {
                using (GCCEntities db = new GCCEntities(con))
                {
                    campanha = db.tblCampanha.FirstOrDefault(a=>a.ID ==campanhaID);
                    if (campanha !=null)
                    {
                        campanha.Estado = estado == 1 ? true : false;
                        db.SaveChanges();
                        result = true;
                    }
                    
                }

            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Campanha_Manager - UpdateCampanhaStatus(campanhaID=" + campanhaID + ")- ", erro);
                throw erro;
            }

            return result;
        }
        public static bool DeleteProdutoCampanha(int ID, string con)
        {
            bool result = false;
            tblAssunto produto = new tblAssunto();
            try
            {
                using (GCCEntities db = new GCCEntities(con))
                {
                    produto = db.tblAssunto.FirstOrDefault(a => a.ID == ID);
                   if (produto != null)
                    {
                        db.tblAssunto.DeleteObject(produto);
                        db.SaveChanges();
                        result = true;
                    }
                    
                }

            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Campanha_Manager - DeleteProdutoCampanha(ID=" + ID + ")- ", erro);
                throw erro;
            }

            return result;
        }
        public static tblAssunto GetProduto(int CampanhaID, int ProdutoID, string con)
        {
            tblAssunto produto = new tblAssunto();
            try
            {

                using (GCCEntities db = new GCCEntities(con))
                {
                    produto = db.tblAssunto.FirstOrDefault(a => a.CampanhaID == CampanhaID && a.ProdutoID == ProdutoID);
                }
            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Campanha_Manager - GetProduto(CampanhaID=" + CampanhaID + ",ProdutoID="+ ProdutoID + ")- ", erro);
                throw erro;
            }
            return produto;
        }

        public static List<vw_Assunto> GetcampanhaProductList(int CampanhaID,string con)
        {
             List<vw_Assunto> lista = new List<vw_Assunto>();
           
            try
            {
                using (GCCEntities db = new GCCEntities(con))
                {
                    lista = db.vw_Assunto.Where(a=>a.CampanhaID == CampanhaID).ToList();

                }

               

            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Campanha_Manager - GetcampanhaProductList(CampanhaID=" + CampanhaID + ")- ", erro);
                throw erro;
            }
            return lista;
        }
        public static List<VW_Campanha> GetCampanhaList(string con)
        {
            List<VW_Campanha> lista = new List<VW_Campanha>();

            try
            {
                using (GCCEntities db = new GCCEntities(con))
                {
                    
                        lista = db.VW_Campanha.OrderByDescending(a => a.ID).ToList();
                   
                }



            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Campanha_Manager - GetCampanhaList()- ", erro);
                throw erro;
            }
            return lista;
        }
    }
}