using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymniTyp
{
    class Vydavatel
    {
        public string Nazev { get; set; }
        public int Cislo { get; set; }
    }
    class Kniha
    {
        public int VydavatelCislo { get; set; }
        public string Nazev { get; set; }
        public string Autor { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Vydavatel[] vydavatele = new Vydavatel[] {
            new Vydavatel() { Nazev = "Computer Press", Cislo = 1 }, 
            new Vydavatel() { Nazev = "Grada", Cislo = 2 },
            new Vydavatel() { Nazev = "Academia", Cislo = 3 } };
            Kniha[] knihy = new Kniha[] {
            new Kniha() { Autor = "Pecinovský", Nazev = "Word 2003", VydavatelCislo = 1 },
            new Kniha() { Autor = "Virius", Nazev = "Jazyk C#", VydavatelCislo = 2 },
            new Kniha() { Autor = "Prata", Nazev = "Mistrovství v C++", VydavatelCislo = 1 },
            new Kniha() { Autor = "Topfer", Nazev = "Datove struktury", VydavatelCislo = 2 } };

            var souhrn = vydavatele.Join(knihy, vydavatel => vydavatel.Cislo, kniha => kniha.VydavatelCislo,
               (vydavatel, kniha) => new { VydavatelNazev = vydavatel.Nazev, kniha.Autor, KnihaNazev = kniha.Nazev });

            foreach (var item in souhrn)
            {
                Console.WriteLine("Vydavatel: {0}, kniha: {1}. {2}", item.VydavatelNazev, item.Autor, item.KnihaNazev);
            }

            Console.ReadKey();
        }
    }
}
