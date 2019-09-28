using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbolb
{
    class Program 
    {
        static void Main(string[] args)
        {
            Arbolb a = new Arbolb(3);
            a.insertar(50);
            a.insertar(100);
            a.insertar(200);
            
            a.insertar(85);
                       
            a.insertar(80);
            
            a.insertar(300);
            a.insertar(600);
            a.insertar(800);
            
            a.mostrar();
            Console.ReadKey();
        }
    }
}
