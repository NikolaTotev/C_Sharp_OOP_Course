using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9b_Problem_1
{
    class Subject : EventArgs
    {
        public const int MAX_GRADE = 5;
        public string Title { get; set; }
        public int[] grades;

        public Subject(string title, int[] grades)
        {
            Title = title;
            Grades = grades;
        }

        public int[] Grades
        {
            get
            {
                int[] temp = new int[grades.Length];
                grades.CopyTo(temp, 0);
                return temp;
            }
            set
            {
                if (value != null && value.Length == MAX_GRADE)
                {
                    grades = new int[MAX_GRADE];
                    for (int i = 0; i < MAX_GRADE; i++)
                    {
                        grades[i] = value[i];
                    }
                }
                else
                {
                    grades=new int[MAX_GRADE];
                }
            }
        }

        public override string ToString()
        {
            string ouput = Title + "[" + string.Join(", ", grades) + "]";
            return ouput;
        }
    }
}
