using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_RozsirujiciMetody
{
    static class StringExt
    {
        public static int WordCount(this string s)
        {
            return WordCount(s, ' ', '.');
        }

        public static int WordCount(this string s, params char[] separators)
        {
            return s.Split(separators, StringSplitOptions.RemoveEmptyEntries).Length;
        }

    }

    static class ArrayExt
    {
        public static int MinimumIndex<T>(this T[] array) where T : IComparable<T>
        {
            if (array.Length == 0)
                throw new ArgumentException("Pole je prazdné", "array");
            int minIndex = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(array[minIndex]) < 0)
                {
                    minIndex = i;
                }
            }
            return minIndex;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string s = "Text1,text2 text3";
            int wc = s.WordCount(); // #1
            int wc2 = s.WordCount(' ', '.', ',', ';');
            Console.WriteLine("Počet slov - varianta A: {0}", wc);
            Console.WriteLine("Počet slov - varianta B: {0}", wc2);
            int[] pole = { 3, 4, 1, 2 };
            int minIndex = pole.MinimumIndex();
            Console.WriteLine("Minimální prvek v poli je {0}, má pořadové číslo {1}",
            pole[minIndex], minIndex + 1);
            Console.ReadKey();
        }
    }
}
