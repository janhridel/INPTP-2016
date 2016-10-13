using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enumerable04b
{
    class Osoba
    {
        public string Jmeno { get; set; }
        public int Vek { get; set; }
        public string[] Deti { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Osoba[] osoby = { 
         new Osoba { Jmeno = "Jana", Vek = 30, Deti = new string[] { "Dagmar", "Jaroslav" } },
         new Osoba { Jmeno = "Karel", Vek = 36, Deti = new string[] { "Petr", "Zdena" } },
         new Osoba { Jmeno = "Adela", Vek = 25, Deti = new string[] { "Pavel" } },
         new Osoba { Jmeno = "Josef", Vek = 20, Deti = new string[0] } };
            IEnumerable<string> deti = osoby.SelectMany(x => x.Deti);
            foreach (string item in deti)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
