using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv03
{

    #region 5 - Vydavatelé a knihy (join) (přidání tříd)
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
    #endregion

    #region 3 - skupiny osob (přidání třídy)
    class Osoba
    {
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public int Vek { get; set; }
    }
    #endregion

    #region 2 - studenti a známky (přidání třídy)
    class Student
    {
        public string Jmeno { get; set; }
        public byte[] Znamky { get; set; }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            #region 1 - výběr lichých
            int[] cisla = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // dotazovací proměnná
            IEnumerable<int> lichaCisla =
               from cislo in cisla
               where cislo % 2 == 1
               orderby cislo
               select cislo;

            Console.WriteLine("\n=====================\nVýpis vybraných lichých čísel\n=====================\n");

            foreach (var item in lichaCisla)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            #endregion

            #region 2 - studenti a známky
            Student[] studenti = { 
            new Student { Jmeno = "Karel", Znamky = new byte[] { 1, 2, 3, 1 } },
            new Student { Jmeno = "Josef", Znamky = new byte[] { 3, 1 } },
            new Student { Jmeno = "Jana",  Znamky = new byte[] { 3, 2, 4 }},
            new Student { Jmeno = "Aneta", Znamky = new byte[] { 3, 2 } } };
            var studentQuery =
               from student in studenti
               from znamka in student.Znamky
               where znamka == 1
               select student;

            Console.WriteLine("\n=====================\nStudenti s jedničkou\n=====================\n");
            foreach (var item in studentQuery)
            {
                Console.WriteLine(item.Jmeno);
            }
            #endregion

            #region 3 - skupiny osob
            Osoba[] osoby = { 
            new Osoba { Jmeno = "Karel", Prijmeni = "Kadeřábek", Vek = 30 },
            new Osoba { Jmeno = "Josef", Prijmeni = "Kadeřábek", Vek = 25 },
            new Osoba { Jmeno = "Jana", Prijmeni = "Silná", Vek = 36 },
            new Osoba { Jmeno = "Dana", Prijmeni = "Silná", Vek = 42 },
            new Osoba { Jmeno = "Mirek", Prijmeni = "Adamec", Vek = 19 },
            new Osoba { Jmeno = "Aneta", Prijmeni = "Adamcová", Vek = 20 } };
            IEnumerable<IGrouping<int, Osoba>> osobyQuery =
               from osoba in osoby
               group osoba by osoba.Vek / 10;
            Console.WriteLine("\n=====================\nPodle desítek věků A\n=====================\n");
            foreach (IGrouping<int, Osoba> item in osobyQuery)
            {
                Console.WriteLine("\nVek {0} až {1}:",
                   item.Key * 10, item.Key * 10 + 9);
                foreach (Osoba item2 in item)
                {
                    Console.WriteLine("{0}, {1}", item2.Jmeno, item2.Vek);
                }
            }
            IEnumerable<IGrouping<int, string>> osobyQuery2 =
               from osoba in osoby
               group osoba.Jmeno by osoba.Vek / 10;
            Console.WriteLine("\n=====================\nPodle desítek věků B\n=====================\n");
            foreach (IGrouping<int, string> item in osobyQuery2)
            {
                Console.WriteLine("\nVek {0} až {1}:",
                   item.Key * 10, item.Key * 10 + 9);
                foreach (string item2 in item)
                {
                    Console.WriteLine(item2);
                }
            }

            IEnumerable<IGrouping<int, Osoba>> osobyQuery3 =
            from osoba in osoby
            group osoba by osoba.Vek / 10 into osobaGroup
            where osobaGroup.Key > 2
            select osobaGroup;
            Console.WriteLine("\n=====================\nJen 30+\n=====================\n");
            foreach (IGrouping<int, Osoba> item in osobyQuery3)
            {
                Console.WriteLine("\nVek {0} až {1}:",
                   item.Key * 10, item.Key * 10 + 9);
                foreach (Osoba item2 in item)
                {
                    Console.WriteLine("{0}, {1}", item2.Jmeno, item2.Vek);
                }
            }

            IEnumerable<Osoba> osobyQuery4 =
            from osoba in osoby
            orderby osoba.Prijmeni descending, osoba.Jmeno
            select osoba;
            Console.WriteLine("\n=====================\nSeřazené osoby\n=====================\n");
            foreach (var item in osobyQuery4)
            {
                Console.WriteLine("{0} {1}", item.Prijmeni, item.Jmeno);
            }
            #endregion

            #region 4 - ukázka let
            string[] radky = { "1, 2, 3, 4", "5, 6, 7, 8", "9, 10, 11, 12" };
            IEnumerable<int> cislaQuery =
               from radek in radky
               let texty = radek.Split(',')
               from text in texty
               let cislo = int.Parse(text)
               select cislo;
            Console.WriteLine("\n=====================\nukázka let\n=====================\n");
            foreach (int item in cislaQuery)
            {
                Console.Write(item + " ");
            }
            #endregion

            #region 5 - Vydavatelé a knihy (join)
            Vydavatel[] vydavatele = new Vydavatel[] {
            new Vydavatel() { Nazev = "Computer Press", Cislo = 1 }, 
            new Vydavatel() { Nazev = "Grada", Cislo = 2 },
            new Vydavatel() { Nazev = "Academia", Cislo = 3 } };
            Kniha[] knihy = new Kniha[] {
            new Kniha() { Autor = "Pecinovský", Nazev = "Word 2003", VydavatelCislo = 1 },
            new Kniha() { Autor = "Virius", Nazev = "Jazyk C#", VydavatelCislo = 2 },
            new Kniha() { Autor = "Prata", Nazev = "Mistrovství v C++", VydavatelCislo = 1 },
            new Kniha() { Autor = "Topfer", Nazev = "Datove struktury", VydavatelCislo = 2 } };
            var souhrnQuery =
               from vydavatel in vydavatele
               join kniha in knihy on vydavatel.Cislo equals kniha.VydavatelCislo
               select new { VydavatelNazev = vydavatel.Nazev, kniha.Autor, KnihaNazev = kniha.Nazev };
            Console.WriteLine("\n=====================\nVydavatelé a knihy\n=====================\n");
            foreach (var item in souhrnQuery)
            {
                Console.WriteLine("Vydavatel: {0}, kniha: {1}. {2}",
                   item.VydavatelNazev, item.Autor, item.KnihaNazev);
            }

            var souhrnQuery2 =
            from vydavatel in vydavatele
            join kniha in knihy on vydavatel.Cislo equals kniha.VydavatelCislo into vydavatelKnihy
            select new { VydavatelNazev = vydavatel.Nazev, Knihy = vydavatelKnihy };
            Console.WriteLine("\n=====================\nVydavatelé a knihy (vše)\n=====================\n");
            foreach (var item in souhrnQuery2)
            {
                Console.WriteLine("Vydatatel: {0}", item.VydavatelNazev);
                foreach (var item2 in item.Knihy)
                {
                    Console.WriteLine("{0}. {1}", item2.Autor, item2.Nazev);
                }
                Console.WriteLine();
            }
            #endregion

            #region 6 - index prvku zdrojové sekvence
            string[] pole1 = new string[] { "Text1", "Text2", "Text3" };
            int[] pole2 = new int[] { 10, 20, 30 };
            int index = 0;
            var query =
               from item in pole1
               select new { Text = item, Cislo = pole2[index++] };

            Console.WriteLine("\n=====================\nNapárované prvky, výpis 1\n=====================\n");
            foreach (var item in query)
            {
                Console.WriteLine("Text = {0}, Cislo = {1}", item.Text, item.Cislo);
            }
            index = 0; // #1

            Console.WriteLine("\n=====================\nNapárované prvky, výpis 2\n=====================\n");
            foreach (var item in query)
            {
                Console.WriteLine("Text = {0}, Cislo = {1}", item.Text, item.Cislo);
            }
            #endregion

            Console.ReadKey();
        }
    }
}
