using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Emgu.CV.Structure;
using Emgu.CV;

namespace Pikto.Command
{
	class RenderXnaCommand : ICommand
	{
		private DisplayComponent displayComponent;
		private PiktoViewManager piktoViewMan;
		private ToolArtNetwork toolNetwork;
		private MDetector md;
		private Image<Bgr, Byte> img;
		private MarkerPosition3D pos;

		public RenderXnaCommand(
			DisplayComponent displayComponent,
			PiktoViewManager pictoViewManager,
			ToolArtNetwork toolArtNetwork,
			MDetector md,
			Image<Bgr, Byte> img,
			MarkerPosition3D pos)
		{
			this.displayComponent = displayComponent;
			this.piktoViewMan = pictoViewManager;
			this.toolNetwork = toolArtNetwork;
			this.md = md;
			this.img = img;
			this.pos = pos;
		}

		public bool CanExecute(object parameter)
		{
			throw new NotImplementedException();
		}

		public event EventHandler CanExecuteChanged;

		public void Execute(object parameter)
		{
			md.findMarkers(img.Convert<Gray, Byte>());
			if (md.isMarker())
			{
				int id = toolNetwork.recognitionPictograms(md.markers[0].getSymbolImage());
				if (id != -1)
				{
					pos.estimate(md.markers[0]);
					piktoViewMan.viewSceneMarker(id, pos.getTransformatinMatrix(), img.ToBitmap());
				}
			}
			else
			{
				piktoViewMan.updateDisplayCameraLayer(img.ToBitmap());
			}
			displayComponent.displaySetContent();
		}
	}
}
