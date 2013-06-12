using System;
using System.Windows.Controls;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Windows.Input;
using System.Windows;

namespace Pikto.View
{
	/// <summary>
	/// Interaction logic for LearningPathWindow.xaml
	/// </summary>
	public partial class LearningPathWindow : Page
	{
        XnaWindow xnaWindow = new XnaWindow();

        public LearningPathWindow()
        {
            InitializeComponent();
            xnaWindow.Show();

            //img = new Image<Bgr, byte>(640, 480, new Bgr(255, 0, 0));

         
            //db = new Database.DatabaseService();
            //pictoRecognitionAndXnaView = new PiktoRecognitionAndXNAViewer();
            //pictoRecognitionAndXnaView.initialize(db);

            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            xnaWindow.Close();
            this.closeButton.Visibility = System.Windows.Visibility.Hidden;
        }


        



	}
}
