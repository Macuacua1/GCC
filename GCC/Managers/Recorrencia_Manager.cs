using GCC.Class;
using GCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCC.Managers
{
    public class Recorrencia_Manager
    {
        public static List<RecorrenciaChart> GetCampanhaListChart(string con, int Periodo, int? Recorrencia)
        {
            List<RecorrenciaChart> lista = new List<RecorrenciaChart>();
            int NumDias = Periodo == 0 ? Periodo : (Periodo - 1);
           
            try
            {
                using (GCCEntities db = new GCCEntities(con))
                {

                    DateTime DataHoje = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                    
                    if (Periodo != 100 && Recorrencia == 100)
                    {
                        var list = db.vw_Log_Recorrencia.Where(a => a.DiasDecorridos <= NumDias).ToList();

                        for (int i= NumDias; i>= 0; i--)
                        {
                            
                            DateTime DiffData = DataHoje.AddDays(-i);
                            string Data = DiffData.ToString("MM/dd/yyyy");
                            RecorrenciaChart chart = new RecorrenciaChart();
                            chart.Data = Data;
                            chart.sucesso = list.Where(a=>a.DiasDecorridos==i && a.Estado==true).ToList().Count;
                            chart.falha = list.Where(a => a.DiasDecorridos == i && a.Estado == false).ToList().Count;
                            lista.Add(chart);
                            //i++;

                        }
                    }
                    if (Periodo != 100 && Recorrencia != 100)
                    {
                        var list = db.vw_Log_Recorrencia.Where(a => a.DiasDecorridos <= NumDias && a.RecorrenciaID == Recorrencia).ToList();

                        for (int i = NumDias; i >= 0; i--)
                        {

                            DateTime DiffData = DataHoje.AddDays(-i);
                            string Data = DiffData.ToString("MM/dd/yyyy");
                            RecorrenciaChart chart = new RecorrenciaChart();
                            chart.Data = Data;
                            chart.sucesso = list.Where(a => a.DiasDecorridos == i && a.Estado == true).ToList().Count;
                            chart.falha = list.Where(a => a.DiasDecorridos == i && a.Estado == false).ToList().Count;
                            lista.Add(chart);
                            //i++;

                        }
                    }
                    if (Periodo == 100 && Recorrencia != 100)
                    {
                        var list = db.vw_Log_Recorrencia.Where(a => a.RecorrenciaID == Recorrencia).ToList();

                        for (int i = NumDias; i >= 0; i--)
                        {

                            DateTime DiffData = DataHoje.AddDays(-i);
                            string Data = DiffData.ToString("MM/dd/yyyy");
                            RecorrenciaChart chart = new RecorrenciaChart();
                            chart.Data = Data;
                            chart.sucesso = list.Where(a => a.DiasDecorridos == i && a.Estado == true).ToList().Count;
                            chart.falha = list.Where(a => a.DiasDecorridos == i && a.Estado == false).ToList().Count;
                            lista.Add(chart);
                            //i++;

                        }
                    }
                    if (Periodo == 100 && Recorrencia == 100)
                    {
                        var list = db.vw_Log_Recorrencia.ToList();

                        for (int i = NumDias; i >= 0; i--)
                        {

                            DateTime DiffData = DataHoje.AddDays(-i);
                            string Data = DiffData.ToString("MM/dd/yyyy");
                            RecorrenciaChart chart = new RecorrenciaChart();
                            chart.Data = Data;
                            chart.sucesso = list.Where(a => a.DiasDecorridos == i && a.Estado == true).ToList().Count;
                            chart.falha = list.Where(a => a.DiasDecorridos == i && a.Estado == false).ToList().Count;
                            lista.Add(chart);
                            //i++;

                        }
                    }

                }

            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Recorrencia_Manager - GetRecorrenciasListChart()- ", erro);
                throw erro;
            }
            return lista;
        }
        public static List<vw_Log_Recorrencia> GetCampanhaList(string con,int Periodo, int? Recorrencia, int? Estado)
        {
            bool status = Estado == 1 ? true : false;
            int NumDias = Periodo == 0 ? Periodo : (Periodo - 1);
            List<vw_Log_Recorrencia> lista = new List<vw_Log_Recorrencia>();

            try
            {
                using (GCCEntities db = new GCCEntities(con))
                {

                    if (Estado ==100 && Periodo ==100 && Recorrencia ==100)
                    {
                        return db.vw_Log_Recorrencia.ToList();
                    }

                    if (Estado !=100 && Periodo ==100 && Recorrencia ==100)
                    {
                        return db.vw_Log_Recorrencia.Where(a => a.Estado == status).ToList();
                    }

                    if (Estado ==100 && Periodo !=100 && Recorrencia ==100)
                    {
                        return db.vw_Log_Recorrencia.Where(a => a.DiasDecorridos <= NumDias).ToList();
                    }

                    if (Estado ==100 && Periodo ==100 && Recorrencia !=100)
                    {
                        return db.vw_Log_Recorrencia.Where(a => a.RecorrenciaID == Recorrencia).ToList();
                    }

                    if (Estado !=100 && Periodo !=100 && Recorrencia ==100)
                    {
                        return db.vw_Log_Recorrencia.Where(a => a.Estado == status && a.DiasDecorridos <= NumDias).ToList();
                    }

                    if (Estado ==100 && Periodo !=100 && Recorrencia !=100)
                    {
                        return db.vw_Log_Recorrencia.Where(a => a.RecorrenciaID == Recorrencia && a.DiasDecorridos <= NumDias).ToList();
                    }

                    if (Estado !=100 && Periodo ==100 && Recorrencia !=100)
                    {
                        return db.vw_Log_Recorrencia.Where(a => a.Estado == status && a.RecorrenciaID==Recorrencia).ToList(); }

                    if (Estado !=100 && Periodo !=100 && Recorrencia !=100)
                    {
                        return  db.vw_Log_Recorrencia.Where(a => a.Estado == status && a.RecorrenciaID == Recorrencia && a.DiasDecorridos <= NumDias).ToList(); }
                    

                }



            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Recorrencia_Manager - GetRecorrenciasList()- ", erro);
                throw erro;
            }
            return lista;
        }

        public static List<VW_Recorrencia> GetRecorrenciaPorExecutar(string con)
        {
            List<VW_Recorrencia> lista = new List<VW_Recorrencia>();

            try
            {
                using (GCCEntities db = new GCCEntities(con))
                {
                    lista = db.VW_Recorrencia.OrderByDescending(a => a.CampanhaID).ToList();

                }



            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Recorrencia_Manager - GetRecorrenciaPorExecutar()- ", erro);
                throw erro;
            }
            return lista;
        }
    }

}