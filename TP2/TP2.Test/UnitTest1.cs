using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP2.Negocio;
using TP2.Entidades.EF;
using System.Collections.Generic;

namespace TP2.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ListarBienes()
        {
            List<T_GG_EMPLEADO> listado = TGGBien.GetAll();
            Assert.IsTrue(listado.Count > 0);
        }
    }
}
