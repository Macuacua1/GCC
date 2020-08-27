using GCC.ActiveDirectoryGroupUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace GCC.Class
{
    public static class Common
    {
        public static Users GetUserActiveDirectory(this string xnuc)
        {
            try
            {
                Users DadosUtilizadores = new UsersServiceADClient().GetUserByXnuc(xnuc);

                return DadosUtilizadores;
            }
            catch (Exception)
            {
                //return null;
                throw;
            }
        }
    }
}