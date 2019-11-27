using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Digital_Clock
{
    class Clock
    {
        private Ticker pulsed;
        private TextBox display;

        public Clock(TextBox displayBox)
        {
            pulsed = new Ticker();
            this.display = displayBox;
        }

        public void Start()
        {
                pulsed.Add(this.RefreshTime);
            
        }

        public void Stop()
        {
            pulsed.Remove(this.RefreshTime);
        }

        private void RefreshTime(int hh, int mm, int ss)
        {
            this.display.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", hh, mm, ss);
        }


    }
}
