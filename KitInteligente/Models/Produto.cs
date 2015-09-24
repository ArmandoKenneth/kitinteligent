using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KitInteligente.Models
{
    public class Produto
    {
       
        public int ProdutoID { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Campo obrigatorio")]
        public int Codigo { get; set; }

        [Display(Name = "Produto")]
        [Required(ErrorMessage = "Campo obrigatorio")]
        public string Descricao { get; set; }

        [Display(Name = "Estoque de segurança")]
        [Required(ErrorMessage = "Campo obrigatorio")]
        public double QtdEstSeg { get; set; }

        // Foreign keys
        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Campo obrigatorio")]
        public int CategoriaID { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        public int CalcEstoqueSegID { get; set; }

        // Virtual objects
        [Display(Name = "Categoria")]
        public virtual Categoria Categoria { get; set; }
        public virtual CalcEstoqueSeg CalcEstoqueSeg { get; set; }
        public virtual ICollection<TransProd> TransProds { get; set; }

        [Display(Name = "Estoque")]
        [Required(ErrorMessage = "Campo obrigatorio")]
        public virtual int estoqueTotal { get; set; }
    }
}