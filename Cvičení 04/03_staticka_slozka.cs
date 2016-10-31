using System;
using System.Collections.Generic;
using System.Text;

namespace StatickaSlozka
{
    class A<T>
    {
        public static int Pocet;
        private T y;
        public A(T y)
        {
            this.y = y;
            Pocet++;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            A<int> a1 = new A<int>(10);
            A<int> a2 = new A<int>(20);
            A<double> a3 = new A<double>(1.5);
            Console.WriteLine(A<int>.Pocet);
            Console.WriteLine(A<double>.Pocet);
            Console.ReadKey();
        }
    }
}
