using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitInteligente.Models
{
    public class CalculoEstoque
    {
        public Produto Produto { get; set; }
        //public CalcEstoqueSeg CalcEstoqueSeg { get; set; }
        //public int NivelServicoID { get; set; }
        public IEnumerable<NivelServico> NiveisServico { get; set; }
        //public ICollection<Demanda> Demandas { get; set; }
    }
}