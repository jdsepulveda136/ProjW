using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projW.DAL;
using projW.Models;

namespace projW.Controllers
{
    public class ZD1Controller : Controller
    {
        private Sepulveda_DbGesTarefas db = new Sepulveda_DbGesTarefas();

        // GET: ZD1
        public ActionResult Index(int? idTarefa)
        {
            Tarefa registo = new Tarefa();
            var tTarefas = db.TTarefas.ToList();
            ViewBag.TAREFA = idTarefa;

            if (!idTarefa.HasValue)
            {
                ViewBag.TAREFA = "Tarefa não existe.";
            }else
            {
                registo = db.TTarefas.Find(idTarefa);

                if (registo == null)
                {
                    ViewBag.ELIMINADA = "Registo inexistente.";
                }
                else
                {
                    db.TTarefas.Remove(registo);
                    db.SaveChanges();
                    ViewBag.ELIMINADA = "Registo eliminado.";
                }
            }


            return View();
        }
    }
}