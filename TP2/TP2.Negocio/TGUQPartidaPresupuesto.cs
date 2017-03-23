using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Datos.EF;
using TP2.Entidades.EF;

namespace TP2.Negocio
{
    public class TGUQPartidaPresupuesto
    {
        public static bool Crear(T_GUQ_PRESUPUESTO_PARTIDA presupuestoPartida)
        {
            bool exito = false;
            try
            {
                RicardoPalmaEntities db = new RicardoPalmaEntities();

                db.T_GUQ_PRESUPUESTO_PARTIDA.Add(presupuestoPartida);
                db.SaveChanges();
                exito = true;
            }
            catch (Exception ex)
            {
                exito = false;
                Bitacora.CrearLog("Error al crear el presupuesto", TipoLog.Error, ex);
            }
            return exito;
        }
    }
}
