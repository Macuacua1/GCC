using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GCC.Models
{
    public class Campanha
    {
        public int CampanhaID { get; set; }
        public string CodCampanha { get; set; }
        public string  NomeCampanha { get; set; }
        public DateTime? DataRecorrMensal { get; set; }
        public int? DataRecorrSemanal { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int? MaxAlvosGestor { get; set; }
        public int? MaxAlvosBalcao { get; set; }
        public bool Estado { get; set; }
        public int RazaoContactoID { get; set; }
        public int ProvinciaID { get; set; }
        public int RedeID { get; set; }

        public int? IDProvincia { get; set; }
        public int? IDRede { get; set; }
        public int CanalID { get; set; }
        public int RecorrenciaID { get; set; }
        public int? PrioridadeID { get; set; }
        public Produto produto { get; set; }
        public List<Rede> rede { get; set; }
        public List<Provincia> provincia { get; set; }
        public List<tblAssunto> produtos { get; set; }
    }
}