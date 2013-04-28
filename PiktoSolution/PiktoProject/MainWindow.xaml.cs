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
        //public delegate void EventHandler(object sender, CameraEventArgs e);
		private RecognitionPath.RecognitionPath recognitionPath;
		private ImageFacade imageFacade;

        private DispatcherTimer timer;
        MDetector md;
        MarkerPosition3D pos;
        DisplayModel dispModel;
        Image<Bgr, Byte> img;
        public MainWindow()
        {
            InitializeComponent();
            md = new MDetector();
            pos = new MarkerPosition3D(80.0f, 640.0f, 640, 480);
            img = new Image<Bgr, byte>(640, 480, new Bgr(255, 0, 0));
			var network = ART1Builder.Instance.BuildNetwork(64 * 64, 0.7f);
			var discretizer = new DiscretizationModule(64);
			var classifier = new ART1PictogramClassifier(network);
			var mapper = new ClassMapper();
			recognitionPath = new RecognitionPath.RecognitionPath(discretizer, classifier, mapper);
			imageFacade = new ImageFacade();
        }

        private void displayImage1(object s, CameraEventArgs e)
        {
           
        }

        private void displayImage(object s, CameraEventArgs e)
        {
            img = e.Image;
         /*   {
                if (mode3D)
                {
                    pos.estimate(md.getMarkers().First());
                    List<Xna3DViewer.VirtualModel> lista = new List<Xna3DViewer.VirtualModel>();
					int cluster = CheckCluster(md.getMarkers().First().getImage());
					string modelName;
					if (cluster < 4)
					{
						modelName = "ship" + (cluster + 1);
					}
					else
					{
						modelName = "ship5";
					}
                    lista.Add(new Xna3DViewer.VirtualModel(modelName, pos.getTransformatinMatrix(), 80.0f));
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
             */ 
        }

		private int CheckCluster(Image<Gray, byte> image)
		{
			//iPictogram.Source = Camera.ToBitmapSource(image);
			imageFacade.Image = image.Bitmap;
			imageFacade.Lock();
			int cluster = recognitionPath.Recognize(imageFacade);
			imageFacade.Unlock();
			Console.WriteLine(cluster);
			return cluster;
		}
     
        private void button1_Click(object sender, RoutedEventArgs e)
        {

           Camera camera = new Camera();
           camera.TimeElapsed += new EventHandler<CameraEventArgs>(displayImage);
        }
        private void buttonXNA_Click(object sender, RoutedEventArgs e)
        {
           
            
            Camera camera = new Camera();
            camera.TimeElapsed += new EventHandler<CameraEventArgs>(displayImage);
        
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

        private void xnaLoad(object sender, GraphicsDeviceEventArgs e)
        {
            dispModel = new DisplayModel(xnaHost, e.GraphicsDevice);
        }

        private void renderXna(object sender, GraphicsDeviceEventArgs e)
        {
            dispModel.setTexture2D(img.ToBitmap());
            md.findMarkers(img.Convert<Gray, Byte>());
            if (md.isMarker()) 
            {
                pos.estimate(md.markers[0]);
                List<E3DModel> list = new List<E3DModel>();
                list.Add(new E3DModel("ship1",pos.getTransformatinMatrix(),80.0f));
                dispModel.setModels(list);
            }
        }


    }
}
