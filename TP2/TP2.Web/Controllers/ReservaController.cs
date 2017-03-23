using System;
using System.Web.Mvc;
using System.Linq;
using TP2.Entidades.EF;
using TP2.Negocio;

namespace TP2.Web.Controllers
{
    public class ReservaController : Controller
    {
        // GET: Reserva

        public ActionResult Index()
        {
            var listado = TGUQReservaSalaOperacion.ListarTodos();
            return View(listado);
        }

        public ActionResult Create()
        {
            var tipoOperacionList = TGUQTipoOperacion.ListarTodos();
            ViewBag.TipoOperacionList = tipoOperacionList;

            var pacienteList = TGDAPaciente.ListarTodos();
            ViewBag.PacienteList = pacienteList;

            return View();
        }

        public ActionResult MedicoPartial(int tipo, string fecha, string hora)
        {
            hora = hora.Substring(0, 2);
            var nuevaHora = int.Parse(hora);
            var nuevaFecha = DateTime.Parse(fecha);

            var empleadoList = TGUQReservaSalaOperacion.ListarMedicos(tipo, nuevaFecha, nuevaHora);
            return PartialView("_ReservaMedico", empleadoList);
        }

        public ActionResult HorarioPartial(string fecha, int inmueble, int tipo)
        {
            var salaList = TGUQReservaSalaOperacion.ListarHorarios(fecha, inmueble, tipo);
            return PartialView("_ReservaSala", salaList);
        }

        public ActionResult PacientePartial(int tipo, string fecha, string hora)
        {
            hora = hora.Substring(0, 2);
            var nuevaHora = int.Parse(hora);
            var nuevaFecha = DateTime.Parse(fecha);
            var pacienteList = TGUQReservaSalaOperacion.ListarPacientes(tipo, nuevaFecha, nuevaHora);

            return PartialView("_Paciente", pacienteList);
        }

        public ActionResult ObtenerSalas(int tipo)
        {
            var lista = TGGInmueble.ListarDisponibles(tipo).Select(p => new { Id = p.idInmueble, Nombre = p.dscTipoInmueble }).ToList();
            return Json(lista, JsonRequestBehavior.AllowGet);

        }

        public int ObtenerDuracion(int tipo)
        {
            int duracion = 0;
            var tipoOperacion = TGUQTipoOperacion.Obtener(tipo);
            if (tipoOperacion != null && tipoOperacion.duracion.HasValue)
                duracion = tipoOperacion.duracion.Value;
            return duracion;

        }

        [HttpPost]
        public string Create(T_GUQ_RESERVA_SALA_OPERACIÓN reserva, string horaInicio)
        {
            horaInicio = horaInicio.Substring(0, 2);
            var nuevaHora = int.Parse(horaInicio);
            reserva.fechaInicio = reserva.fechaInicio.AddHours(nuevaHora);
            reserva.fechaFin = reserva.fechaInicio.AddHours(reserva.duración);

            string mensaje = "Error al grabar los datos";
            bool exito = TGUQReservaSalaOperacion.Crear(reserva);
            if (exito)
                mensaje = "Los datos se grabaron con exito";
            return mensaje;
        }
    }
}