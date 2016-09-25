using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Razeni
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
			new Osoba { Jmeno = "Jana", Prijmeni = "Nováková" },
			new Osoba { Jmeno = "Václav", Prijmeni = "Hřídel" },
			new Osoba { Jmeno = "Adéla", Prijmeni = "Nováková" },
			new Osoba { Jmeno = "Josef", Prijmeni = "Hřídel" } };
            IEnumerable<Osoba> serazeneOsoby = osoby.OrderBy(x => x.Prijmeni).ThenBy(x => x.Jmeno);
            foreach (var item in serazeneOsoby)
            {
                Console.WriteLine("{0} {1}", item.Prijmeni, item.Jmeno);
            }
            Console.ReadKey();
        }
    }
}
