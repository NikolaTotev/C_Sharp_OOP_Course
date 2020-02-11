using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab13_Clock
{
    /// <summary>
    /// Interaction logic for Clock.xaml
    /// </summary>
    public partial class Clock : UserControl
    {
        private bool m_Suspended;
        public Clock()
        {
            m_Suspended = false;
            Thread tick = new Thread(new ThreadStart(ClockTick));
            tick.Start();
        }

        private void ClockTick()
        {
            if (Rect_HourHand == null || RectMinHand == null || Rect_SecondHand == null)
            {
                return;
            }
            SetTime();
            while (true)
            {
                SetTime();
                Thread.Sleep(1000);
                lock (this)
                {
                    while (m_Suspended)
                    {
                        Monitor.Wait(this);
                    }
                }
            }
        }

        public void Resume()
        {
            lock (this)
            {
                m_Suspended = true;
                Monitor.Pulse(this);
            }
        }

        public void Suspend()
        {
            m_Suspended = true;
        }
        public void SetTime()
        {
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            int second = DateTime.Now.Second;

            Dispatcher.Invoke(new Action(() =>
                {
                    Rt_Hour.Angle = hour * 30 + minute * 0.5;
                    Rt_Min.Angle = minute * 6;
                    Rt_Sec.Angle = second * 6;
                }
                ));
        }

    }
}
