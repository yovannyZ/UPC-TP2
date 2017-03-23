using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Datos.EF;
using TP2.Entidades.EF;

namespace TP2.Negocio
{
    public class TGUQPartida
    {
        public static List<T_GUQ_PARTIDA> ListarTodos()
        {
            RicardoPalmaEntities db = new RicardoPalmaEntities();
            return db.T_GUQ_PARTIDA.ToList();
        }

        public static T_GUQ_PARTIDA Obtener(int id)
        {
            RicardoPalmaEntities db = new RicardoPalmaEntities();
            var partida = db.T_GUQ_PARTIDA.Find(id);
            
            return partida;
        }
    }
}
