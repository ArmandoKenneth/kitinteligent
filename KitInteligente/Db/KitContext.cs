using KitInteligente.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace KitInteligente.Db
{
    public class KitContext : DbContext
    {
        public KitContext() : base("KitContext")
        {

        }

        public DbSet<CalcEstoqueSeg> CalcEstoqueSegs { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Demanda> Demandas { get; set; }
        public DbSet<NivelServico> NivelServicos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TpTransacao> TpTransacaos { get; set; }
        public DbSet<Transacao> Transacaos { get; set; }
        public DbSet<TransProd> TransProds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}