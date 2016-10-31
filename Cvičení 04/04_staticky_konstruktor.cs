using System;
using System.Collections.Generic;
using System.Text;

namespace StatickyKonstruktor
{
    enum Barva { Cervena, Zelena, Modra }
    class A<T>
    {
        T x;
        public A(T x) { this.x = x; }
        static A()
        {
            if (!typeof(T).IsEnum)
            {
                string s = string.Format("T typu {0} není výčtový typ", typeof(T).Name);
                throw new ArgumentException(s);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                A<Barva> a1 = new A<Barva>(Barva.Cervena); // OK
                A<int> a2 = new A<int>(0); // vznikne výjimka
            }
            catch (Exception e)
            {
                Console.WriteLine("Výjimka: " + e.Message);
                if (e.InnerException != null)
                {
                    Console.WriteLine("Vnitřní výjimka: " + e.InnerException.Message);
                }
            }
            Console.ReadKey();
        }
    }
}
