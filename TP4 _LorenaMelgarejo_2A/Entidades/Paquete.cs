using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region DELEGADO
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformarEstado;
        #endregion

        #region ENUMERADO
        public enum EEstado { Ingresado, EnViaje, Entregado }
        #endregion

        #region ATRIBUTOS
        string direccionEntrega;
        EEstado estado;
        string trackingID;
        #endregion

        #region PROPIEDADES
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set{ this.direccionEntrega = value;}
        }
        public EEstado Estado
        {
            get{ return this.estado; }
            set{ this.estado = value;}
        }
        public string TrackingID
        {
            get{ return this.trackingID;}
            set{ this.trackingID = value;}
        }
        #endregion

        #region CONSTRUCTOR
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
            this.Estado = EEstado.Ingresado;
        }
        #endregion
        #region METODOS

        
        // Muestra los datos 
       
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p= (Paquete)elemento;

            return string.Format("{0} para {1}\r\n", p.trackingID, p.direccionEntrega);
        }

        //retorna la información del paquete

        public override string ToString()
        {
            return this.MostrarDatos((IMostrar<Paquete>)this);
        }

       
        public void MockCicloDeVida()
        {
            while (this.estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.estado++;
                this.InformarEstado.Invoke(null, null);
            }
            if (this.estado == EEstado.Entregado)
            {
                PaqueteDAO.Insertar(this);
            }
        }

        #endregion
        #region SOBRECARGAS
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return (p1.trackingID == p2.trackingID);
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion
    }
}
