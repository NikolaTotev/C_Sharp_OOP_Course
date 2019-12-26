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
using BackendLogic;

namespace Frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public HeavyElement[] HeavyElementArray { get; set; }
        private int m_CurrentIndex=0;
        public MainWindow()
        {
            InitializeComponent();
            MyPoint pointA = new MyPoint(1, 5);
            MyPoint pointB = new MyPoint(10, 24);

            Line myLineA = new Line(1, 3, 5, 2);
            Line myLineB = new Line(1, 3, 5, 2);

            HeavyElementArray = new HeavyElement[4]
            {
                pointA, pointB,myLineA, myLineB
            };

            HeavyElementArray = MixHeavyObjects(HeavyElementArray);
        }

        private HeavyElement[] MixHeavyObjects(HeavyElement[] hs)
        {
            Random r = new Random();
            for (int i = hs.Length; i > 0; i--)
            {
                int j = r.Next(i);
                HeavyElement k = hs[j];
                hs[j] = hs[i - 1];
                hs[i - 1] = k;
            }
            return hs;
        }

        private void ChangeIndex()
        {
            if (m_CurrentIndex != 4)
            {
                m_CurrentIndex++;
                return;
            }

            m_CurrentIndex = 0;

        }

        private void BtnLines_OnClick(object sender, RoutedEventArgs e)
        {
          
            string LineItems = "";
            foreach (var heavyElement in HeavyElementArray)
            {
                if (heavyElement is Line)
                {
                    LineItems+= $" {heavyElement.Weight}";
                }
            }
            TbLineArea.Text = string.Format("Current index: {0}, PointItems: {1}", m_CurrentIndex, LineItems);
            ChangeIndex();
        }

        private void BtnPoints_OnClick(object sender, RoutedEventArgs e)
        {
            string PointItems = "";
            foreach (var heavyElement in HeavyElementArray)
            {
                if (heavyElement is Point)
                {
                    PointItems+= $" {heavyElement.Weight}";
                }
            }
            TbLineArea.Text = string.Format("Current index: {0}, PointItems: {1}", m_CurrentIndex, PointItems);
            ChangeIndex();
        }

        private void Shuffle_OnClick(object sender, RoutedEventArgs e)
        {
            HeavyElementArray = MixHeavyObjects(HeavyElementArray);
        }
    }
}
