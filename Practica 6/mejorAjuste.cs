using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_6
{
    public class mejorAjuste
    {
        public List<Memoria> algoritmo(List<archivos> listaArchivos, List<Memoria> memoriaLista)
        {
            //ITERAMOS EN CADA ARCHIVO
            foreach (var item in listaArchivos){
                //Espacios de memoria que sean libres y tamaño mayor o igual al archivo
                var espaciosLibres = memoriaLista.Where(m=>m.estatus == false && m.tamano >= item.tamano).ToList();
                if (espaciosLibres.Any()) { 
                    var mejorAjuste = espaciosLibres.OrderBy(m => m.tamano - item.tamano).First();
                    int espacioSobrante = mejorAjuste.tamano - item.tamano;
                    mejorAjuste.tamano = item.tamano;
                    mejorAjuste.estatus = true;
                    mejorAjuste.archivo = item;
                    if (espacioSobrante > 0)
                    {
                        int indice = memoriaLista.IndexOf(mejorAjuste);
                        memoriaLista.Insert(indice + 1, new Memoria { tamano = espacioSobrante, estatus = false });
                    }
                }
            }
            return memoriaLista;
        }
    }
}
