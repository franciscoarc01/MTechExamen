using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Escritura
    {
        public static void EscrituraFuncion(string path, string[] datos)
        {
            StreamWriter sw = new StreamWriter(path);
            for (uint datoInd = 0; datoInd < datos.Length; datoInd++)
            {
                sw.WriteLine(datos[datoInd]);
            }
            sw.Close();
        }
    }
}
