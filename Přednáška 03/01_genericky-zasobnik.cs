class GenZasobnik<T>
{
    T[] pole = new T[100];
    int pocet;
    public void Vloz(T obj)
    {
        if (pocet < pole.Length) pole[pocet++] = obj;
    }
    public T Odeber()
    {
        if (pocet > 0) return pole[--pocet];
        throw new InvalidOperationException("Zasobník je prázdný");
    }
}
class Program
{
    static void Main(string[] args)
    {
        GenZasobnik<int> zasobnik = new GenZasobnik<int>();
        zasobnik.Vloz(1);
        zasobnik.Vloz(2);
        // zasobnik.Vloz("aaa"); // Chyba
        int cislo = zasobnik.Odeber();
        Console.WriteLine(cislo);
        Console.ReadKey();
    }
}