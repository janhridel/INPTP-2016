using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqp2
{
    class Student
    {
        public string Jmeno { get; set; }
        public byte[] Znamky { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student[] studenti = {
                new Student { Jmeno = "Karel", Znamky = new byte[] { 1, 2, 3, 1 } },
                new Student { Jmeno = "Josef", Znamky = new byte[] { 3, 1 } },
                new Student { Jmeno = "Jana", Znamky = new byte[] { 3, 2, 4 }},
                new Student { Jmeno = "Aneta", Znamky = new byte[] { 3, 2 } } };

            var studentQuery =
                from student in studenti
                from znamka in student.Znamky
                where znamka == 1
                select student;

            foreach (var item in studentQuery)
            {
                Console.WriteLine(item.Jmeno);
            }

            Console.ReadKey();
        }
    }
}
