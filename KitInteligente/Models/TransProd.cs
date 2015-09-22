using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitInteligente.Models
{
    public class TransProd
    {
        public int TransProdID { get; set; }
        public int QtdEstoque { get; set; }
        public double Custo { get; set; }

        // Foreign keys
        public int ProdutoID { get; set; }
        public int TransacaoID { get; set; }

        // Virtual objects
        public virtual Produto Produto { get; set; }
        public virtual Transacao Transacao { get; set; }
    }
}