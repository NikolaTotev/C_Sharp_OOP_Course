using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
using Microsoft.Win32;
using Lab11Prob1ClassLibrary;

namespace Lab11Prob1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FileStream fs;
        private BinaryFormatter binaryFmtr;
        public MainWindow()
        {
            InitializeComponent();
            binaryFmtr = new BinaryFormatter();
            btnOpen.IsEnabled = true;
            btnWrite.IsEnabled = false;
            btnClose.IsEnabled = false;
        }


        private void BtnOpen_OnClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            bool? result = fileDialog.ShowDialog();
            if (result.HasValue)
            {
                string fileName = fileDialog.FileName;
                try
                {

                    fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                    btnOpen.IsEnabled = false;
                    usStorageUI.ClearBoxes();
                }
                catch (IOException)
                {

                    MessageBox.Show("Unable to open or create file...");
                    System.Environment.Exit(1);
                }
            }
        }

        private void BtnWrite_OnClick(object sender, RoutedEventArgs e)
        {
            string[] data = usStorageUI.ReadTextBoxValues();
            Student stud = new Student(

                data[0],
                data[1],
                data[2],
                data[3],
                int.Parse(data[4])
            );
            try
            {
                binaryFmtr.Serialize(fs, stud);

            }
            catch (SerializationException)
            {

                MessageBox.Show("Failed to write to file...");
            }
        }

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            fs?.Close(); //What is this question mark for?
            btnWrite.IsEnabled = false;
            btnOpen.IsEnabled = true;
        }
    }
}
