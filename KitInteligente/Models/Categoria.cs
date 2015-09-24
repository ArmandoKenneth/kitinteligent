using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KitInteligente.Models
{
    public class Categoria
    {

        public int CategoriaID { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Campo obrigatorio")]
        public string Descricao { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

        [NotMapped]
        public bool PermitirExclusao { get; set; }
    }
}