using System.Collections.Generic;
using TP2.Datos.EF;
using TP2.Entidades.EF;
using System.Linq;

namespace TP2.Negocio
{
    public class TGDAPaciente
    {
        public static List<T_GDA_PACIENTE> ListarTodos()
        {
            RicardoPalmaEntities db = new RicardoPalmaEntities();
            return db.T_GDA_PACIENTE.ToList();
        }
    }
}