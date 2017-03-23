using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP2.Negocio;

namespace TP2.Web.Controllers
{
    public class EstadisticaRecursosController : Controller
    {
        //
        // GET: /EstadisticaRecursos/
        [HttpPost]
        public string Index(string anio, int partida,int idArea)
        {
            double valor = TGUQEstadisticaRecursos.ObtenerPromedio(int.Parse(anio), partida, idArea);
            return string.Format("{0:0.00}", valor);
        }
	}
}