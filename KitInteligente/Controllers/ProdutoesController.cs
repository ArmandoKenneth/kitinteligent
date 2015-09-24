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

namespace KitInteligente.Controllers
{
    public class ProdutoesController : Controller
    {
        private ProdutoDb produtoDb = new ProdutoDb();
        private CategoriaDb categoriaDb = new CategoriaDb();

        // GET: Produtoes
        public ActionResult Index()
        {
            var produtos = produtoDb.obterTodosProdutos();
            return View(produtos);
        }

        // GET: Produtoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = produtoDb.obterProduto(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtoes/Create
        public ActionResult Create()
        {
            ViewBag.CalcEstoqueSegID = new SelectList(produtoDb.obterCalcEstoqueSegs(), "CalcEstoqueSegID", "CalcEstoqueSegID");
            ViewBag.CategoriaID = new SelectList(categoriaDb.obterTodasCategorias(), "CategoriaID", "Descricao");
            Produto model = new Produto();
            model.Codigo = produtoDb.obterUltimoCodigo() + 1;
            return View(model);
        }

        // POST: Produtoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutoID,Codigo,Descricao,QtdEstSeg,CategoriaID,CalcEstoqueSegID")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                
                produtoDb.salvarProduto(produto);
                return RedirectToAction("Index");
            }

            ViewBag.CalcEstoqueSegID = new SelectList(produtoDb.obterCalcEstoqueSegs(), "CalcEstoqueSegID", "CalcEstoqueSegID", produto.CalcEstoqueSegID);
            ViewBag.CategoriaID = new SelectList(categoriaDb.obterTodasCategorias(), "CategoriaID", "Descricao", produto.CategoriaID);
            return View(produto);
        }

        // GET: Produtoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = produtoDb.obterProduto(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CalcEstoqueSegID = new SelectList(produtoDb.obterCalcEstoqueSegs(), "CalcEstoqueSegID", "CalcEstoqueSegID", produto.CalcEstoqueSegID);
            ViewBag.CategoriaID = new SelectList(categoriaDb.obterTodasCategorias(), "CategoriaID", "Descricao", produto.CategoriaID);
            return View(produto);
        }

        // POST: Produtoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutoID,Codigo,Descricao,QtdEstSeg,CategoriaID,CalcEstoqueSegID")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                produtoDb.editarProduto(produto);
                return RedirectToAction("Index");
            }
            ViewBag.CalcEstoqueSegID = new SelectList(produtoDb.obterCalcEstoqueSegs(), "CalcEstoqueSegID", "CalcEstoqueSegID", produto.CalcEstoqueSegID);
            ViewBag.CategoriaID = new SelectList(categoriaDb.obterTodasCategorias(), "CategoriaID", "Descricao", produto.CategoriaID);
            return View(produto);
        }

        // GET: Produtoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = produtoDb.obterProduto(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            produtoDb.removerProduto(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                produtoDb.dispose();
            }
            base.Dispose(disposing);
        }
    }
}
