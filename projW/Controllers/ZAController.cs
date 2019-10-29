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
    public class ZAController : Controller
    {
        private Sepulveda_DbGesTarefas db = new Sepulveda_DbGesTarefas();
        private IQueryable<Tarefa> tTarefas;

        // GET: ZA
        public ActionResult Index(int? id){

   
            var tTarefas = db.TTarefas.Include(t => t.Cliente).Include(t => t.Funcionario).Include(t => t.TipoPrioridade).Include(t => t.TipoTarefa);
            ViewBag.ID = "nulo";

            if (id.HasValue)
            {
                tTarefas = db.TTarefas.Where(t => t.ClienteId == id);
                ViewBag.ID = id;
            }

            ViewBag.LINHAS = tTarefas.Count();

            List<Cliente> tclientes = db.TClientes.ToList();
            SelectList lista_clientes = new SelectList(tclientes, "Id", "NomeCliente");
            ViewBag.CLIENTES = lista_clientes;


            return View(tTarefas.ToList());
        }

        // GET: ZA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefa tarefa = db.TTarefas.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }

        // GET: ZA/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.TClientes, "Id", "NomeCliente");
            ViewBag.FuncionarioId = new SelectList(db.TFuncionarios, "Id", "NomeFuncionario");
            ViewBag.TipoPrioridadeId = new SelectList(db.TTipoPrioridades, "Id", "DesignacaoPrioridade");
            ViewBag.TipoTarefaId = new SelectList(db.TTipoTarefas, "Id", "DesignacaoTipoTarefa");
            return View();
        }

        // POST: ZA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,DescritivoTarefa,TipoTarefaId,ClienteId,FuncionarioId,Equipa,DataRegisto,DataLimite,SujeitaCoima,TipoPrioridadeId,Estado")] Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                db.TTarefas.Add(tarefa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.TClientes, "Id", "NomeCliente", tarefa.ClienteId);
            ViewBag.FuncionarioId = new SelectList(db.TFuncionarios, "Id", "NomeFuncionario", tarefa.FuncionarioId);
            ViewBag.TipoPrioridadeId = new SelectList(db.TTipoPrioridades, "Id", "DesignacaoPrioridade", tarefa.TipoPrioridadeId);
            ViewBag.TipoTarefaId = new SelectList(db.TTipoTarefas, "Id", "DesignacaoTipoTarefa", tarefa.TipoTarefaId);
            return View(tarefa);
        }

        // GET: ZA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefa tarefa = db.TTarefas.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.TClientes, "Id", "NomeCliente", tarefa.ClienteId);
            ViewBag.FuncionarioId = new SelectList(db.TFuncionarios, "Id", "NomeFuncionario", tarefa.FuncionarioId);
            ViewBag.TipoPrioridadeId = new SelectList(db.TTipoPrioridades, "Id", "DesignacaoPrioridade", tarefa.TipoPrioridadeId);
            ViewBag.TipoTarefaId = new SelectList(db.TTipoTarefas, "Id", "DesignacaoTipoTarefa", tarefa.TipoTarefaId);
            return View(tarefa);
        }

        // POST: ZA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,DescritivoTarefa,TipoTarefaId,ClienteId,FuncionarioId,Equipa,DataRegisto,DataLimite,SujeitaCoima,TipoPrioridadeId,Estado")] Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarefa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.TClientes, "Id", "NomeCliente", tarefa.ClienteId);
            ViewBag.FuncionarioId = new SelectList(db.TFuncionarios, "Id", "NomeFuncionario", tarefa.FuncionarioId);
            ViewBag.TipoPrioridadeId = new SelectList(db.TTipoPrioridades, "Id", "DesignacaoPrioridade", tarefa.TipoPrioridadeId);
            ViewBag.TipoTarefaId = new SelectList(db.TTipoTarefas, "Id", "DesignacaoTipoTarefa", tarefa.TipoTarefaId);
            return View(tarefa);
        }

        // GET: ZA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefa tarefa = db.TTarefas.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }

        // POST: ZA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarefa tarefa = db.TTarefas.Find(id);
            db.TTarefas.Remove(tarefa);
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
