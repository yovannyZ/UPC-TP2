using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using TP2.Datos.EF;
using TP2.Entidades.EF;

namespace TP2.Negocio
{
    public class TGUQReservaSalaOperacion
    {
        protected static readonly ILog log = LogManager.GetLogger("Reservas");

        public static List<T_GUQ_RESERVA_SALA_OPERACIÓN> ListarTodos()
        {
            RicardoPalmaEntities db = new RicardoPalmaEntities();
            return db.T_GUQ_RESERVA_SALA_OPERACIÓN.ToList();
        }

        public static List<string> ListarHorarios(string fecha, int inmueble, int tipo)
        {
            List<String> horario = new List<string>();
            TimeSpan result;
            string timeString;
            DateTime nuevaFecha = Convert.ToDateTime(fecha);
            if (nuevaFecha.CompareTo(new DateTime(1900, 1, 1)) == 0)
                return horario;

            try
            {
                RicardoPalmaEntities db = new RicardoPalmaEntities();
                var tipoOperacion = db.T_GUQ_TIPO_OPERACIÓN.Find(tipo);
                if (tipoOperacion == null)
                    return horario;
                List<T_GUQ_RESERVA_SALA_OPERACIÓN> reservas = new List<T_GUQ_RESERVA_SALA_OPERACIÓN>(); ;
                DateTime fechaInicio;
                DateTime fechaFin;
                for (int i = 0; i < 24; i++)
                {
                    fechaInicio = nuevaFecha.AddHours(i);
                    fechaInicio = fechaInicio.AddHours((Convert.ToInt32(tipoOperacion.duracion) - 1) * -1);
                    fechaFin = nuevaFecha.AddHours(i);
                    fechaFin = fechaFin.AddHours(Convert.ToInt32(tipoOperacion.duracion) - 1);
                    reservas = db.T_GUQ_RESERVA_SALA_OPERACIÓN.Where(x => x.idInmueble == inmueble && x.fechaInicio >= fechaInicio && x.fechaInicio <= fechaFin).ToList();

                    if (reservas == null || reservas.Count == 0)
                    {
                        result = TimeSpan.FromHours(i);
                        timeString = result.ToString("hh':'mm");
                        horario.Add(timeString);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error al consultar los horarios", ex);
            }

            return horario;
        }

        public static List<T_GG_EMPLEADO> ListarMedicos(int tipoOperacion, DateTime fecha, int hora)
        {
            List<T_GG_EMPLEADO> lista = new List<T_GG_EMPLEADO>();
            DateTime nuevaFecha = Convert.ToDateTime(fecha);
            if (nuevaFecha.CompareTo(new DateTime(1900, 1, 1)) == 0)
                return lista;
            try
            {
                RicardoPalmaEntities db = new RicardoPalmaEntities();
                var tipo = db.T_GUQ_TIPO_OPERACIÓN.Find(tipoOperacion);
                DateTime fechaInicio;
                DateTime fechaFin;
                fechaInicio = fecha.AddHours(hora);
                fechaInicio = fechaInicio.AddHours((Convert.ToInt32(tipo.duracion) - 1) * -1);
                fechaFin = nuevaFecha.AddHours(hora);
                fechaFin = fechaFin.AddHours(Convert.ToInt32(tipo.duracion) - 1);

                var listaEspecialidad = db.T_GDA_ESPECIALIDAD__MEDICA.Where(x => x.idOperacion == tipoOperacion).ToList();
                var listaEmpleados = db.T_GG_EMPLEADO.ToList();
                listaEmpleados = listaEmpleados.Where(x => listaEspecialidad.Any(y => y.idEspecialidad == x.idEspecialidad)).ToList();

                var reservas = db.T_GUQ_RESERVA_SALA_OPERACIÓN.Where(x => x.fechaInicio >= fechaInicio && x.fechaInicio <= fechaFin).ToList();

                lista = listaEmpleados.Where(x => !reservas.Any(y => y.idEmpleado == x.idEmpleado)).ToList();
            }
            catch (Exception ex)
            {
                log.Error("Error al consultar los médicos", ex);
            }

            return lista;
        }

        public static List<T_GDA_PACIENTE> ListarPacientes(int tipoOperacion, DateTime fecha, int hora)
        {
            List<T_GDA_PACIENTE> lista = new List<T_GDA_PACIENTE>();
            DateTime nuevaFecha = Convert.ToDateTime(fecha);
            if (nuevaFecha.CompareTo(new DateTime(1900, 1, 1)) == 0)
                return lista;
            try
            {
                RicardoPalmaEntities db = new RicardoPalmaEntities();
                var tipo = db.T_GUQ_TIPO_OPERACIÓN.Find(tipoOperacion);
                DateTime fechaInicio;
                DateTime fechaFin;
                fechaInicio = fecha.AddHours(hora);
                fechaInicio = fechaInicio.AddHours((Convert.ToInt32(tipo.duracion) - 1) * -1);
                fechaFin = nuevaFecha.AddHours(hora);
                fechaFin = fechaFin.AddHours(Convert.ToInt32(tipo.duracion) - 1);

                var listaEmpleados = db.T_GDA_PACIENTE.ToList();
                var reservas = db.T_GUQ_RESERVA_SALA_OPERACIÓN.Where(x => x.fechaInicio >= fechaInicio && x.fechaInicio <= fechaFin).ToList();

                lista = listaEmpleados.Where(x => !reservas.Any(y => y.idPaciente == x.idPaciente)).ToList();
            }
            catch (Exception ex)
            {
                log.Error("Error al consultar los pacientes", ex);
            }

            return lista;
        }

        public static bool Crear(T_GUQ_RESERVA_SALA_OPERACIÓN reserva)
        {
            bool exito = false;
            try
            {
                RicardoPalmaEntities db = new RicardoPalmaEntities();
                db.T_GUQ_RESERVA_SALA_OPERACIÓN.Add(reserva);
                db.SaveChanges();
                exito = true;
            }
            catch (Exception ex)
            {
                exito = false;
                Bitacora.CrearLog("Error al crear la reserva", TipoLog.Error, ex);
            }
            return exito;
        }
    }
}
