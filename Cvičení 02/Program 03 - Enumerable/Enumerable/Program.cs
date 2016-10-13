using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cisla = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            Console.WriteLine("Minimální číslo: {0}", cisla.Min());
            Console.WriteLine("Počet sudých čísel: {0}", cisla.Count(x => x % 2 == 0));
            Console.WriteLine("Maximální sudé číslo: {0}", cisla.Where(x => x % 2 == 0).Max());
            Console.ReadKey();
        }
    }
}
