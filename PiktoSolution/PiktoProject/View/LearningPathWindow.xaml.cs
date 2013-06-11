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
		private RecognitionPath.RecognitionPath recognitionPath;
        Database.DatabaseService db;
        MDetector md;
        MarkerPosition3D pos;
        ToolArtNetwork toolNetwork;
        DisplayComponent displayContent;
        PiktoViewManager piktoViewMan;
        Image<Bgr, Byte> img;

        public LearningPathWindow()
        {
            InitializeComponent();
            md = new MDetector();
            pos = new MarkerPosition3D(80.0f, 640.0f, 640, 480);
            img = new Image<Bgr, byte>(640, 480, new Bgr(255, 255, 0));

            db = new Database.DatabaseService();
      
            PiktoViewDB piktodb = new PiktoViewDB(db);
            toolNetwork = new ToolArtNetwork(piktodb.getImageIdDic());
            piktoViewMan = new PiktoViewManager(piktodb);
			Camera camera = new Camera();
			camera.TimeElapsed += new EventHandler<CameraEventArgs>(displayImage);
        }

		private void displayImage(object s, CameraEventArgs e)
		{
			img = e.Image;
		}

		private void xnaLoad(object sender, GraphicsDeviceEventArgs e)
		{
			displayContent = piktoViewMan.createScene(xnaHost, e.GraphicsDevice);
		}

		private void renderXna(object sender, GraphicsDeviceEventArgs e)
		{
			//md.findMarkers(img.Convert<Gray, Byte>());
			//if (md.isMarker())
			//{
			//    int id = toolNetwork.recognitionPictograms(md.markers[0].getSymbolImage());
			//    if (id != -1)
			//    {
			//        pos.estimate(md.markers[0]);
			//        piktoViewMan.viewSceneMarker(id, pos.getTransformatinMatrix(), img.ToBitmap());
			//    }
			//}
			//else
			//{
				piktoViewMan.updateDisplayCameraLayer(img.ToBitmap());
			//}
			displayContent.displaySetContent();

		}
	}
}
