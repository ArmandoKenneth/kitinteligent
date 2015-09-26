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
        public int PeriodoSelecionado;

        // Foreign keys
        //public int ProdutoID { get; set; }
        //public int DemandaID { get; set; }
        public int NivelServicoID { get; set; }

        // Virtual object
        public virtual ICollection<Demanda> Demandas { get; set; }
        public virtual NivelServico NivelServico { get; set; }

        public CalcEstoqueSeg()
        {
            this.NivelServicoID = (int)Utils.NivelServico.NV50;
            this.DemTotal = 0;
            this.DemMedia = 0;
            this.DesvioPadrao = 0;
            this.LeadTime = 0;
            this.EstoqueSeg = 0;
            this.PontoRessuprimento = 0;
            this.EstoqueMaximo = 0;
            this.PeriodoSelecionado = 0;
        }
    }
}