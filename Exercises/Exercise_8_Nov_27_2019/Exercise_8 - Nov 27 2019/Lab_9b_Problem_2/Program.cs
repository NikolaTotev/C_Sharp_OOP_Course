using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9b_Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            AlarmClock clock = new AlarmClock();
            clock.Alarm += OnRing1;
            clock.Alarm += OnRing2;
            clock.PropertyChanged += OnPropertyChanged;
            clock.Rings = 5;
            clock.RingTimes = 3000;
            clock.Start();
        }

        private static void OnRing1(object sender, EventArgs args)
        {
            int rings = ((AlarmEventArgs)args).NRings;
            Console.WriteLine("Ring1: {0}", rings);
        }
        private static void OnRing2(object sender, EventArgs args)
        {
            int rings = ((AlarmEventArgs)args).NRings;
            Console.WriteLine("Ring2: {0}", rings);
        }

        private static void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            Console.WriteLine("New ringtime setup. {0}", args.PropertyName);
            AlarmClock ac = sender as AlarmClock;
            if (ac != null)
            {


                switch (args.PropertyName)
                {
                    case "Rings":
                        Console.WriteLine("New ringtime setup. {0} - {1}", args.PropertyName, ac.RingTimes);

                        break;
                    case "RingTimes":
                        Console.WriteLine("New ringtime setup. {0} - {1}", args.PropertyName, ac.RingTimes);

                        break;
                }
            }

        }
    }
}
