using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Entidades
{
    public static class PaqueteDAO
    {
        public delegate void MiDelegado(string mensaje);
        public static event MiDelegado Excepcion;
        /// <summary>
        /// Atributos
        /// </summary>
        #region Atributos
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #endregion


        #region Constructor
        static PaqueteDAO()
        {

            PaqueteDAO.conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            PaqueteDAO.comando = new SqlCommand();
            PaqueteDAO.comando.Connection = conexion;
        }
        #endregion

        #region Metodo
        /// <summary>
        /// Ingresa un paquete a la base de datos
        /// </summary>
        /// <param name="p"></param>
        /// <returns>True si pudo escribir, sino false</returns>

        public static bool Insertar(Paquete p)
        {
            String consulta;
            bool retorno = false;

            try
            {
                conexion.Open();
                consulta = string.Format("INSERT INTO Paquetes (direccionEntrega,trackingID,alumno)  VALUES('{0}','{1}','{2}')",
                    p.DireccionEntrega, p.TrackingID, "Melgarejo Lorena");
                comando.CommandText = consulta;
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception e)
            {
                Excepcion(string.Format("Error en la insercion de datos en la base de datos: {0}", e.Message));
            }
            finally
            {
                if (!(conexion is null))
                {
                    conexion.Close();
                }
            }
            return retorno;
           

        }
        #endregion
    }
}
