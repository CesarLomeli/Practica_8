using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_6
{
    public class archivos
    {
        public string nombre { get; set; }
        public int tamano { get; set; }
        public List<archivos> cargarArchivos(string path)
        {
            List<archivos> archivos = new List<archivos>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    string[] lineSplit = line.Split(',');
                    archivos ar = new archivos();
                    ar.nombre = lineSplit[0];
                    string[] lineSplit2 = lineSplit[1].Split("kb");
                    ar.tamano = int.Parse(lineSplit2[0]);
                    archivos.Add(ar);
                }
            }
            return archivos;
        }

    }
}
