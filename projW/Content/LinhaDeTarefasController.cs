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

namespace projW.Content
{
    public class LinhaDeTarefasController : Controller
    {
        private Sepulveda_DbGesTarefas db = new Sepulveda_DbGesTarefas();

        // GET: LinhaDeTarefas
        public ActionResult Index()
        {
            var tLinhasDeTarefas = db.TLinhasDeTarefas.Include(l => l.Tarefa);
            return View(tLinhasDeTarefas.ToList());
        }

        // GET: LinhaDeTarefas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LinhaDeTarefa linhaDeTarefa = db.TLinhasDeTarefas.Find(id);
            if (linhaDeTarefa == null)
            {
                return HttpNotFound();
            }
            return View(linhaDeTarefa);
        }

        // GET: LinhaDeTarefas/Create
        public ActionResult Create()
        {
            ViewBag.TarefaId = new SelectList(db.TTarefas, "Id", "Titulo");
            return View();
        }

        // POST: LinhaDeTarefas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TarefaId,DataDaLinha,Descritivo")] LinhaDeTarefa linhaDeTarefa)
        {
            if (ModelState.IsValid)
            {
                db.TLinhasDeTarefas.Add(linhaDeTarefa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TarefaId = new SelectList(db.TTarefas, "Id", "Titulo", linhaDeTarefa.TarefaId);
            return View(linhaDeTarefa);
        }

        // GET: LinhaDeTarefas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LinhaDeTarefa linhaDeTarefa = db.TLinhasDeTarefas.Find(id);
            if (linhaDeTarefa == null)
            {
                return HttpNotFound();
            }
            ViewBag.TarefaId = new SelectList(db.TTarefas, "Id", "Titulo", linhaDeTarefa.TarefaId);
            return View(linhaDeTarefa);
        }

        // POST: LinhaDeTarefas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TarefaId,DataDaLinha,Descritivo")] LinhaDeTarefa linhaDeTarefa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(linhaDeTarefa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TarefaId = new SelectList(db.TTarefas, "Id", "Titulo", linhaDeTarefa.TarefaId);
            return View(linhaDeTarefa);
        }

        // GET: LinhaDeTarefas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LinhaDeTarefa linhaDeTarefa = db.TLinhasDeTarefas.Find(id);
            if (linhaDeTarefa == null)
            {
                return HttpNotFound();
            }
            return View(linhaDeTarefa);
        }

        // POST: LinhaDeTarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LinhaDeTarefa linhaDeTarefa = db.TLinhasDeTarefas.Find(id);
            db.TLinhasDeTarefas.Remove(linhaDeTarefa);
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
