using System.Collections.Generic;
using TP2.Datos.EF;
using TP2.Entidades.EF;
using System.Linq;

namespace TP2.Negocio
{
    public class TGGBien
    {
        public static List<T_GG_EMPLEADO> GetAll()
        {
            RicardoPalmaEntities db = new RicardoPalmaEntities();
            return db.T_GG_EMPLEADO.ToList();
        }
    }
}
