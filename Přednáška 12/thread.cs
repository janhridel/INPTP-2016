using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FondPodprocesu
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> prvocisla = new List<int>();
            AutoResetEvent[] events = new AutoResetEvent[2] { new AutoResetEvent(false), new AutoResetEvent(false) };
            ThreadPool.QueueUserWorkItem(x => Start(10000, 30000, 500, prvocisla, events[0]));
            ThreadPool.QueueUserWorkItem(x => Start(30001, 50000, 500, prvocisla, events[1]));
            WaitHandle.WaitAll(events); // #1
            Console.WriteLine("Seznam prvočísel");
            Vypis(prvocisla);
            Console.WriteLine("Konec - libovolná klávesa");
            Console.ReadKey();
        }
        static void Start(int dolni, int horni, int pocetVyskytu, List<int> prvocisla, AutoResetEvent ukonceniEvent)
        {
            Console.WriteLine(@"Spušten podproces s následujícími informacemi:
Id: {0}, IsBackground: {1}, IsThreadPoolThread: {2}",
               Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsBackground, Thread.CurrentThread.IsThreadPoolThread);
            NaplnPrvocisla(dolni, horni, pocetVyskytu, prvocisla);
            Console.WriteLine("Podproces Id {0} byl dokončen", Thread.CurrentThread.ManagedThreadId);
            ukonceniEvent.Set();
        }
        static void Vypis(IEnumerable<int> kolekce)
        {
            foreach (int item in kolekce)
            {
                Console.WriteLine(item);
            }
        }
        static void NaplnPrvocisla(int dolni, int horni, int pocetVyskytu, List<int> prvocisla)
        {
            int pocet = 0;
            for (int i = dolni; i <= horni; i++)
            {
                bool jePrvocislo = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0) jePrvocislo = false;
                }
                if (jePrvocislo)
                {
                    pocet++;
                    if (pocet == pocetVyskytu)
                    {
                        lock (((ICollection)prvocisla).SyncRoot)
                        {
                            prvocisla.Add(i);
                        }
                        pocet = 0;
                    }
                }
            }
        }
    }

}
