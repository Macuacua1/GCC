using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCC.Models
{
    public class ParametrizacaoGeral
    {
        public Canal canal { get; set; }
        public Prioridade prioridade { get; set; }
        public RazaoContacto razaoContacto { get; set; }
        public Rede rede { get; set; }
    }
}