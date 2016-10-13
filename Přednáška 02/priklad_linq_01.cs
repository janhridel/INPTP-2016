using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cisla = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            IEnumerable<int> lichaCisla =
                from cislo in cisla
                where cislo % 2 == 1
                orderby cislo
                select cislo;

            foreach (var item in lichaCisla)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }

}
