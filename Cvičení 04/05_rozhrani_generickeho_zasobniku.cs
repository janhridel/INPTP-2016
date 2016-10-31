using System;
using System.Collections.Generic;
using System.Text;

namespace Rozhrani
{
    interface IZasobnik<T>
    {
        void Vloz(T obj);
        T Odeber();
    }

    class GenZasobnik<T> : IZasobnik<T>
    {
        T[] pole = new T[100];
        int pocet;
        public void Vloz(T obj)
        {
            if (pocet < pole.Length) pole[pocet++] = obj;
        }
        public T Odeber()
        {
            if (pocet > 0) return pole[--pocet];
            throw new InvalidOperationException("Zasobník je prázdný");
        }
    }
    class IntZasobnik : IZasobnik<int>
    {
        public void Vloz(int obj)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Odeber()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
    class ExplicitGenZasobnik<T> : IZasobnik<T>
    {
        T[] pole = new T[100];
        int pocet;

        public void Pridej(T obj)
        {
            if (pocet < pole.Length) pole[pocet++] = obj;
        }
        public T Vymaz()
        {
            if (pocet > 0) return pole[--pocet];
            throw new InvalidOperationException("Zasobník je prázdný");
        }
        void IZasobnik<T>.Vloz(T obj)
        {
            Pridej(obj);
        }
        T IZasobnik<T>.Odeber()
        {
            return Vymaz();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IZasobnik<int> zasobnik = new GenZasobnik<int>();
            zasobnik.Vloz(1);
            zasobnik.Vloz(2);
            Console.WriteLine(zasobnik.Odeber());
            Console.WriteLine(zasobnik.Odeber());
            ExplicitGenZasobnik<string> zasobnik2 = new ExplicitGenZasobnik<string>();
            zasobnik2.Pridej("Aaa");
            zasobnik2.Pridej("Bbb");
            Console.WriteLine(zasobnik2.Vymaz());
            Console.WriteLine(zasobnik2.Vymaz());
            Console.ReadKey();
        }
    }
}
