class Vektor<T>
{
    T[] pole;
    int kapacita;
    // ...
}
class Slovnik<K, H>
{
    Vektor<K> klice;
    Vektor<H> hodnoty;
    public Slovnik()
    {
        klice = new Vektor<K>();
        hodnoty = new Vektor<H>();
    }
    public void Pridej(K klic, H hodnota)
    {
        // ...
    }
}
class Program
{
    static void Main(string[] args)
    {
        Slovnik<int, string> slovnik = new Slovnik<int, string>();
        slovnik.Pridej(1, "text");
        // ...
    }
}