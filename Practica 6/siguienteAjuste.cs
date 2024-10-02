using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_6
{
    public class siguienteAjuste
    {
        public List<Memoria> algoritmo(List<archivos> listaArchivos, List<Memoria> memoriaLista)
        {
            int LastIndex = 0;
            foreach (var item in listaArchivos) {
                //Iteramos toda la lista
                for (int i = 0; i < memoriaLista.Count; i++)
                {
                    //Creamos nuevo indice, % nos permite un bucle circular
                    //si llegamos al final de la lista comenzamos en 0
                    int indice = (LastIndex + i) % memoriaLista.Count;
                    var espacio = memoriaLista[indice];
                    if (espacio.estatus == false && espacio.tamano >= item.tamano)
                    {
                        int espacioSobrante = espacio.tamano - item.tamano;
                        espacio.tamano = item.tamano;
                        espacio.estatus = true;
                        espacio.archivo = item;
                        LastIndex = indice;
                        if(espacioSobrante > 0)
                        {
                            memoriaLista.Insert(indice+1, new Memoria { tamano = espacioSobrante, estatus = false });
                        }
                        break;
                    }
                }
            }
            return memoriaLista;
        }
    }
}
