using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_6
{
    public class Memoria
    {
        public int tamano { get; set; }
        public bool estatus {  get; set; } = false;
        public archivos archivo { get; set; }

        public List<Memoria> cargarMemoria()
        {
            List<Memoria> memorias = new List<Memoria>();
            Memoria m = new Memoria();
            m.tamano = 1000;
            m.estatus = false;
            memorias.Add(m);
            Memoria m1 = new Memoria();
            m1.tamano = 400;
            m1.estatus = false;
            memorias.Add(m1);
            Memoria m2 = new Memoria();
            m2.tamano = 1800;
            m2.estatus = false;
            memorias.Add(m2);
            Memoria m3 = new Memoria();
            m3.tamano = 700;
            m3.estatus = false;
            memorias.Add(m3);
            Memoria m4 = new Memoria();
            m4.tamano = 900;
            m4.estatus = false;
            memorias.Add(m4);
            Memoria m5 = new Memoria();
            m5.tamano = 1200;
            m5.estatus = false;
            memorias.Add(m5);
            Memoria m6 = new Memoria();
            m6.tamano = 1500;
            m6.estatus = false;
            memorias.Add(m6);
            return memorias;
        }
    }
}
