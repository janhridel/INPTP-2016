using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enumerable04c
{
    class Osoba
    {
        public string Jmeno { get; set; }
        public int Vek { get; set; }
        public string[] Deti { get; set; }
    }
    class OsobaDite
    {
        public string OsobaJmeno { get; set; }
        public string DiteJmeno { get; set; }
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
            IEnumerable<OsobaDite> deti = osoby.SelectMany(x => x.Deti, (x, y) => new OsobaDite() { OsobaJmeno = x.Jmeno, DiteJmeno = y });
            foreach (OsobaDite item in deti)
            {
                Console.WriteLine("{0}: {1}", item.OsobaJmeno, item.DiteJmeno);
            }
            Console.ReadKey();
        }
    }
}
