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

namespace Lab11Prob1ClassLibrary
{
    /// <summary>
    /// Interaction logic for StorageUI.xaml
    /// </summary>
    public partial class StorageUI : UserControl
    {
        private int txtBoxCount;
        public StorageUI()
        {
            InitializeComponent();
        }

        public void ClearBoxes()
        {
            foreach (var item in GrdMain.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Clear();
                }
            }
        }

        public void SetTextBoxValues(string[] values)
        {
            if (values.Length != txtBoxCount)
            {
                return;
            }

            txtID.Text = values[0];
            txtFirstName.Text = values[1];
            txtLastName.Text = values[2];
            txtCourseName.Text = values[3];
            txtGrade.Text = values[4];
        }

        public string[] ReadTextBoxValues()
        {
            string[] values = new string[txtBoxCount];
            int counter = 0;

            foreach (var item in GrdMain.Children)
            {
                if (item is TextBox)
                {
                    values[counter++] = ((TextBox) item).Text;
                } 
            }
            txtID.Text = values[0];
            txtFirstName.Text = values[1];
            txtLastName.Text = values[2];
            txtCourseName.Text = values[3];
            txtGrade.Text = values[4];
            return values;
        }
    }

}
