using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Function_Calculation
{
    public class Table
    {
        #region Fields

        private double startValue;
        private double endValue;
        private double stepSize;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor, initializes all fields with default values.
        /// startValue = 0;
        /// endValue = 5;
        /// stepSize = 1;
        /// </summary>
        public Table(double startValue = 0, double endValue = 5, double stepSize = 1)
        {
            StartValue = startValue;
            EndValue = endValue;
            StepSize = stepSize;
        }

        #endregion

        #region Properties
        public double EndValue 
        {
            get => endValue;
            set => endValue = value;
        }

        public double StartValue
        {
            get => startValue;
            set => startValue = value;
        }

        public double StepSize
        {

            get => stepSize;
            set => stepSize = value;
        }

        #endregion

        /// <summary>
        /// Make table method. Contains the algorithm that tabulates the results of the function.
        /// </summary>
        public void MakeTable() 
        {
            Console.WriteLine("Input value    Output value");
            int outputCounter = 0;
            for (double i = StartValue; i < EndValue; i += StepSize)
            {
                if (outputCounter % 20 == 0 && outputCounter != 0)
                {
                    Console.WriteLine("Press enter to continue...");
                    while (Console.ReadKey().Key != ConsoleKey.Enter)
                    {
                        if (Console.ReadKey().Key == ConsoleKey.Escape)
                        {
                            Console.WriteLine("Exiting program.");
                            return;
                        }
                    }
                }

                outputCounter++;
                double functionValue = (Math.Abs((i - 2) * (i - 2)) / (i * i + 1));
                Console.WriteLine("{0, 4}{1,15}", i, functionValue);

            }
        }
    }
}