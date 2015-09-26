using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitInteligente.Models
{
    public class JsonCalculo
    {
        //public int Demanda1 { get; set; }
        //public int Demanda2 { get; set; }
        //public int Demanda3 { get; set; }
        //public int Demanda4 { get; set; }
        //public int Demanda5 { get; set; }
        //public int Demanda6 { get; set; }
        //public int Demanda7 { get; set; }
        //public int Demanda8 { get; set; }
        //public int Demanda9 { get; set; }
        //public int Demanda10 { get; set; }
        public int[] Demandas { get; set; }

        public double Media { get; set; }
        public double Total { get; set; }

        public double DesvioPadrao { get; set; }
        public int LeadTime { get; set; }
        public int PeriodoSelecionado { get; set; }

        public double EstoqueSeguro { get; set; }
        public double PontoRessuprimento { get; set; }
        public double EstoqueMaximo { get; set; }

        public int NivelServicoID { get; set; }

        public int ProdutoID { get; set; }
    }
}