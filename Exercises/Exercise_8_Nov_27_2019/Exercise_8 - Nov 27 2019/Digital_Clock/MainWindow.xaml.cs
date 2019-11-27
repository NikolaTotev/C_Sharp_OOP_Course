using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Digital_Clock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            clock = new Clock(digital);
        }
        private void startClick(object sender, RoutedEventArgs e)
        {
            this.clock.Start();
            start.IsEnabled = false;
            stop.IsEnabled = true;
        }

        private void stopClick(object sender, RoutedEventArgs e)
        {
            this.clock.Stop();
            start.IsEnabled = true;
            stop.IsEnabled = false;
        }

        private Clock clock;
    }
}
