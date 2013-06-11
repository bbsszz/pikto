using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace Pikto.View
{
    /// <summary>
    /// Interaction logic for MetroMessageBox.xaml
    /// </summary>
    public partial class PiktoMessageBox : Window
    {
        private MessageBoxButton _buttons = MessageBoxButton.OK;
        private String _msg = "";
        public PiktoMessageBox(String message, MessageBoxButton mode)
        {
            _buttons = mode;
            //Left = -50;
            this.Message = message;
            Top = System.Windows.SystemParameters.PrimaryScreenHeight / 2 - (150);
            Width = System.Windows.SystemParameters.PrimaryScreenWidth + 100;
            InitializeComponent();
            base.DataContext = this;
        }



        public String Message
        {
            get { return this._msg; }
            set { this._msg = value; }
        }

        public Visibility IsOkButtonVisible
        {
            get { if (_buttons == MessageBoxButton.OK || _buttons == MessageBoxButton.OKCancel) return Visibility.Visible; else return Visibility.Hidden; }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
