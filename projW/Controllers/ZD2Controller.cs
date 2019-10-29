using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projW.DAL;
using projW.Models;


namespace projW.Controllers
{
    public class ZD2Controller : Controller
    {

        private Sepulveda_DbGesTarefas db = new Sepulveda_DbGesTarefas();

        // GET: ZD2
        public ActionResult Index(int? idTarefa)
        {
            Tarefa registo = new Tarefa();
            registo = null;
            var tTarefas = db.TTarefas.ToList();
            ViewBag.TAREFA = null;
            ViewBag.REGISTOENCONTRADO = false;
            ViewBag.PEDECONFIRMACAO = false;



            if (idTarefa.HasValue)
            {
                ViewBag.TAREFA = idTarefa;
                registo = db.TTarefas.Find(idTarefa);

                ViewBag.PEDECONFIRMACAO = true;
            }

            if (registo != null)
            {
                ViewBag.REGISTOENCONTRADO = true;
            }



                //    if (registo == null)
                //    {
                //        ViewBag.ELIMINADA = "Registo inexistente.";
                //    }
                //    else
                //    {
                //        db.TTarefas.Remove(registo);
                //        db.SaveChanges();
                //        ViewBag.ELIMINADA = "Registo eliminado.";
                //    }
                //}

                return View(registo);
        }
    }
}