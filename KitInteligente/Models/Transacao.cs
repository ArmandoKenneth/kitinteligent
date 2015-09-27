using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitInteligente.Models
{
    public class Transacao
    {
        public int TransacaoID { get; set; }
        public int QtdTransacao { get; set; }
        public double CustoUn { get; set; }
        public double CustoTotal { get; set; }
        public DateTime Horario { get; set; }

        // Foreign keys
        // public int UsuarioID { get; set; }
        public int TpTransacaoID { get; set; }
        public int TransProdID { get; set; }

        // Virtual objects
        // public virtual Usuario Usuario { get; set; }
        public virtual TpTransacao TpTransacao { get; set; }
        public virtual TransProd TransProd { get; set; }
    }
}