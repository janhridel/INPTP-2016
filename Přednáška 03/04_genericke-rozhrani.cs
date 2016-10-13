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
}
class Program
{
    static void Main(string[] args)
    {
        IZasobnik<int> zasobnik = new GenZasobnik<int>();
        zasobnik.Vloz(1);
        // ...
    }
}
