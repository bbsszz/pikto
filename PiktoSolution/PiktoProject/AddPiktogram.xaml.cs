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

namespace Pikto
{
    /// <summary>
    /// Interaction logic for AddPiktogram.xaml
    /// </summary>
    public partial class AddPiktogram : Window
    {
        DatabaseService db;
        public AddPiktogram()
        {
            InitializeComponent();
            db = new DatabaseService();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
