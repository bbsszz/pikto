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
        public LearningPathWindow()
        {
			InitializeComponent();
            img = new Image<Bgr, byte>(640, 480, new Bgr(255, 127, 127));

            
            db = new Database.DatabaseService();
            pictoRecognitionAndXnaView = new PiktoRecognitionAndXNAViewer();
            pictoRecognitionAndXnaView.initialize(db);

            camera = new Camera();
            camera.TimeElapsed += displayFrame;
        }

		// TODO to be refactored

		PiktoRecognitionAndXNAViewer pictoRecognitionAndXnaView;
        Image<Bgr, Byte> img;
        Database.DatabaseService db;

        Camera camera;

        private void xnaLoad(object sender, GraphicsDeviceEventArgs e)
        {
            
            pictoRecognitionAndXnaView.createScene((GraphicsDeviceControl)sender, e.GraphicsDevice);
        }

        private void renderXna(object sender, GraphicsDeviceEventArgs e)
        {
            pictoRecognitionAndXnaView.render(img);
        }

        private void displayFrame(object sender, CameraEventArgs e)
        {
            img = e.Image;
        }
	}
}
