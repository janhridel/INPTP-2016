using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Enumerable04
{
    class Osoba
    {
        public string Jmeno { get; set; }
        public int Vek { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList osoby = new ArrayList { 
            new Osoba { Jmeno = "Jana", Vek = 30 },
            new Osoba { Jmeno = "Karel", Vek = 36 },
            new Osoba { Jmeno = "Adela", Vek = 25 },
            new Osoba { Jmeno = "Josef", Vek = 20 } };
            IEnumerable<string> jmena = osoby.Cast<Osoba>().Where(x => x.Vek > 20).OrderByDescending(x => x.Jmeno).Select(x => x.Jmeno);
            foreach (var item in jmena)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
