using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9b_Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Subject> list = new List<Subject>();
            string[] titles = new string[] { "English", "Math", "CS" };
            Random r = new Random();
            int[] grades;
            for (int i = 0; i < Subject.MAX_GRADE; i++)
            {
                grades = new int[Subject.MAX_GRADE];
                for (int j = 0; j < Subject.MAX_GRADE; j++)
                {
                    grades[j] = r.Next(0, 151);
                }
                Subject s = new Subject(titles[i], grades);
                Console.WriteLine(s);
                Console.WriteLine();
                list.Add(s);
            }

            StudentCardReport report = new StudentCardReport(list);
            report.PassOrFail += OnPassOrFail;
            report.ProcessReport();
        }

        private static void OnPassOrFail(object sender, EventArgs args)
        {
            Subject subject = (Subject)args;
            string output = subject.Title + "Congratulations: Passing";
            Console.WriteLine(output);
        }
    }
}
