class Obecne
{
    public static void Vymena<T>(ref T x, ref T y)
    {
        T pom = x;
        x = y;
        y = pom;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int a = 10, b = 20;
        Console.WriteLine("Před výměnou: a = {0}, b = {1}", a, b);
        Obecne.Vymena(ref a, ref b);
        // Obecne.Vymena<int>(ref a, ref b); // dtto předchozí příkaz
        Console.WriteLine("Po výměně: a = {0}, b = {1}", a, b);
        Console.ReadKey();
    }
}