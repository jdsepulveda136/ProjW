using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projW.MyUtil;

namespace projW.Controllers
{
    public class ZFController : Controller
    {

        // GET: ZF
        public ActionResult Index()
        {
            ViewBag.TAREFAS = 0;
            ViewBag.CLIENTES = 0;
            ViewBag.FUNCIONARIOS = 0;

            StringConnection ligabd = new StringConnection();
            string str_conn = "Data Source = 89.154.2.41,62444; Initial Catalog = SepulvedaDbGesTarefas; User ID = sepulveda; Password = 123.abc; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            string query_tarefas = "select count(*) from Tarefas";
            string query_clientes = "select count(*) from Clientes";
            string query_funcionarios = "select count(*) from Funcionarios";

            DataTable dados_tarefas = ligabd.BuscaDados(str_conn, query_tarefas);
            DataTable dados_clientes = ligabd.BuscaDados(str_conn, query_clientes);
            DataTable dados_funcionarios = ligabd.BuscaDados(str_conn, query_funcionarios);

            ViewBag.TAREFAS = dados_tarefas.Rows[0][0];
            ViewBag.CLIENTES = dados_clientes.Rows[0][0];
            ViewBag.FUNCIONARIOS = dados_funcionarios.Rows[0][0];

            return View();
        }
    }
}