using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double x; //input value;
            double eps; //accuracy;
            double sum; //output approx cos()val;
            double term; //current term;
            int counter;
            int sign;
            //initialization;
            Console.WriteLine("Enter accuracy");
            eps = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter x");
            x = Convert.ToDouble(Console.ReadLine());

            term = 1;
            sum = term;
            counter = 1;
            sign = -1;
            do
            {
                term = term*x*x/(2 * counter*(2*counter-1));
                sum += term;
                sign = -sign;
                counter++;
                term = (term >= 0) ? term : -term;

            }

            while (term>eps);

            Console.WriteLine("Approx cos({0}):{1}",x, sum);
            Console.WriteLine("Accurate cos({0}):{1}", x, Math.Cos(x));

        }
    }
}
