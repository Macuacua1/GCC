using GCC.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCC.Managers
{
    public class Home_Manager
    {
        public static List<tblRazaoContacto> GetRazaoList(string con)
        {
            try
            {
                using (GCCEntities db= new GCCEntities(con))
                {
                    return db.tblRazaoContacto.OrderBy(a=>a.ID).ToList();
                }
            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Home_Manager - GetRazaoList)- ", erro);
                throw erro;
            }
        }
        public static List<tblPrioridade> GetPrioridadeList(string con)
        {
            try
            {
                using (GCCEntities db = new GCCEntities(con))
                {
                    return db.tblPrioridade.OrderBy(a => a.ID).ToList();
                }
            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Home_Manager - GetPrioridadeList)- ", erro);
                throw erro;
            }
        }
        public static List<tblRede> GetRedeList(string con)
        {
            try
            {
                using (GCCEntities db = new GCCEntities(con))
                {
                    return db.tblRede.OrderBy(a => a.ID).ToList();
                }
            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Home_Manager - GetRedeList)- ", erro);
                throw erro;
            }
        }
        public static List<tblCanal> GetCanalList(string con)
        {
            try
            {
                using (GCCEntities db = new GCCEntities(con))
                {
                    return db.tblCanal.OrderBy(a => a.ID).ToList();
                }
            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Home_Manager - GetCanalList)- ", erro);
                throw erro;
            }
        }

        public static bool ActualizaRazao(int status,int ID,string con)
        {
            bool result = false;
            bool estado = status == 1 ? true : false;
            try
            {
                using (GCCEntities db= new GCCEntities(con))
                {
                    var razao = db.tblRazaoContacto.SingleOrDefault(a=>a.ID==ID);
                    if (razao !=null)
                    {
                        razao.Estado = estado;
                        db.SaveChanges();
                        result = true;
                    }

                }
            }

            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Home_Manager - GetCanalList)- ", erro);
                throw erro;
            }

            return result;

        }
        public static bool ActualizaPrioridade(int status, int ID, string con)
        {
            bool result = false;
            bool estado = status == 1 ? true : false;
            try
            {
                using (GCCEntities db = new GCCEntities(con))
                {
                    var obj = db.tblPrioridade.SingleOrDefault(a => a.ID == ID);
                    if (obj != null)
                    {
                        obj.Estado = estado;
                        db.SaveChanges();
                        result = true;
                    }

                }
            }

            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Home_Manager - ActualizaPrioridade(ID="+ ID + "))- ", erro);
                throw erro;
            }

            return result;

        }
        public static bool ActualizaCanal(int status, int ID, string con)
        {
            bool result = false;
            bool estado = status == 1 ? true : false;
            try
            {
                using (GCCEntities db = new GCCEntities(con))
                {
                    var obj = db.tblCanal.SingleOrDefault(a => a.ID == ID);
                    if (obj != null)
                    {
                        obj.Estado = estado;
                        db.SaveChanges();
                        result = true;
                    }

                }
            }

            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Home_Manager - ActualizaCanal(ID=" + ID + "))- ", erro);
                throw erro;
            }

            return result;

        }
        public static bool ActualizaRede(int status, int ID, string con)
        {
            bool result = false;
            bool estado = status == 1 ? true : false;
            try
            {
                using (GCCEntities db = new GCCEntities(con))
                {
                    var obj = db.tblRede.SingleOrDefault(a => a.ID == ID);
                    if (obj != null)
                    {
                        obj.Estado = estado;
                        db.SaveChanges();
                        result = true;
                    }

                }
            }

            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Home_Manager - ActualizaRede(ID=" + ID + "))- ", erro);
                throw erro;
            }

            return result;

        }

        public static bool CreateParamtrizacao(ref string mensagem, string texto, string Tipo,string UserID, string con,int ID)
        {
            bool result = false;
            
            try
            {
                using (GCCEntities db = new GCCEntities(con))
                {
                    switch (Tipo)
                    {
                        case "Razao":
                            if (ID > 0)
                            {
                                var obj = db.tblRazaoContacto.FirstOrDefault(a => a.ID == ID);
                                obj.RazaoContacto = texto.Trim();
                                db.SaveChanges();
                                mensagem = "Actualizado com Sucesso!";
                                result = true;
                            }
                            else
                            {
                                var obj = db.tblRazaoContacto.FirstOrDefault(a=>a.RazaoContacto.Trim().ToUpper() == texto.Trim().ToUpper());
                                if (obj==null) {
                                    tblRazaoContacto razao = new tblRazaoContacto();
                                    razao.RazaoContacto = texto.Trim(); 
                                    razao.Estado = true;
                                    razao.DataRegisto = DateTime.Now;
                                    razao.UserRegisto = UserID;
                                    db.AddTotblRazaoContacto(razao);
                                    db.SaveChanges();
                                    mensagem = "Registado com Sucesso!";
                                    result = true;
                                }
                                else {
                                    mensagem = "Existe um registo com este Nome!";
                                }
                                
                            }
                            
                            break;

                        case "Prioridade":
                            if (ID > 0)
                            {

                                var obj = db.tblPrioridade.FirstOrDefault(a => a.ID == ID);
                                obj.Prioridade = texto.Trim();
                                db.SaveChanges();
                                mensagem = "Actualizado com Sucesso!";
                                result = true;
                            }
                            else
                            {
                                var obj = db.tblPrioridade.FirstOrDefault(a => a.Prioridade.Trim().ToUpper() == texto.Trim().ToUpper());
                                if (obj == null)
                                {
                                    tblPrioridade prioridade = new tblPrioridade();
                                    prioridade.Prioridade = texto.Trim();
                                    prioridade.Estado = true;
                                    prioridade.DataRegisto = DateTime.Now;
                                    prioridade.UserRegisto = UserID;
                                    db.AddTotblPrioridade(prioridade);
                                    db.SaveChanges();
                                    mensagem = "Registado com Sucesso!";
                                    result = true;
                                }
                                else
                                {
                                    mensagem = "Existe um registo com este Nome!";
                                }
                            }

                                break;
                        case "Canal":
                            if (ID > 0)
                            {

                                var obj = db.tblCanal.FirstOrDefault(a => a.ID == ID);
                                obj.Canal = texto.Trim();
                                db.SaveChanges();
                                mensagem = "Actualizado com Sucesso!";
                                result = true;
                            }
                            else
                            {
                                var obj = db.tblCanal.FirstOrDefault(a => a.Canal.Trim().ToUpper() == texto.Trim().ToUpper());
                                if (obj == null)
                                {
                                    tblCanal canal = new tblCanal();
                                canal.Canal = texto.Trim();
                                canal.Estado = true;
                                canal.DataRegisto = DateTime.Now;
                                canal.UserRegisto = UserID;
                                db.AddTotblCanal(canal);
                                db.SaveChanges();
                                    mensagem = "Registado com Sucesso!";
                                    result = true;
                                }
                                else
                                {
                                    mensagem = "Existe um registo com este Nome!";
                                }
                            }
                            
                            break;
                        case "Rede":
                            if (ID > 0)
                            {

                                var obj = db.tblRede.FirstOrDefault(a => a.ID == ID);
                                obj.Rede = texto.Trim();
                                db.SaveChanges();
                                mensagem = "Actualizado com Sucesso!";
                                result = true;
                            }
                            else
                            {
                                var obj = db.tblRede.FirstOrDefault(a => a.Rede.Trim().ToUpper() == texto.Trim().ToUpper());
                                if (obj == null)
                                {
                                    tblRede rede = new tblRede();
                                rede.Rede = texto.Trim();
                                rede.Estado = true;
                                rede.DataRegisto = DateTime.Now;
                                rede.UserRegisto = UserID;
                                db.AddTotblRede(rede);
                                db.SaveChanges();
                                    mensagem = "Registado com Sucesso!";
                                    result = true;
                                }
                                else
                                {
                                    mensagem = "Existe um registo com este Nome!";
                                }
                            }
                            
                            break;
                    }
                }
            }

            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Home_Manager - CreateParamtrizacao(texto=" + texto + ",TIPO="+Tipo+"))- ", erro);
                throw erro;
            }

            return result;

        }
    }
}