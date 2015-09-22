using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitInteligente.Models
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public double QtdEstSeg { get; set; }

        // Foreign keys
        public int CategoriaID { get; set; }
        public int CalcEstoqueSegID { get; set; }

        // Virtual objects
        public virtual Categoria Categoria { get; set; }
        public virtual CalcEstoqueSeg CalcEstoqueSeg { get; set; }
    }
}