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
                new Kniha() { Autor = "Pecinovský", Nazev = "Word 2003",
                VydavatelCislo = 1 },
                new Kniha() { Autor = "Virius", Nazev = "Jazyk C#",
                VydavatelCislo = 2 },
                new Kniha() { Autor = "Prata", Nazev = "Mistrovství v C++",
                VydavatelCislo = 1 },
                new Kniha() { Autor = "Topfer", Nazev = "Datove struktury",
                VydavatelCislo = 2 } };

        var souhrnQuery =
        from vydavatel in vydavatele
        join kniha in knihy on vydavatel.Cislo equals kniha.VydavatelCislo
        into vydavatelKnihy
        select new { VydavatelNazev = vydavatel.Nazev, Knihy = vydavatelKnihy };

        foreach (var item in souhrnQuery)
        {
            Console.WriteLine("Vydatatel: {0}", item.VydavatelNazev);
            foreach (var item2 in item.Knihy)
            {
                Console.WriteLine("{0}. {1}", item2.Autor, item2.Nazev);
            }
            Console.WriteLine();
        }

        Console.ReadKey();
    }
}