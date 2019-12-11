using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DataBindingExample7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Person> people = new ObservableCollection<Person>();
        private void BtnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            people.Add(new Person("Petya Assenova", 62));
        }
        // The rest of code of class MainWindow is unchanged
        private void BtnChangePerson_Click(object sender, RoutedEventArgs e)
        {
            if (MyListBox.SelectedItem != null)
                (MyListBox.SelectedItem as Person).Name = "Random Name";
        }
        public MainWindow()
        {
            InitializeComponent();
            Binding b = new Binding
            { // Initialze the same attributes as in XAML
                ElementName = "TxtBox1",
                Path = new PropertyPath("Text")

            };
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            TxtBox3.SetBinding(TextBox.TextProperty, b);

            people.Add(new Person("Ivan Ivanov", 39));
            people.Add(new Person("Petar Petrov", 21));
            people.Add(new Person("John Atanasoff", 80));
            StcPanel.DataContext = people;
            people.Add(new Person("Petya Petrova", 32));
        }


    }
}
