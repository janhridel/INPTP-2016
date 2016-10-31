using System;
using System.Collections.Generic;
using System.Text;

namespace Omezeni02
{
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
                if (item.Id == id) return index;
                //if ((item as Entita).Id == id) return index; // OK
                //if (((Entita)item).Id == id) return index; // Chyba
                index++;
            }
            return -1;
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
                    {
                        //if (((IComparable)pole[j]).CompareTo(pole[j + 1]) > 0) { //OK
                        //if ((pole[j] as IComparable).CompareTo(pole[j + 1]) > 0) { // OK
                        T prvek = pole[j];
                        pole[j] = pole[j + 1];
                        pole[j + 1] = prvek;
                        vymena = true;

                    }
                }
                if (!vymena) return;
            }
        }
        public void Vypis()
        {
            foreach (T item in pole)
            {
                Console.WriteLine(item);
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
            Console.WriteLine("Uživatel s hledaným Id je na indexu " + index);
            uzivatelSeznam.Serad();
            Console.WriteLine("Po utřídění");
            uzivatelSeznam.Vypis();
            Console.ReadKey();
        }
    }
}
