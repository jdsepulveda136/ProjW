using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projW.MyUtil;

namespace projW.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            TarefasFuncs tarefa = new TarefasFuncs();

            ViewBag.HORA = DateTime.Now.ToString("HH:mm");
            ViewBag.SAUDACAO = tarefa.BomDia();

            return View();
        }
    }
}