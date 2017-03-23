using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP2.Negocio;

namespace TP2.Web.Controllers
{
    public class PacienteEstadoController : Controller
    {
        // GET: PacienteEstado
        public ActionResult Index()
        {
            var listado = TGUQPAcienteEstadoUCI.ListarTodos();
            return View(listado);
           
        }
    }
}