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

namespace Lab_11_Problem_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Binding b = new Binding
            {
                ElementName = "SlrValue",
                Path = new PropertyPath("Value")
            };
            //b.StringFormat = "{0:F2}";
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            b.Converter = new ValueConverter(); 
            TxtBindWithCode.SetBinding(TextBox.TextProperty, b);
        }
    }
}
