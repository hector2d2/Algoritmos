using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbolb
{
    class Arbolb
    {

        public Nodo raiz;
        int degree;
        public Arbolb(int degree)
        {
            this.raiz = null;
            this.degree = degree;
        }

        public void insertar(int dato)
        {
            raiz = insertar(raiz, dato,null);
        }

        public Nodo insertar(Nodo actual, int dato,Nodo padre)
        {
            if (actual == null) actual = new Nodo(degree);
            if (actual.nodos[0] != null)
            {
                for(int indice = 0; indice < degree; indice++)
                {
                    if (actual.datos[indice] > dato || actual.datos[indice] == -1)
                    {
                        actual.nodos[indice] = insertar(actual.nodos[indice],dato,actual);
                        break;
                    }
                }
            }
            else
            {
                int i = 0;
                while (actual.datos[i] < dato && actual.datos[i] != -1)
                {
                    i++;
                }
                actual.datos = recorrerdatos(actual,i);
                
                actual.datos[i] = dato;
            }            
            if (estalleno(actual))
            {// partir :c
                actual = partir(padre, actual);
            }
            return actual;
        }

        public Nodo partir(Nodo padre, Nodo actual)
        {
            if (padre == null)
            {
                Nodo derecha = new Nodo(degree);
                Nodo izquierda = new Nodo(degree);
                int l = 0;
                for(int k = 0; k < degree+1;k++)
                {
                    if (k < (degree / 2)+1)
                    {
                        izquierda.nodos[k] = actual.nodos[k];
                    }
                    else
                    {
                        derecha.nodos[l++] = actual.nodos[k];
                        
                    }
                }
                actual.nodos[0] = izquierda;
                actual.nodos[1] = derecha;
                int i;
                for (i = 0; i < degree / 2; i++)//hijos izquierda
                {
                    actual.nodos[0].datos[i] = actual.datos[i];
                }
                int j = 0;
                for (i = (degree / 2) + 1; i < degree; i++)//hijos derecha
                {
                    actual.nodos[1].datos[j++] = actual.datos[i];
                }
                actual.datos[0] = actual.datos[degree / 2];//mover al principio los hijos del actual
                inicializardatos(actual.datos);
                actual.nodos = inicializarnodos(actual);
                return actual;
            }

            for(int i = 0; i < degree; i++)
            {
                if (padre.datos[i]>actual.datos[degree/2] || padre.datos[i] == -1)
                {
                    int j;
                    padre.datos = recorrerdatos(padre,i);
                    padre.nodos = recorrernodos(padre,i);
                    
                    padre.datos[i] = actual.datos[degree / 2];
                    padre.nodos[i + 1] = new Nodo(degree);
                    int k = 0;
                    
                    for (j= (degree / 2)+1; j < degree; j++)
                    {
                        padre.nodos[i + 1].datos[k++] = actual.datos[j];//actualizar el padre nodo con los valores izquierdos del hijo
                    }
                    inicializardatos(actual.datos);
                    //pasar nodos hijos 
                    k = 0;
                    for(j = degree / 2 + 1; j < degree + 1; j++)
                    {
                        padre.nodos[i + 1].nodos[k++] = actual.nodos[j];
                    }
                    
                    actual.nodos = inicializarnodos(actual);
                    break;
                }                
            }
            return actual;
        }

        bool estalleno(Nodo nodo)
        {
            return nodo.datos[degree - 1] != -1 ? true : false;
        }

        void inicializardatos(int[]datos)
        {
            for(int i = degree/2; i < degree; i++)
            {
                datos[i] = -1;
            }
        }

        int[] recorrerdatos(Nodo actual,int indice)
        {
            for (int j = degree - 1; j > indice; j--)
            {
                actual.datos[j] = actual.datos[j - 1];
            }
            return actual.datos;
        }

        Nodo[] recorrernodos(Nodo actual,int indice)
        {
            int j;
            for (j = degree; j > indice; j--)
            {
                actual.nodos[j] = actual.nodos[j - 1];
            }
            return actual.nodos;
        }
        public void mostrar()
        {
            if (raiz != null) preorden(raiz);
        }

        Nodo[] inicializarnodos(Nodo actual)
        {
            for(int i = degree/2+1; i < degree+1; i++)
            {
                actual.nodos[i] = null;
            }
            return actual.nodos;
        }

        void preorden(Nodo actual)
        {
            if(actual != null)
            {
                int i;
                for(i = 0; i < degree; i++)
                {
                    if (actual.datos[i] != -1) Console.Write(actual.datos[i] + " ");
                    else break;
                }
                Console.WriteLine();
                for (i = 0; i < degree+1; i++)
                {
                    if (actual.nodos[i] != null) preorden(actual.nodos[i]);
                    else break;
                }
            }
        }
        
    }
}
