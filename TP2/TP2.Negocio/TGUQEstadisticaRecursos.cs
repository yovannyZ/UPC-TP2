using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Datos.EF;

namespace TP2.Negocio
{
    public class TGUQEstadisticaRecursos
    {
        public static double ObtenerPromedio(int anio, int partida, int area)
        {
            RicardoPalmaEntities db = new RicardoPalmaEntities();
            double monto = 0.00;
            double promedio = 0.00;
            
            var listaMontos = db.T_GUQ_ESTADÍSTICA_RECURSOS.Where(c => c.idPartida == partida)
                                           .Where(c => c.anio < anio)
                                           .Where(c => c.anio >= anio-3)
                                           .Where(c => c.idArea == area).Select(c => c.montoHistórico).ToList();

            if (listaMontos.Count != 0)
            {
                for (int i = 0; i < listaMontos.Count; i++)
                {
                    monto = monto + listaMontos[i];
                }
                promedio = monto / 3;
            }

           

            return  Math.Round(promedio,2);
        }
    }
}
