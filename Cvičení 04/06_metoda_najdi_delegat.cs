using System;
using System.Collections.Generic;
using System.Text;

namespace Delegat
{
    delegate bool Predikat<T>(T hodnota);

    class GenZasobnik<T>
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
        public T Najdi(Predikat<T> predikat)
        {
            for (int i = 0; i < pocet; i++)
            {
                if (predikat(pole[i])) return pole[i];
            }
            return default(T);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GenZasobnik<string> zasobnik = new GenZasobnik<string>();
            for (int i = 0; i < 4; i++)
            {
                Console.Write("Zadej {0}. text: ", i + 1);
                zasobnik.Vloz(Console.ReadLine());
            }
            Console.Write("Zadej počáteční text: ");
            string pocatek = Console.ReadLine();
            string text = zasobnik.Najdi(x => x.StartsWith(pocatek));
            //Predikat<string> predikat = delegate(string hodnota) { return hodnota.StartsWith(pocatek); };
            //string text = zasobnik.Najdi(predikat); 
            if (text == null) Console.WriteLine("Text nebyl nalezen");
            else Console.WriteLine("Nalezený text: " + text);
            Console.ReadKey();
        }
    }
}
