using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        Correo correo;

        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
        }

        
        // Cierra los hilos activos al cerrar el formulario
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }
       
        // Informa en caso de que suceda algun error
        
        private void PaqueteDAO_Excepcion(string mensaje)
        {
            MessageBox.Show(mensaje);
        }
        
        // Agrega un paquete al correo
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(this.txtDireccion.Text.ToString(), this.mtxtTrackingID.Text.ToString());

            paquete.InformarEstado += Paq_InformarEstado;
            PaqueteDAO.Excepcion += PaqueteDAO_Excepcion;

            try
            {
                this.correo += paquete;
            }
            catch (TrackingIdRepetidoException ex)
            {
                MessageBox.Show(string.Format("El trackin ID: {0} ya figura en la lista de envios", this.mtxtTrackingID.Text.ToString()), ex.Message);
            }
            this.ActualizarEstados();
        }

        private void Paq_InformarEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(this.Paq_InformarEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        
        // actualiza las listas en base a su estado
       
        private void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach (Paquete temporal in this.correo.Paquetes)
            {
                switch (temporal.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(temporal);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(temporal);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(temporal);
                        break;
                    default:
                        break;
                }
            }
        }

        
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

       
        // Muestra la infromacion 
       
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!(elemento is null))
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                elemento.MostrarDatos(elemento).Guardar("salida.txt");
            }
        }

        private void mostrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        
    }
}
