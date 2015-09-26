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
    public class CategoriasController : Controller
    {

        private CategoriaDb categoriaDb = new CategoriaDb();

        // GET: Categorias
        public ActionResult Index()
        {
            var categorias = categoriaDb.obterTodasCategorias();
            foreach (Categoria c in categorias)
            {
                if (c.Produtos != null && c.Produtos.Count > 0)
                {
                    c.PermitirExclusao = false;
                }
                else
                {
                    c.PermitirExclusao = true;
                }
            }
            return View(categorias);
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = categoriaDb.obterCategoria(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoriaID,Descricao")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoriaDb.salvarCategoria(categoria);
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = categoriaDb.obterCategoria(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoriaID,Descricao")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoriaDb.editarCategoria(categoria);
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = categoriaDb.obterCategoria(id);
            ViewBag.permitirExclusao = permitirExclusao(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (permitirExclusao(id))
            {
                categoriaDb.removerCategoria(id);
            }
            return RedirectToAction("Index");
        }
        
        private bool permitirExclusao(int? id)
        {
            Categoria categoria = categoriaDb.obterCategoria(id);
            if (categoria.Produtos != null && categoria.Produtos.Count > 0)
            {
                return false;
            }
            return true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                categoriaDb.dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult VerificarStatus(int idSelecionado)
        {
            try
            {
                return Json(this.permitirExclusao(idSelecionado), JsonRequestBehavior.AllowGet);
            }catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }
    }
}
