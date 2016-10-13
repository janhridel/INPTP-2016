class Program
{
    static void Main(string[] args)
    {
        string[] radky = { "1, 2, 3, 4", "5, 6, 7, 8", "9, 10, 11, 12" };
        
        IEnumerable<int> cislaQuery =
        from radek in radky
        let texty = radek.Split(',')
        from text in texty
        let cislo = int.Parse(text)
        select cislo;
    
        foreach (int item in cislaQuery)
        {
            Console.Write(item + " ");
        }
        
        Console.ReadKey();
    }
}