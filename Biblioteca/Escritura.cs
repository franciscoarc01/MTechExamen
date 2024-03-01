using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public  class Escritura
    {
        public static void EscrituraFuncion(string path, string[] datos)
        {
            // Create the file, or overwrite if the file exists.
            using (FileStream fs = File.Create(path))
            {
                // Add some information to the file.
                StreamWriter streamFile = new StreamWriter(fs);
                for (uint datoInd = 0; datoInd < datos.Length; datoInd++)
                {
                    streamFile.WriteLine(datos[datoInd]);
                }
                streamFile.Close();
            }
        }
    }
}
