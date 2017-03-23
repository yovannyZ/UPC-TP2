using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Datos.EF;
using TP2.Entidades.EF;

namespace TP2.Negocio
{
    public class TGUQPresupuesto
    {
        public static List<T_GUQ_PRESUPUESTO> ListarTodos()
        {
            RicardoPalmaEntities db = new RicardoPalmaEntities();
            return db.T_GUQ_PRESUPUESTO.ToList();
        }

        public static bool Crear(T_GUQ_PRESUPUESTO presupuesto, List<T_GUQ_PARTIDA> listaPartidas,List<double> listaMontos)
        {
            bool exito = false;

            try
            {
                RicardoPalmaEntities db = new RicardoPalmaEntities();
                T_GUQ_PRESUPUESTO_PARTIDA PresupuestoPartida ;
             
                
                presupuesto.estado = "Generado";
                for (int i = 0; i < listaPartidas.Count(); i++)
                {
                    PresupuestoPartida = new T_GUQ_PRESUPUESTO_PARTIDA();
                    PresupuestoPartida.idPartida = listaPartidas[i].idPartida;
                    PresupuestoPartida.montoPartida = listaMontos[i]; 
                    presupuesto.monto =  presupuesto.monto + listaMontos[i];
                    presupuesto.T_GUQ_PRESUPUESTO_PARTIDA.Add(PresupuestoPartida);
                }
                   
                db.Entry(presupuesto).State = EntityState.Added;
              //  db.T_GUQ_PRESUPUESTO.Add(presupuesto);

                for (int i = 0; i < listaPartidas.Count(); i++)
                {
                    db.Entry(listaPartidas[i]).State = EntityState.Unchanged;
                }
               
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

        public static bool Editar(T_GUQ_PRESUPUESTO presupuesto, List<T_GUQ_PARTIDA> listaPartidas, List<double> listaMontos)
        {
            bool exito = false;

            try
            {
                RicardoPalmaEntities db = new RicardoPalmaEntities();
                T_GUQ_PRESUPUESTO_PARTIDA PresupuestoPartida;

                
                db.Database.ExecuteSqlCommand(
                    "DELETE FROM  T_GUQ_PRESUPUESTO_PARTIDA  WHERE idPresupuesto = @idPer",
                    new SqlParameter[]
                       {
                           new SqlParameter ("idPer", presupuesto.idPresupuesto)
                       }
              );

                presupuesto.estado = "Generado";
                presupuesto.monto = 0;
                for (int i = 0; i < listaPartidas.Count(); i++)
                {
                    PresupuestoPartida = new T_GUQ_PRESUPUESTO_PARTIDA();
                    PresupuestoPartida.idPartida = listaPartidas[i].idPartida;
                    PresupuestoPartida.idPresupuesto = presupuesto.idPresupuesto;
                    PresupuestoPartida.montoPartida = listaMontos[i];
                    presupuesto.idPresupuesto = presupuesto.idPresupuesto;
                    presupuesto.monto = presupuesto.monto + listaMontos[i];

                    db.Database.ExecuteSqlCommand(
                  "InSERT INTO  T_GUQ_PRESUPUESTO_PARTIDA VALUES(@P1,@P2,@P3)",
                  new SqlParameter[]
                       {
                           new SqlParameter ("P1",PresupuestoPartida.idPresupuesto),
                            new SqlParameter ("P2",PresupuestoPartida.idPartida),
                             new SqlParameter ("P3",PresupuestoPartida.montoPartida)
                       }
            );
            }

                db.Database.ExecuteSqlCommand(
                "UPDATE   T_GUQ_PRESUPUESTO SET monto = @p1  WHERE idPresupuesto = @p2",
                new SqlParameter[]
                       {
                           new SqlParameter ("P1",presupuesto.monto),
                              new SqlParameter ("P2",presupuesto.idPresupuesto)
                          
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

        public static T_GUQ_PRESUPUESTO Obtener(int id)
        {
            RicardoPalmaEntities db = new RicardoPalmaEntities();
            var presupuesto = db.T_GUQ_PRESUPUESTO.Find(id);
            return presupuesto;
        }
    }
}
