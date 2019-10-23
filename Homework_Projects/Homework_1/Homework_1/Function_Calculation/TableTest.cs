using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Function_Calculation
{
    public class TableTest
    {
        private double inputStartValue;
        private double inputEndValue;
        private double inputStepSize;

        #region Constructor

        //Constructor
        public TableTest()
        {

            Console.WriteLine("Please input the following values:");
            try
            {
                Console.WriteLine("Start Value:");
                InputStartValue = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("End Value:");
                InputEndValue = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Step Size Value:");
                InputStepSize = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input!");
                Console.WriteLine("Aborting execution.");
                throw;
            }




            MakeTable();
        } 
        #endregion

        #region Properties
        public double InputEndValue
        {
            get => inputEndValue;
            set
            {
                if (value != null)
                {
                    inputEndValue = value;
                }
            }
        }

        public double InputStartValue
        {
            get => inputStartValue;
            set
            {
                if (value != null)
                {
                    inputStartValue = value;
                }
            }
        }

        public double InputStepSize
        {
            get => inputStepSize;
            set
            {
                if (value != null)
                {
                    inputStepSize = value;
                }
            }
        }
        #endregion

        public void MakeTable()
        {
            if (InputEndValue < InputStartValue)
            {
                double temp = InputEndValue;
                InputEndValue = InputStartValue;
                InputStartValue = temp;
            }
            Table newTable = new Table(InputStartValue, InputEndValue, InputStepSize);
            newTable.MakeTable();
        }
    }
}