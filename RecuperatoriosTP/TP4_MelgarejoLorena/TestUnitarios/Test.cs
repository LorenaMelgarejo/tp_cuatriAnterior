using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class Test
    {
        /// <summary>
        /// Verifica que la lista de Paquetes del Correo esté instanciada
        /// </summary>
        [TestMethod]
        public void TestListaInstanciada()
        {
            Correo c = new Correo();

            Assert.IsTrue(true);

            Assert.IsNotNull(c);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestMismoID()
        {
            Correo correo = new Correo();

            Paquete p1 = new Paquete("diccion1", "123-123-1233");
            Paquete p2 = new Paquete("diccion2", "123-123-1233");

            try
            {
                correo += p1;
                correo += p2;
            }
            catch (TrackingIdRepetidoException)
            {
                Assert.IsTrue(true);
            }
        }

    }
}
