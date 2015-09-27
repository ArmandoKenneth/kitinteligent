using KitInteligente.Models;
using KitInteligente.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace KitInteligente.Data
{
    public class TransacaoDb :KitDb
    {
        public ICollection<Transacao> obterTodasTransacoes()
        {
            try
            {
                return context.Transacaos.Include(t => t.TpTransacao).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ICollection<Transacao> obterTodasTransacoes(int id)
        {
            try
            {
                var tprod = context.TransProds.Find(9);
                return context.Transacaos
                    .Include(t => t.TransProd)
                    .Where(t=>t.TpTransacaoID== id)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICollection<Transacao> obterTransacoesEntrada()
        {
            try
            {
                return this.obterTodasTransacoes((int)TiposTransacoes.ENTRADA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICollection<Transacao> obterTransacoesEntrada(DateTime inicio, DateTime fim)
        {
            try
            {
                return this.obterTodasTransacoes((int)TiposTransacoes.ENTRADA)
                    .Where(t => (t.Horario >= inicio) && (t.Horario <= fim)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICollection<TpTransacao> obterTpTransacoes()
        {
            try
            {
                return context.TpTransacaos.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void salvarTransacao(Transacao t)
        {
            try
            {
                context.Transacaos.Add(t);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TransProd obterTransProd(int id, double custo)
        {
            try
            {
                return context.TransProds.Where(t => (t.ProdutoID == id) && (t.Custo == custo)).FirstOrDefault();
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public TransProd obterTransProd(int id)
        {
            try
            {
                return context.TransProds.Where(t => t.TransProdID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void salvarTransProd(TransProd tp)
        {
            try
            {
                context.TransProds.Add(tp);
                context.SaveChanges();

                Produto p = context.Produtos.Find(tp.ProdutoID);
                p.estoqueTotal += tp.QtdEstoque;
                context.Entry(p).State = EntityState.Modified;
                context.SaveChanges();
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public void removerTransProd(int id)
        {
            try
            {
                context.TransProds.Remove(obterTransProd(id));
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}