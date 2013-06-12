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
using Emgu.CV;
using Emgu.CV.Structure;

namespace Pikto.View
{
    /// <summary>
    /// Interaction logic for XnaWindow.xaml
    /// </summary>
    public partial class XnaWindow : Window
    {
        PiktoRecognitionAndXNAViewer pictoRecognitionAndXnaView;
        Image<Bgr, Byte> img;
        Database.DatabaseService db;

        Camera camera;
        public XnaWindow()
        {
            InitializeComponent();
            img = new Image<Bgr, byte>(640, 480, new Bgr(255, 255, 0));

            
            db = new Database.DatabaseService();
            pictoRecognitionAndXnaView = new PiktoRecognitionAndXNAViewer();
            pictoRecognitionAndXnaView.initialize(db);

            camera = new Camera();
            camera.TimeElapsed += displayFrame;
        }
        

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
