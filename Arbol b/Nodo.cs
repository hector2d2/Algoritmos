using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbolb
{
    class Nodo
    {
        public int[] datos;
        public Nodo[] nodos;
        public Nodo(int grado)
        {
            this.datos = new int[grado];
            this.nodos = new Nodo[grado + 1];
            for(int i = 0; i < grado; i++)
            {
                datos[i] = -1;
            }
        }
    }
}
