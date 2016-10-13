class Entita : IComparable<Entita>
{
    private int id;
    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    public Entita(int id) { this.id = id; }

    public int CompareTo(Entita other)
    {
        return id.CompareTo(other.id);
    }
}
class Uzivatel : Entita
{
    private string jmeno;
    public Uzivatel(int id, string jmeno)
        : base(id)
    {
        this.jmeno = jmeno;
    }
    public override string ToString()
    {
        return string.Format("{0}, {1}", Id, jmeno);
    }
}
class EntitaSeznam<T> where T : Entita, IComparable<Entita>
{
    private T[] pole;
    public EntitaSeznam(T[] pole) { this.pole = pole; }
    public int NajdiId(int id)
    {

        int index = 0;
        foreach (T item in pole)
        {
            if (item.Id == id) return index; // #1
            index++;
        }
        return -1;
    }
    public void Vypis()
    {
        foreach (T item in pole)
        {
            Console.WriteLine(item);
        }
    }

    public void Serad()
    {
        bool vymena;
        for (int i = 0; i < pole.Length - 1; i++)
        {
            vymena = false;
            for (int j = 0; j < pole.Length - i - 1; j++)
            {
                if (pole[j].CompareTo(pole[j + 1]) > 0)
                { // #2
                    T prvek = pole[j];
                    pole[j] = pole[j + 1];
                    pole[j + 1] = prvek;
                    vymena = true;
                }
            }
            if (!vymena) return;
        }
    }

}
class Program
{
    static void Main(string[] args)
    {
        EntitaSeznam<Uzivatel> uzivatelSeznam = new EntitaSeznam<Uzivatel>(
        new Uzivatel[] { new Uzivatel(3, "Karel"),
new Uzivatel(1, "Jana"),
new Uzivatel(2, "Pavel")});
        uzivatelSeznam.Vypis();
        int index = uzivatelSeznam.NajdiId(2);
        Console.WriteLine("Uživatel s hledaným Id je na pozici " + (index + 1));
        uzivatelSeznam.Serad();
        Console.WriteLine("Po utřídění");
        uzivatelSeznam.Vypis();
        Console.ReadKey();
    }
}