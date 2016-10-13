class Osoba
{
    public string Jmeno { get; set; }
    public int Vek { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Osoba[] osoby = {
            new Osoba { Jmeno = "Karel", Vek = 30 },
            new Osoba { Jmeno = "Josef", Vek = 25 },
            new Osoba { Jmeno = "Jana", Vek = 36 },
            new Osoba { Jmeno = "Aneta", Vek = 40 } };

        IEnumerable<IGrouping<int, Osoba>> osobyQuery =
            from osoba in osoby
            group osoba by osoba.Vek / 10 into osobaGroup
            where osobaGroup.Key > 2
            select osobaGroup;

        foreach (IGrouping<int, Osoba> item in osobyQuery)
        {
            Console.WriteLine("\nVek {0} až {1}:",
            item.Key * 10, item.Key * 10 + 9);
            foreach (Osoba item2 in item)
            {
                Console.WriteLine("{0}, {1}", item2.Jmeno, item2.Vek);
            }
        }

        Console.ReadKey();
    }
}