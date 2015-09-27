using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KitInteligente.Db;
using KitInteligente.Models;
using KitInteligente.Data;
using PagedList;
using KitInteligente.ViewModel;
using KitInteligente.Utils;

namespace KitInteligente.Controllers
{
    public class EntradaController : Controller
    {
        private TransacaoDb transacaoDb = new TransacaoDb();
        private ProdutoDb produtoDb = new ProdutoDb();

        // GET: Entrada
        public ActionResult Index(string dataInicial, string dataFinal, int? pagina)
        {
            if (dataInicial != null && dataFinal != null)
            {
                pagina = 1;
            }
            if (pagina == null)
                pagina = 1;

            ICollection<Transacao> transacoes;
            if (!String.IsNullOrEmpty(dataInicial) && !String.IsNullOrEmpty(dataFinal))
            {
                transacoes = transacaoDb.obterTransacoesEntrada(DateTime.Parse(dataInicial), DateTime.Parse(dataFinal));
            }
            else
            {
                transacoes = transacaoDb.obterTransacoesEntrada();
            }


            //var transacoes = transacaoDb.obterTransacoesEntrada();
            int pageSize = 3;
            int pageNumber = (pagina ?? 1);
            return View(transacoes.ToPagedList(pageNumber, pageSize));
            //return View(transacaos);
        }

        // GET: Entrada/Details/5
        /*public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacao transacao = db.Transacaos.Find(id);
            if (transacao == null)
            {
                return HttpNotFound();
            }
            return View(transacao);
        }*/

        // GET: Entrada/Create
        public ActionResult Create()
        {
            ViewBag.TpTransacaoID = new SelectList(transacaoDb.obterTpTransacoes(), "TpTransacaoID", "Descricao");
            return View();
        }

        // POST: Entrada/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Qtd,Custo,DataEntrada,ProdutoID")] TransacaoEntrada transacao)
        {
            TransProd tp = new TransProd();
            try
            {
                if (ModelState.IsValid)
                {
                    // adicionar transprodid
                   

                    tp = transacaoDb.obterTransProd(transacao.ProdutoID, transacao.Custo);
                    if (tp == null)
                        tp = new TransProd();
                    Transacao t = new Transacao();
                    t.CustoUn = transacao.Custo;
                    t.QtdTransacao = transacao.Qtd;
                    t.CustoTotal = t.CustoUn * t.QtdTransacao;
                    t.Horario = transacao.DataEntrada;
                    t.TpTransacaoID = (int)TiposTransacoes.ENTRADA;

                    tp.QtdEstoque += t.QtdTransacao;
                    tp.ProdutoID = transacao.ProdutoID;

                    transacaoDb.salvarTransProd(tp);

                    t.TransProdID = tp.TransProdID;

                    transacaoDb.salvarTransacao(t);

                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                transacaoDb.removerTransProd(tp.TransProdID);
                throw ex;
            }
            return RedirectToAction("Index");
            //return PartialView("_NovaTransacao");
            //return View(transacao);
        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                transacaoDb.dispose();
            }
            base.Dispose(disposing);
        }
        
        public ActionResult _NovaTransacao(int? id)
        {
            try
            {
                if (id != null && id != 0)
                {
                    TransacaoEntrada t = new TransacaoEntrada();
                    t.Produto = produtoDb.obterProduto(id);
                    t.ProdutoID = t.Produto.ProdutoID;
                    return PartialView("_NovaTransacao", t);
                }
                return RedirectToAction("Index");
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult _DetalhesProduto(int id)
        {
            try
            {
                Produto p = produtoDb.obterProduto(id);
                return PartialView("_DetalhesProduto", p);
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult _PesquisaProduto(string stringPesquisa, string filtroAtual, int? pagina)
        {
            try
            {
                if (stringPesquisa != null)
                {
                    pagina = 1;
                }
                else
                {
                    stringPesquisa = filtroAtual;
                }

                ViewBag.FiltroAtual = stringPesquisa;
                ICollection<Produto> produtos;
                if (!String.IsNullOrEmpty(stringPesquisa))
                {
                    produtos = produtoDb.obterProdutos(stringPesquisa);
                }
                else
                {
                    produtos = produtoDb.obterTodosProdutos();
                }
                int pageSize = 1;
                int pageNumber = (pagina ?? 1);
                return PartialView("_PesquisaProduto",produtos.ToPagedList(pageNumber, pageSize));
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
