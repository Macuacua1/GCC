using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCC.Models
{
    public class Catalogo
    {
        public int ProdutoRaiz { get; set; }

        public int ProdutoNivel1 { get; set; }
        public int ProdutoNivel2 { get; set; }
        public int ProdutoNivel3 { get; set; }

        public string Nome { get; set; }

        public string CodProduto { get; set; }

        public int ProdutoID { get; set; }
        public int CampanhaID { get; set; }
    }
}