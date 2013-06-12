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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Emgu.CV;
using Emgu.CV.Structure;
using Pikto.Database;
using System.Windows.Threading;

namespace Pikto.View
{
	/// <summary>
	/// Interaction logic for LearningPathWindow.xaml
	/// </summary>
	public partial class LearningPathWindow : Page
	{
        PiktoRecognitionAndXNAViewer pictoRecognitionAndXnaView;
        Image<Bgr, Byte> img;
        Database.DatabaseService db;
        public LearningPathWindow()
        {
            InitializeComponent();
            img = new Image<Bgr, byte>(640, 480, new Bgr(255, 255, 0));
         
            db = new Database.DatabaseService();
            pictoRecognitionAndXnaView = new PiktoRecognitionAndXNAViewer();
            pictoRecognitionAndXnaView.initialize(db);
            
            Camera camera = new Camera();
            camera.TimeElapsed += new EventHandler<CameraEventArgs>(displayImage);
        }
        private void displayImage(object s, CameraEventArgs e)
        {
            img = e.Image;
         }

        
        private void xnaLoad(object sender, GraphicsDeviceEventArgs e)
        {
            
            pictoRecognitionAndXnaView.createScene((GraphicsDeviceControl)sender, e.GraphicsDevice);
        }

        private void renderXna(object sender, GraphicsDeviceEventArgs e)
        {
            pictoRecognitionAndXnaView.render(img);
        }


	}
}
