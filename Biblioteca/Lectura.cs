using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Lectura
    {
        public static string[] Lista(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
