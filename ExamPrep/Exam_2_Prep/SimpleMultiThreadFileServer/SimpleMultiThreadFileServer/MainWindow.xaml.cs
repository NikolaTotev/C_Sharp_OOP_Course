﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace SimpleMultiThreadFileServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FileServer m_Server;
        public MainWindow()
        {
            InitializeComponent();
            m_Server = new FileServer();
            m_Server.ServerNotification += DisplayMessage;
            m_Server.Start();
        }

        private void DisplayMessage(string message)
        {
            if (Tb_Display.Dispatcher != null && !Tb_Display.Dispatcher.CheckAccess())
            {
                Tb_Display.Dispatcher.Invoke(new Action(() => Tb_Display.Text = $"\r\n{Tb_Display.Text}" + message));
            }
            else
            {
                Tb_Display.Text = $"\r\n{Tb_Display.Text}" + message;
            }
        }

        private void Tb_Input_OnKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            m_Server.Stop();
        }
    }
}
