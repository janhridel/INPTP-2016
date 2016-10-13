class Program
{
    static void Main(string[] args)
    {
        string[] pole1 = new string[] { "Text1", "Text2", "Text3" };
        int[] pole2 = new int[] { 10, 20, 30 };
        int index = 0;

        var query =
        from item in pole1
        select new { Text = item, Cislo = pole2[index++] };
        foreach (var item in query)
        {
            Console.WriteLine("Text = {0}, Cislo = {1}", item.Text, item.Cislo);
        }

        Console.WriteLine();

        index = 0; // #1
        foreach (var item in query)
        {
            Console.WriteLine("Text = {0}, Cislo = {1}", item.Text, item.Cislo);
        }
        Console.ReadLine();
    }
}