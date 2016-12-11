using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FondPodprocesu02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> prvocisla = new List<int>();
            const int pocetPodprocesu = 5;
            int pocetPracovnich, pocetIO;
            ThreadPool.SetMinThreads(pocetPodprocesu, pocetPodprocesu); // #1
            ThreadPool.GetMinThreads(out pocetPracovnich, out pocetIO);
            Console.WriteLine("Minimální počet podprocesů: pracovních: {0}, I/O: {1}", pocetPracovnich, pocetIO);
            ThreadPool.GetMaxThreads(out pocetPracovnich, out pocetIO);
            Console.WriteLine("Maximální počet podprocesů: pracovních: {0}, I/O: {1}", pocetPracovnich, pocetIO);
            AutoResetEvent[] events = new AutoResetEvent[pocetPodprocesu];
            for (int i = 0; i < pocetPodprocesu; i++)
            {
                events[i] = new AutoResetEvent(false);
                int d = i * 10000;
                int h = i * 10000 + 10000 - 1;
                AutoResetEvent e = events[i];
                ThreadPool.QueueUserWorkItem(x => Start(d, h, 500, prvocisla, e));
            }
            WaitHandle.WaitAll(events);
            Console.WriteLine("Seznam prvočísel");
            Vypis(prvocisla);
            Console.WriteLine("Konec - libovolná klávesa");
            Console.ReadKey();
        }
        static void Start(int dolni, int horni, int pocetVyskytu, List<int> prvocisla, AutoResetEvent ukonceniEvent)
        {
            Console.WriteLine(@"Spušten podproces Id {0}, dolni: {1}, horni: {2}",
               Thread.CurrentThread.ManagedThreadId, dolni, horni);
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
