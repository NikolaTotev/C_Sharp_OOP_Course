using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountApp
{
    public class Time
    {
        private int hour;
        private int minute;
        private int second;

        public Time(int hour)
        {
            Hour = hour;
        }

        public int Hour
        {
            get => default;
            set
            {
                if (value != null)
                {
                    hour = value;
                }
            }
        }

        public int Minute
        {
            get => default;
            set
            {
                if (value != null)
                {
                    minute = value;
                }
            }
        }

        public int Second
        {
            get => default;
            set
            {
                if (value != null)
                {
                   second = value;
                }
            }
        }
    }
}