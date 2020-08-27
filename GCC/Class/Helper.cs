using GCC;
using GCC.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCC.Class
{
    public class Helper
    {
        string con = ConnectionDB.GetContactosDBConnectionString;
        public string getURL(string AppName)
        {
            return dfd.validacoes.Voltar(AppName);
        }

        public string getNUMUNICO( string XNuC)
        {
            string NUMUNICO = "";
            try
            {
                using (CONTACTOSEntities db = new CONTACTOSEntities(con))
                {
                    var colab = db.Colaborador.SingleOrDefault(x=> x.Username==XNuC);
                    NUMUNICO = colab.NUMUNICO.ToString();
                }
            }
            catch (Exception erro)
            {
                LogInicializer.logger.Info(DateTime.Now + " -Helper - getNUMUNICO)- ", erro);
               
                throw erro;
            }

            return NUMUNICO;
        }

        public string getServerName(string AppName, string BD, int tipo)
        {
            return dfd.validacoes.Ligacao(AppName, BD, tipo);
        }

        public string getUserName(string AppName, string BD, int tipo, string user)
        {
            return dfd.validacoes.Ligacao(AppName, BD, tipo, user);
        }

        public string getPass(string AppName, string BD, int tipo, string pass)
        {
            return dfd.validacoes.Ligacao(AppName, BD, tipo, pass);
        }
    }
}