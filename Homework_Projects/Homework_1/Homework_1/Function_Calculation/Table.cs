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

        /// <summary>
        /// Constructor, initializes all fields with default values.
        /// startValue = 0;
        /// endValue = 5;
        /// stepSize = 1;
        /// </summary>
        public Table(double startValue = 0, double endValue = 5, double stepSize = 1) //Constructor start;
        {
            StartValue = startValue;//Init startValue;
            EndValue = endValue;//Init endValue;
            StepSize = stepSize;//Init stepSize;
        }
        #region Properties
        public double EndValue //EndValue property begin;
        {
            get => endValue;
            set => endValue = value;
        }//EndValue property end;

        public double StartValue//StartValue property begin;
        {
            get => startValue;
            set => startValue = value;
        }//StartValue property end;

        public double StepSize//StepSize property being;
        {

            get => stepSize;
            set => stepSize = value;
        }//StepSize property end;

        #endregion

        public void MakeTable() //Make table method begin;
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
        }//Make table method end;
    }
}