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
using Emgu.CV.UI;
using Emgu.CV.Structure;
using System.Runtime.InteropServices;
using System.Windows.Threading;

namespace Pikto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public delegate void EventHandler(object sender, CameraEventArgs e);

        private DispatcherTimer timer;
        MarkerDetector md;
        Xna3DViewer.AugmentedRealityForm arForm;

        ImageViewer v;
        Position3DForm.Window1 f;
        Position3D pos;
        bool mode3D;
        Image<Bgr, Byte> img;
        public MainWindow()
        {
            InitializeComponent();
            md = new MarkerDetector();
            arForm = new Xna3DViewer.AugmentedRealityForm();
            mode3D = false;
            pos = new Position3D();
        
          
        }

        private void displayImage1(object s, CameraEventArgs e)
        {
            cameraImage.Source = Camera.ToBitmapSource(e.Image);
        }

        private void displayImage(object s, CameraEventArgs e)
        {
            md.findMarkers(e.Image.Convert<Gray, Byte>());
          //  img = e.Image;

            if (md.getMarkerCount() == 1)
            {
                if (mode3D)
                {
                    pos.estimate(md.getMarkers().First());
                    List<Xna3DViewer.VirtualModel> lista = new List<Xna3DViewer.VirtualModel>();
                    lista.Add(new Xna3DViewer.VirtualModel("ship2", pos.getTransformatinMatrix(), 80.0f));
                    arForm.UpdateScene(e.Image.ToBitmap(), lista);
                }
                else
                {
                    EmguTools.draw4ContourAndCircle(img,
                    md.getMarkers().First().getContourExternal());
                    pos.estimate(md.getMarkers().First());
                    f.setImagePoint(pos.imagePoints);
                    f.setTransformatinMatrix(pos.getTransformatinMatrix());
                    f.setEstymationLabel(pos.estimatedYaw,
                    pos.estimatedPitch, pos.estimatedRoll);
                    f.updateAngle(pos.estimatedYaw,
                        pos.estimatedPitch,
                        pos.estimatedRoll);
                    EmguTools.draw3LineFromList(img, pos.getPointList(320, 240));
                }

            }
            else
            {
                if (mode3D)
                    arForm.UpdateScene(e.Image.ToBitmap(), new List<Xna3DViewer.VirtualModel>());
                else
                    cameraImage.Source = Camera.ToBitmapSource(e.Image);
            }
        }
     
        private void button1_Click(object sender, RoutedEventArgs e)
        {

           Camera camera = new Camera();
            v = new ImageViewer();
            f = new Position3DForm.Window1();
            f.setModelPoints(pos.modelPoints);
            f.Show();
            camera.TimeElapsed += new EventHandler<CameraEventArgs>(displayImage);
        }
        private void buttonXNA_Click(object sender, RoutedEventArgs e)
        {
            mode3D = true;
            
            Camera camera = new Camera();
            camera.TimeElapsed += new EventHandler<CameraEventArgs>(displayImage);
            arForm.Show();
        }

     
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            AddPiktogram addPiktogram = new AddPiktogram();
            addPiktogram.Show();

			Camera camera = new Camera();
            camera.TimeElapsed += new EventHandler<CameraEventArgs>(displayImage1);

            FindCorners.Form1 frm = new FindCorners.Form1();
            frm.Show();


        }

        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            Camera camera = new Camera();

            camera.TimeElapsed += new EventHandler<CameraEventArgs>(displayImage1);

            FindCorners.Form1 frm = new FindCorners.Form1();
            frm.Show();
        }


    }
}
