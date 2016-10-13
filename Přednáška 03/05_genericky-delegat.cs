interface IZasobnik<T>
{
    void Vloz(T obj);
    T Odeber();
}
class GenZasobnik<T> : IZasobnik<T>
{
    // ...
    public void Vloz(T obj)
    { //... 
    }
    public T Odeber()
    { //...
    }

    public T Najdi(Predikat<T> predikat)
    {
        for (int i = 0; i < pocet; i++)
        {
            if (predikat(pole[i])) return pole[i];
        }
        return default(T);
    }
}
class Program
{
    static void Main(string[] args)
    {
        GenZasobnik<string> zasobnik = new GenZasobnik<string>();
        for (int i = 0; i < 4; i++)
        {
            Console.Write("Zadej {0}. text: ", i + 1);
            zasobnik.Vloz(Console.ReadLine());
        }
        Console.Write("Zadej počáteční text: ");
        string pocatek = Console.ReadLine();
        string text = zasobnik.Najdi(x => x.StartsWith(pocatek));
        if (text == null) Console.WriteLine("Text nebyl nalezen");
        else Console.WriteLine("Nalezený text: " + text);
        Console.ReadKey();
    }
}
