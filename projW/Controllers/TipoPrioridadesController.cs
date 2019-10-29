using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using projW.DAL;
using projW.Models;

namespace projW.Controllers
{
    public class TipoPrioridadesController : Controller
    {
        private Sepulveda_DbGesTarefas db = new Sepulveda_DbGesTarefas();

        // GET: TipoPrioridades
        public ActionResult Index()
        {
            return View(db.TTipoPrioridades.ToList());
        }

        // GET: TipoPrioridades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPrioridade tipoPrioridade = db.TTipoPrioridades.Find(id);
            if (tipoPrioridade == null)
            {
                return HttpNotFound();
            }
            return View(tipoPrioridade);
        }

        // GET: TipoPrioridades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPrioridades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DesignacaoPrioridade")] TipoPrioridade tipoPrioridade)
        {
            if (ModelState.IsValid)
            {
                db.TTipoPrioridades.Add(tipoPrioridade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoPrioridade);
        }

        // GET: TipoPrioridades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPrioridade tipoPrioridade = db.TTipoPrioridades.Find(id);
            if (tipoPrioridade == null)
            {
                return HttpNotFound();
            }
            return View(tipoPrioridade);
        }

        // POST: TipoPrioridades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DesignacaoPrioridade")] TipoPrioridade tipoPrioridade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoPrioridade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoPrioridade);
        }

        // GET: TipoPrioridades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPrioridade tipoPrioridade = db.TTipoPrioridades.Find(id);
            if (tipoPrioridade == null)
            {
                return HttpNotFound();
            }
            return View(tipoPrioridade);
        }

        // POST: TipoPrioridades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoPrioridade tipoPrioridade = db.TTipoPrioridades.Find(id);
            db.TTipoPrioridades.Remove(tipoPrioridade);
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
