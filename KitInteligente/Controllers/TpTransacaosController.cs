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
    public class TpTransacaosController : Controller
    {
        private KitContext db = new KitContext();

        // GET: TpTransacaos
        public ActionResult Index()
        {
            return View(db.TpTransacaos.ToList());
        }

        // GET: TpTransacaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TpTransacao tpTransacao = db.TpTransacaos.Find(id);
            if (tpTransacao == null)
            {
                return HttpNotFound();
            }
            return View(tpTransacao);
        }

        // GET: TpTransacaos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TpTransacaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TpTransacaoID,Descricao")] TpTransacao tpTransacao)
        {
            if (ModelState.IsValid)
            {
                db.TpTransacaos.Add(tpTransacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tpTransacao);
        }

        // GET: TpTransacaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TpTransacao tpTransacao = db.TpTransacaos.Find(id);
            if (tpTransacao == null)
            {
                return HttpNotFound();
            }
            return View(tpTransacao);
        }

        // POST: TpTransacaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TpTransacaoID,Descricao")] TpTransacao tpTransacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tpTransacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tpTransacao);
        }

        // GET: TpTransacaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TpTransacao tpTransacao = db.TpTransacaos.Find(id);
            if (tpTransacao == null)
            {
                return HttpNotFound();
            }
            return View(tpTransacao);
        }

        // POST: TpTransacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TpTransacao tpTransacao = db.TpTransacaos.Find(id);
            db.TpTransacaos.Remove(tpTransacao);
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
