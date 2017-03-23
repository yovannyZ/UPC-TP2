using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP2.Negocio;

using TP2.Entidades.EF;

namespace TP2.Web.Controllers
{
    public class PacienteEstadoController : Controller
    {
        // GET: PacienteEstado
        public ActionResult Index()
        {
            var listado = TGDAIngresoUCI.ListarTodos();
            return View(listado);
        }


        public ActionResult Aprobar(int id)
        {
            var ingreso = TGDAIngresoUCI.Obtener(id);
            return View(ingreso);
        }

        [HttpPost]
        public string Aprobar(T_GDA_INGRESOUCI IngresoUCI)
        {
            string mensaje = "Error al grabar los datos";

            bool esValido = TGDAIngresoUCI.Editar(IngresoUCI);

            if (esValido)
            {
                mensaje = "Datos grabadas y notificaciones enviadas";
            }
            return mensaje;

        }

        public ActionResult Desaprobar(int id)
        {
            var ingreso = TGDAIngresoUCI.Obtener(id);
            return View(ingreso);
        }

        [HttpPost]
        public string Desaprobar(T_GDA_INGRESOUCI IngresoUCI)
        {
            string mensaje = "Error al grabar los datos";

            bool esValido = TGDAIngresoUCI.Editar(IngresoUCI);

            if (esValido)
            {
                mensaje = "Datos grabadas y notificaciones enviadas";
            }
            return mensaje;

        }

    }
}