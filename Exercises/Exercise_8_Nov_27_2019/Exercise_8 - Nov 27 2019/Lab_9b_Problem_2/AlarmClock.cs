using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Lab_9b_Problem_2
{
    class AlarmClock: INotifyPropertyChanged
    {
        //Step 2 Publisher: event source;
        //Publish the alarm event
        public event EventHandler Alarm; //publish event Alar
        public event PropertyChangedEventHandler PropertyChanged; // this even is the NotifyPropertyChanged interface.
        private int _rings;
        private int _ringTimes;

        public int RingTimes
        {
            get { return _ringTimes; }
            set
            {
                _ringTimes = value >= 0 ? value : 0;
                if (_ringTimes > 0) PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RingTimes)));
            }
        }


        public int Rings
        {
            get { return _rings; }
            set { _rings = value >= 0 ? value : 0; }
        }

        /// <summary>
        /// Raise event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnAlarm(AlarmEventArgs e) => Alarm?.Invoke(this, e);
        // {
        //     Alarm?.Invoke(this, e);
        //  }

        public void Start()
        {
            //What is this thingy
            //creates an object of type task. when we get out of using the memory for task is freed
            using (var task = Task.Delay(_ringTimes)) 
            {
                task.Wait();
            }

            while(true)
            {
                _rings--;

                if (_rings < 0)
                {
                    break;
                }
                //ring as subscriber has defined 
                OnAlarm(new AlarmEventArgs(_rings));
            }
        }
    }
}
