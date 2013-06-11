using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Pikto.Command;
using Emgu.CV.Structure;
using Emgu.CV;

namespace Pikto.ViewModel.SimpleViewModel
{
	class LearningPathViewModel : BaseViewModel
	{
        public DisplayComponent DisplayContent { get; set; }
        public PiktoViewManager PiktoViewMan { get; set; }

        MDetector md;
        Image<Bgr, Byte> img;
        ToolArtNetwork toolNetwork;
        MarkerPosition3D pos;

        private void LoadXna(object sender, GraphicsDeviceEventArgs e)
        {
            DisplayContent = PiktoViewMan.createScene((GraphicsDeviceControl)sender, e.GraphicsDevice);
        }

        private void RenderXna(object sender, GraphicsDeviceEventArgs e)
        {
            md.findMarkers(img.Convert<Gray, Byte>());
            if (md.isMarker())
            {
                int id = toolNetwork.recognitionPictograms(md.markers[0].getSymbolImage());
                if (id != -1)
                {
                    pos.estimate(md.markers[0]);
                    PiktoViewMan.viewSceneMarker(id, pos.getTransformatinMatrix(), img.ToBitmap());

                }
            }
            else
            {
                PiktoViewMan.updateDisplayCameraLayer(img.ToBitmap());
            }
            DisplayContent.displaySetContent();

        }
	}
}
