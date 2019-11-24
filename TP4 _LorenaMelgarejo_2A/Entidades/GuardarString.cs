using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        
        // guarda texto en un archivo
        
        public static bool Guardar(this string texto, string archivo)
        {
            bool retorno = false;
            string ruta;

            ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo;

            using (StreamWriter writer = new StreamWriter(ruta, true))
            {
                writer.WriteLine(texto);
                retorno = true;
            }
            return retorno;
            
        }
    }
}
