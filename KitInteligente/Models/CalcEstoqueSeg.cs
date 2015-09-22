using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitInteligente.Models
{
    public class CalcEstoqueSeg
    {
        public int CalcEstoqueSegID { get; set; }
        public double DemTotal { get; set; }
        public double DemMedia { get; set; }
        public double DesvioPadrao { get; set; }
        public int LeadTime { get; set; }
        public double EstoqueSeg { get; set; }
        public int PontoRessuprimento { get; set; }
        public int EstoqueMaximo { get; set; }

        // Foreign keys
        //public int ProdutoID { get; set; }
        public int DemandaID { get; set; }
        public int NivelServicoID { get; set; }

        // Virtual object
        public virtual Demanda Demanda { get; set; }
        public virtual NivelServico NivelServico { get; set; }
    }
}