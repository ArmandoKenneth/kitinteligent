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

namespace KitInteligente.Controllers
{
    public class ProdutoesController : Controller
    {
        private KitContext db = new KitContext();

        // GET: Produtoes
        public ActionResult Index()
        {
            var produtos = db.Produtos.Include(p => p.CalcEstoqueSeg).Include(p => p.Categoria);
            return View(produtos.ToList());
        }

        // GET: Produtoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtoes/Create
        public ActionResult Create()
        {
            ViewBag.CalcEstoqueSegID = new SelectList(db.CalcEstoqueSegs, "CalcEstoqueSegID", "CalcEstoqueSegID");
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Descricao");
            int codProduto;
            if (db.Produtos.Count() > 0)
            {
                codProduto = db.Produtos.Last().Codigo + 1;
            }
            else
            {
                codProduto = 1;
            }
            ViewBag.codProduto = codProduto;

            Produto model = new Produto();
            model.Codigo = codProduto;
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
                db.Produtos.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");

                // Criar calc_estoque_seg

                // Criar uma transacap de entrada

                
                
            }

            ViewBag.CalcEstoqueSegID = new SelectList(db.CalcEstoqueSegs, "CalcEstoqueSegID", "CalcEstoqueSegID", produto.CalcEstoqueSegID);
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Descricao", produto.CategoriaID);
            return View(produto);
        }

        // GET: Produtoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CalcEstoqueSegID = new SelectList(db.CalcEstoqueSegs, "CalcEstoqueSegID", "CalcEstoqueSegID", produto.CalcEstoqueSegID);
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Descricao", produto.CategoriaID);
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
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CalcEstoqueSegID = new SelectList(db.CalcEstoqueSegs, "CalcEstoqueSegID", "CalcEstoqueSegID", produto.CalcEstoqueSegID);
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Descricao", produto.CategoriaID);
            return View(produto);
        }

        // GET: Produtoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
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
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
