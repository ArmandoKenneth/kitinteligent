using KitInteligente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using KitInteligente.Utils;

namespace KitInteligente.Data
{
    public class ProdutoDb : KitDb
    {
        public int obterUltimoCodigo()
        {
            int id = 0;
            try
            {
                var produtos = context.Produtos.ToList().OrderBy(p => p.ProdutoID);
                if (produtos.Count() > 0)
                {
                    id = produtos.Last().ProdutoID + 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
        }

        public ICollection<Produto> obterTodosProdutos()
        {
            try
            {
                return context.Produtos.Include(p => p.CalcEstoqueSeg).Include(p => p.Categoria).ToList<Produto>();
            }
            catch (Exception ex) {
                
            }
            return null;
            
        }

        public Produto obterProduto(int? id)
        {

            try
            {
                return context.Produtos.Find(id);
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public ICollection<CalcEstoqueSeg> obterCalcEstoqueSegs()
        {
            try
            {
                return context.CalcEstoqueSegs.ToList();
            }catch (Exception ex)
            {

            }
            return null;
        }

        private List<Demanda> gerarDemandasPadrao(int id)
        {

            var demandas = new List<Demanda>
            {
                new Demanda {CalcEstoqueSegID = id, Periodo = 1, Valor = 0 },
                new Demanda {CalcEstoqueSegID = id, Periodo = 2, Valor = 0 },
                new Demanda {CalcEstoqueSegID = id, Periodo = 3, Valor = 0 },
                new Demanda {CalcEstoqueSegID = id, Periodo = 4, Valor = 0 },
                new Demanda {CalcEstoqueSegID = id, Periodo = 5, Valor = 0 },
                new Demanda {CalcEstoqueSegID = id, Periodo = 6, Valor = 0 },
                new Demanda {CalcEstoqueSegID = id, Periodo = 7, Valor = 0 },
                new Demanda {CalcEstoqueSegID = id, Periodo = 8, Valor = 0 },
                new Demanda {CalcEstoqueSegID = id, Periodo = 9, Valor = 0 },
                new Demanda {CalcEstoqueSegID = id, Periodo = 10, Valor = 0 }
            };
            return demandas;
        }

        public void salvarProduto(Produto p)
        {
            try
            {
                
                // Criar calc_estoque_seg
                CalcEstoqueSeg c = new CalcEstoqueSeg();
                context.CalcEstoqueSegs.Add(c);
                context.SaveChanges();

                // criar demandas 
                // db.Entry(MyNewObject).GetDatabaseValues();
                var demandas = gerarDemandasPadrao(c.CalcEstoqueSegID);
                demandas.ForEach(d => context.Demandas.Add(d));
                context.SaveChanges();

                p.CalcEstoqueSegID = c.CalcEstoqueSegID;


                // Criar uma transacap de entrada
                /*Transacao t = new Transacao();
                t.QtdTransacao = 0;
                t.CustoUn = 0;
                t.CustoTotal = 0;
                // t.UsuarioID
                t.Horario = DateTime.Now;
                t.TpTransacaoID = (int) TiposTransacoes.ENTRADA;

                // Criar trans_prod
                TransProd tp = new TransProd();*/


                context.Produtos.Add(p);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void editarProduto(Produto p)
        {
            try
            {
                context.Entry(p).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        public void removerProduto(int id)
        {
            try
            {
                context.Produtos.Remove(obterProduto(id));
                context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

       
    }
}