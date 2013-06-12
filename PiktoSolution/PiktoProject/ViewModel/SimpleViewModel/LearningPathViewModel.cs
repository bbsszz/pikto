using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Pikto.Command;
using Emgu.CV.Structure;
using Emgu.CV;
using Pikto.Database;

namespace Pikto.ViewModel.SimpleViewModel
{
	class LearningPathViewModel : BaseViewModel
	{
		public ICommand RenderXnaCmd { get; private set; }
		public GraphicsDeviceControl control { set; private get; }

		private DisplayComponent displayComponent;
		private PiktoViewManager pictoViewManager;

		public LearningPathViewModel(/*ICommand renderXnaCmd, */DatabaseService db)
		{
			MDetector md = new MDetector();
			Image<Bgr, Byte> img = new Image<Bgr, Byte>(640, 480, new Bgr(255, 255, 0));
			PiktoViewDB piktodb = new PiktoViewDB(db);
			pictoViewManager = new PiktoViewManager(piktodb);
            ToolArtNetwork toolNetwork = new ToolArtNetwork(piktodb.getImageIdDic());
			MarkerPosition3D pos = new MarkerPosition3D(80.0f, 640.0f, 640, 480);

			RenderXnaCmd = new BasicCommand(p =>
			{
				md.findMarkers(img.Convert<Gray, Byte>());
				if (md.isMarker())
				{
					int id = toolNetwork.recognitionPictograms(md.markers[0].getSymbolImage());
					if (id != -1)
					{
						pos.estimate(md.markers[0]);
						pictoViewManager.viewSceneMarker(id, pos.getTransformatinMatrix(), img.ToBitmap());
					}
				}
				else
				{
					pictoViewManager.updateDisplayCameraLayer(img.ToBitmap());
				}
				displayComponent.displaySetContent();
			});


		}

		public EventHandler<GraphicsDeviceEventArgs> RenderXnaEvent;

		public void _RenderXnaEvent(object sender, GraphicsDeviceEventArgs e)
		{
			RenderXnaCmd.Execute(null);
		}

		public override void Loaded()
		{
			//displayComponent = pictoViewManager.createScene(control);
		}


	}
}
