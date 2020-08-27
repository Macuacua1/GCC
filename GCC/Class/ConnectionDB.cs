using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCC.Class
{
    public class ConnectionDB
    {
        public static string GetDBConnectionString
        {
            get
            {
                return dfd.dbLigacao.obtemDadosLigacao("GCC", "GCC", "DB");
            }
        }
        public static string GetContactosDBConnectionString
        {
            get
            {
                return dfd.dbLigacao.obtemDadosLigacao("GCC", "CONTACTOS", "CONTACTOS");
            }
        }

        public static string GetDBConnection
        {
            get
            {
                return dfd.dbLigacao.obtemDadosLigacao("GCC", "GCC");
            }
        }
    }
}