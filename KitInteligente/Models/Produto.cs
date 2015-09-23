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
        public int Codigo { get; set; }

        [Display(Name = "Produto")]
        public string Descricao { get; set; }

        [Display(Name = "Estoque de seguranca")]
        public double QtdEstSeg { get; set; }

        // Foreign keys
        public int CategoriaID { get; set; }
        public int CalcEstoqueSegID { get; set; }

        // Virtual objects
        public virtual Categoria Categoria { get; set; }
        public virtual CalcEstoqueSeg CalcEstoqueSeg { get; set; }
        public virtual ICollection<TransProd> TransProds { get; set; }

        [Display(Name = "Estoque")]
        public virtual int estoqueTotal { get; set; }
    }
}