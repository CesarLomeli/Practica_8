using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_6
{
    public class primerAjuste
    {
        public List<Memoria> algoritmo(List<archivos> listaArchivos, List<Memoria> memoriaLista)
        {
            //ITERAMOS EN CADA ARCHIVO
            foreach (var item in listaArchivos)
            {
                //COMENZAMOS A PASAR POR CADA ESPACIO DE MEMORIA 
                for (int i = 0; i <= memoriaLista.Count-1; i++)
                {
                    //REVISAMOS QUE EL ARCHIVO ENTRE EN EL TAMANO Y ESTE DISPONIBLE
                    if(item.tamano <= memoriaLista[i].tamano && memoriaLista[i].estatus == false)
                    {
                        int residuo = memoriaLista[i].tamano - item.tamano;
                        memoriaLista[i].estatus = true;
                        memoriaLista[i].tamano = item.tamano;
                        memoriaLista[i].archivo = item;
                        if (residuo > 0)
                        {
                            memoriaLista.Insert(i + 1, new Memoria { tamano = residuo, estatus = false });
                        }
                        break;
                    }
                }
            }
            return memoriaLista;
        }
    }
}
