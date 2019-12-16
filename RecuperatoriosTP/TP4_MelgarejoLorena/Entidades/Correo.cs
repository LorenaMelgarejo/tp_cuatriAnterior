using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {

        #region Atributos
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region Propiedad
        public List<Paquete> Paquetes
        {

            get { return this.paquetes; }
            set { this.paquetes = value; }
            
        }
        #endregion

        #region Constructor
        public Correo()
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Finaliza los hilos en ejecucion
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread t in this.mockPaquetes)
            {
                t.Abort();
            }
        }

        /// <summary>
        /// Muestra los datos del correo y de los paquetes con su estado
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            string retorno = "";

            if (!(elementos is null))
            {
                foreach (Paquete p in ((Correo)elementos).paquetes)
                {

                    retorno += string.Format("{0} para {1} ({2})\n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());

                }
            }

            return retorno;
        }
        #endregion

        #region Sobrecarga
        /// <summary>
        /// Agrega un paquete al correo si el paquete no es del correo
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            Thread t;

            if (!(c.paquetes is null))
            {
                foreach (Paquete temporal in c.paquetes)
                {
                    if (temporal == p)
                    {
                        throw new TrackingIdRepetidoException(string.Format("Id repetido {0}", temporal.TrackingID));
                    }
                }
                c.paquetes.Add(p);
                t = new Thread(p.MockCicloDeVida);
                c.mockPaquetes.Add(t);
                t.Start();
            }
            return c;

           
        }
        #endregion
    }
}