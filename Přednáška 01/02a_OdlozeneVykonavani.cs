
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 02a_OdlozeneVykonavani
{
    class Program
    {
        static void Vypis(IEnumerable<int> cisla)
        {
            foreach (var item in cisla)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] cisla = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            IEnumerable<int> lichaCisla = cisla.Where(x => x % 2 == 1);
            cisla[0] = 6;
            Vypis(lichaCisla);
            cisla[2] = 6;
            Vypis(lichaCisla);
            Console.ReadKey();
        }
    }
}
