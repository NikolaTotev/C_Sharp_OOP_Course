using System.Windows.Controls;

namespace Delegates
{
	class Clock
	{
		private Ticker pulsed ;
        private TextBox display;
        
        public Clock(TextBox displayBox)
        {  
            pulsed = new Ticker();
            this.display = displayBox;
        }

        public void Start()
		{
            // To do
        }

		public void Stop()
		{
            // To do
        }

		private void RefreshTime(int hh, int mm, int ss)
		{
			this.display.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", hh, mm, ss);
		}


    }
}
