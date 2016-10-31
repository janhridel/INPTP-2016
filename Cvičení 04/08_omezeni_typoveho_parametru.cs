using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_omezeni_typoveho_parametru
{
    class Entita
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public Entita(int id) { this.id = id; }
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
    class EntitaSeznam<T> where T : Entita
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
            Console.WriteLine("Uživatel s hledaným Id je na pozici " +
            (index + 1));
            Console.ReadKey();
        }
    }
}
