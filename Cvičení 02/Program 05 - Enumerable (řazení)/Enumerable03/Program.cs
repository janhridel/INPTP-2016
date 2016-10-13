using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enumerable03
{
    class Osoba
    {
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Osoba[] osoby = new Osoba[] { 
            new Osoba { Jmeno = "Jan", Prijmeni = "Hřídel" },
            new Osoba { Jmeno = "Roman", Prijmeni = "Diviš" },
            new Osoba { Jmeno = "Adam", Prijmeni = "Hřídel" },
            new Osoba { Jmeno = "Josef", Prijmeni = "Horálek" } };
            IEnumerable<Osoba> serazeneOsoby = osoby.OrderBy(x => x.Prijmeni).ThenBy(x => x.Jmeno);
            foreach (var item in serazeneOsoby)
            {
                Console.WriteLine("{0} {1}", item.Prijmeni, item.Jmeno);
            }
            Console.ReadKey();
        }
    }
}
