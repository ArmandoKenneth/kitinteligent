using KitInteligente.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KitInteligente.ViewModel
{
    public class TransacaoEntrada
    {
        /*public int Qtd { get; set; }
        public double Custo { get; set; }
        public int ProdutoID { get; set; }

        public ICollection<Produto> Proutos { get; set; }*/

        [Display(Name ="Quantidade")]
        [Required(ErrorMessage ="Campo obrigatorio")]
        public int Qtd { get; set; }

        [Display(Name = "Custo")]
        [Required(ErrorMessage = "Campo obrigatorio")]
        public double Custo { get; set; }

        public Produto Produto { get; set; }
        public int ProdutoID { get; set; }

        [Display(Name = "Entrada")]
        [Required(ErrorMessage = "Campo obrigatorio")]
        public DateTime DataEntrada { get; set; }
        public object TpTransacaoID { get; internal set; }
    }
}