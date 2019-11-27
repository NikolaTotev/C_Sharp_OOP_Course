using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9b_Problem_1
{
    class StudentCardReport
    {
        public event EventHandler PassOrFail;
        private List<Subject> listOfGrades;

        public StudentCardReport(List<Subject> list)
        {
            listOfGrades = new List<Subject>(list);
        }

        protected virtual void OnPassOrFail(EventArgs args) => PassOrFail?.Invoke(this, args);


        public void ProcessReport()
        {
            foreach (var item in listOfGrades)
            {
                double avrg;
                avrg = item.grades.Average(v => v);
                if (avrg < 75)
                {
                    Console.WriteLine("{0}: Grade - F", item.Title);
                }
                OnPassOrFail(item);

                //foreach (var grade in item.Grades)
                //{
                //    if (grade < 75)
                //    {
                //        Console.WriteLine("{0}: Grade - F", item.Title);
                //    }
                //    OnPassOrFail(item);
                //}
            }
        }
    }
}
