using System;
using System.Collections.Generic;
using System.Text;

namespace Zasobnik01
{
    class Zasobnik
    {
        object[] pole = new object[100];
        int pocet;
        public void Vloz(object obj)
        {
            if (pocet < pole.Length) pole[pocet++] = obj;
        }
        public object Odeber()
        {
            if (pocet > 0) return pole[--pocet];
            return null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Zasobnik zasobnik = new Zasobnik();
            zasobnik.Vloz(1);
            zasobnik.Vloz(2);
            int cislo = (int)zasobnik.Odeber();
            Console.WriteLine(cislo);
            Console.ReadKey();
        }
    }
}
