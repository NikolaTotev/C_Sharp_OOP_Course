using System;
using System.Collections.Generic;
using System.IO;
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
using Common;

namespace Components
{
    /// <summary>
    /// Interaction logic for DataForm.xaml
    /// </summary>
    public partial class DataForm : UserControl
    {
        #region Dependencty Properties

        public static readonly DependencyProperty BtnSaveTextProperty = DependencyProperty.Register(
            "BtnSaveText", typeof(string), typeof(DataForm), new PropertyMetadata(default(string)));

        public string BtnSaveText
        {
            get { return (string)GetValue(BtnSaveTextProperty); }
            set
            {
                SetValue(BtnSaveTextProperty, value);
                Btn_Save.Content = value;
            }
        }


        public static readonly DependencyProperty BtnRequestTextProperty = DependencyProperty.Register(
            "BtnRequestText", typeof(string), typeof(DataForm), new PropertyMetadata(default(string)));

        public string BtnRequestText
        {
            get { return (string)GetValue(BtnRequestTextProperty); }
            set
            {
                SetValue(BtnRequestTextProperty, value);
                Btn_Request.Content = value;
            }
        }


        public static readonly DependencyProperty LbFileContentsTextProperty = DependencyProperty.Register(
            "LbFileContentsText", typeof(string), typeof(DataForm), new PropertyMetadata(default(string)));

        public string LbFileContentsText
        {
            get { return (string)GetValue(LbFileContentsTextProperty); }
            set
            {
                SetValue(LbFileContentsTextProperty, value);
                Lb_FileContents.Content = value;
            }
        }

        public static readonly DependencyProperty LbFileNameTextProperty = DependencyProperty.Register(
            "LbFileNameText", typeof(string), typeof(DataForm), new PropertyMetadata(default(string)));

        public string LbFileNameText
        {
            get { return (string)GetValue(LbFileNameTextProperty); }
            set
            {
                SetValue(LbFileNameTextProperty, value);
                Lb_Name.Content = value;
            }
        }

        #endregion

        public delegate void SaveEvent(object sender, SaveEventArgs args);

        public delegate void RequestEvent(object sender, RequestEventArgs args);

        public event SaveEvent ButtonSaveClicked;

        public event RequestEvent ButtonRequestClicked;

        public DataForm()
        {
            InitializeComponent();
        }

        private void Btn_Save_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Tbx_FileName.Text))
            {
                TextRange RtfText = new TextRange(Rtf_FileContents.Document.ContentStart, Rtf_FileContents.Document.ContentEnd);
                FileDataRecord record = new FileDataRecord(Tbx_FileName.Text, RtfText.Text);
                SaveEventArgs args = new SaveEventArgs(Common.CommandsHelper.SaveCommand, record);
                ButtonSaveClicked?.Invoke(sender, args);
            }
        }

        private void Btn_Request_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Tbx_FileName.Text))
            {
                RequestEventArgs args = new RequestEventArgs(Common.CommandsHelper.RequestCommand, Tbx_FileName.Text);
                ButtonRequestClicked?.Invoke(sender, args);
            }
        }

        public void DisplayFileData(string record)
        {

            if (Rtf_FileContents.Dispatcher != null && !Rtf_FileContents.Dispatcher.CheckAccess())
            {
                Rtf_FileContents.Dispatcher.Invoke(new Action(() => {
                    MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(record));
                    Rtf_FileContents.Selection.Load(stream, DataFormats.Rtf);
                }));
            }
            else
            {
                MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(record));
                Rtf_FileContents.Selection.Load(stream, DataFormats.Rtf);
            }

        }
        protected virtual void OnButtonSaveClicked(SaveEventArgs args)
        {
            ButtonSaveClicked?.Invoke(this, args);
        }

        protected virtual void OnButtonRequestClicked(RequestEventArgs args)
        {
            ButtonRequestClicked?.Invoke(this, args);
        }
    }
}
