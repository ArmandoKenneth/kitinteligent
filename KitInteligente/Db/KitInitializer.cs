using KitInteligente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitInteligente.Db
{
    public class KitInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<KitContext>
    {
        protected override void Seed(KitContext context)
        {

            #region Categorias
            var categorias = new List<Categoria>
            {
                new Categoria {CategoriaID = 1, Descricao = "Bebida" },
                new Categoria {CategoriaID = 2, Descricao = "Higiene" },
                new Categoria {CategoriaID = 3, Descricao = "Frutas" },
                new Categoria {CategoriaID = 4, Descricao = "Verduras" },
                new Categoria {CategoriaID = 5, Descricao = "Carne" },
                new Categoria {CategoriaID = 6, Descricao = "Alimento" }
            };

            categorias.ForEach(c => context.Categorias.Add(c));
            context.SaveChanges();
            #endregion

            #region niveis de servico
            var niveis = new List<NivelServico>
            {
                new NivelServico {NivelServicoID  = 1, Nivel = 50, Fator = 0},
                new NivelServico {NivelServicoID  = 2, Nivel = 60, Fator = 0.2540},
                new NivelServico {NivelServicoID  = 3, Nivel = 70, Fator = 0.5250},
                new NivelServico {NivelServicoID  = 4, Nivel = 80, Fator = 0.8420},
                new NivelServico {NivelServicoID  = 5, Nivel = 85, Fator = 1.0370},
                new NivelServico {NivelServicoID  = 6, Nivel = 90, Fator = 1.2820},
                new NivelServico {NivelServicoID  = 7, Nivel = 95, Fator = 1.6450},
                new NivelServico {NivelServicoID  = 8, Nivel = 96, Fator = 1.7510},
                new NivelServico {NivelServicoID  = 9, Nivel = 97, Fator = 1.8800},
                new NivelServico {NivelServicoID  = 10, Nivel = 98, Fator = 2.0550},
                new NivelServico {NivelServicoID  = 11, Nivel = 99, Fator = 2.3250},
                new NivelServico {NivelServicoID  = 12, Nivel = 99.90, Fator = 3.1000},
                new NivelServico {NivelServicoID  = 13, Nivel = 99.99, Fator = 3.6200},
            };
            niveis.ForEach(n => context.NivelServicos.Add(n));
            context.SaveChanges();
            #endregion

            #region tipos de transacoes
            var tpTrans = new List<TpTransacao>
            {
                new TpTransacao { TpTransacaoID = 1, Descricao = "Entrada" },
                new TpTransacao { TpTransacaoID = 2, Descricao = "Saida" }
            };
            tpTrans.ForEach(t => context.TpTransacaos.Add(t));
            context.SaveChanges();
            #endregion

        }
    }
}