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
                new Osoba { Jmeno = "Karel", Prijmeni = "Hřídel" },
                new Osoba { Jmeno = "Adela", Prijmeni = "Nováková" },
                new Osoba { Jmeno = "Josef", Prijmeni = "Hřídel" } };

        IEnumerable<Osoba> osobyQuery =
        from osoba in osoby
        orderby osoba.Prijmeni descending, osoba.Jmeno
        select osoba;

        foreach (var item in osobyQuery)
        {
            Console.WriteLine("{0} {1}", item.Prijmeni, item.Jmeno);
        }

        Console.ReadKey();
    }
}