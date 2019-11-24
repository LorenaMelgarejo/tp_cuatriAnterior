using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PaqueteListaInstanciada()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]
        public void MismoTrackingID()
        {
            Paquete package1 = new Paquete("diccion1", "123-123-1233");
            Paquete package2 = new Paquete("direccion2", "123-123-1233");
            Correo mail = new Correo();

            mail += package1;

            try
            {
                mail += package2;
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
            }
        }
    }
}
