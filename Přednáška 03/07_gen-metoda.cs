delegate string FunkceCallback(int x, int y);
class Program
{
    public static string DejText<T>(T x, T y)
    {
        return string.Format("x = {0}, y = {1}", x, y);
    }
    static void Main(string[] args)
    {
        FunkceCallback f = new FunkceCallback(DejText<int>); // OK
        FunkceCallback g = new FunkceCallback(DejText); // OK
        Console.WriteLine(f(10, 20));
        Console.WriteLine(g(30, 40));
        Console.ReadKey();
    }
}