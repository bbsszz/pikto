using System;
using System.IO;
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
using Emgu.CV.UI;
using Emgu.CV.Structure;
using System.Runtime.InteropServices;
using System.Windows.Threading;
using Pikto.RecognitionPath.DiscretizationModule;
using Pikto.RecognitionPath.Classifier;
using AdaptiveResonanceTheory1;
using Pikto.RecognitionPath.ClassMapper;
using Pikto.RecognitionPath;

namespace Pikto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PiktoRecognitionAndXNAViewer pictoRecognitionAndXnaView;
        Image<Bgr, Byte> img;
        Database.DatabaseService db;
        public MainWindow()
        {
            InitializeComponent();
            img = new Image<Bgr, byte>(640, 480, new Bgr(255, 255, 0));
         
            db = new Database.DatabaseService();
            pictoRecognitionAndXnaView = new PiktoRecognitionAndXNAViewer();
            pictoRecognitionAndXnaView.initialize(db);
        }
        private void displayImage(object s, CameraEventArgs e)
        {
            img = e.Image;
         }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            

            Camera camera = new Camera();
            camera.TimeElapsed += new EventHandler<CameraEventArgs>(displayImage);
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
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
