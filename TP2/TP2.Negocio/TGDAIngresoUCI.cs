using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Datos.EF;
using TP2.Entidades.EF;

namespace TP2.Negocio
{
    public class TGDAIngresoUCI
    {
        public static List<T_GDA_INGRESOUCI> ListarTodos()
        {
            RicardoPalmaEntities db = new RicardoPalmaEntities();
            return db.T_GDA_INGRESOUCI.Where(c => c.estPaciente == "En espera").ToList();
        }

        public static T_GDA_INGRESOUCI Obtener(int id)
        {
            RicardoPalmaEntities db = new RicardoPalmaEntities();
            var ingreso = db.T_GDA_INGRESOUCI.Find(id);
            return ingreso;
        }

        public static bool Editar(T_GDA_INGRESOUCI IngresoUCI)
        {
            bool exito = false;
            RicardoPalmaEntities db = new RicardoPalmaEntities();

            try
            {
                db.Database.ExecuteSqlCommand(
                  "UPDATE T_GDA_INGRESOUCI SET estPaciente = @p1 , gravedad =  @p2 , motDesaprobacion = @p3 , obsDesaprobacion = @p4 WHERE idIngreso = @p5",
                  new SqlParameter[]
                           {
                               new SqlParameter ("p1",IngresoUCI.estPaciente),
                               new SqlParameter ("p2",IngresoUCI.gravedad),
                               new SqlParameter ("p3",IngresoUCI.motDesaprobacion),
                               new SqlParameter ("p4",IngresoUCI.obsDesaprobacion),
                               new SqlParameter ("p5",IngresoUCI.idIngreso),
                           }
                    );
                db.SaveChanges();
                exito = true;
            }
            catch (Exception ex)
            {
                exito = false;
                Bitacora.CrearLog("Error al editar el presupuesto", TipoLog.Error, ex);
            }

            return exito;
           
        }
    }
}
