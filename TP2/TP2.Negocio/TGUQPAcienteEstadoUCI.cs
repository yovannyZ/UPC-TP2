using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Datos.EF;
using TP2.Entidades.EF;

namespace TP2.Negocio
{
   public  class TGUQPAcienteEstadoUCI
    {
       public static List<T_GUQ_PACIENTE_ESTADO_UCI> ListarTodos()
       {
           RicardoPalmaEntities db = new RicardoPalmaEntities();
           return db.T_GUQ_PACIENTE_ESTADO_UCI.ToList();
       }
    }
}
