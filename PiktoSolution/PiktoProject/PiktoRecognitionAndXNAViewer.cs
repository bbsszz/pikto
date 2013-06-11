using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Pikto
{
    class PiktoRecognitionAndXNAViewer
    {
        DisplayComponent displayComponent;
        PiktoViewManager piktoViewManager;
        PiktoViewDB piktoViewDB;
        MDetector md;
        MarkerPosition3D pos;
        ToolArtNetwork toolNetwork;
        
        public void initialize(Database.DatabaseService db)
        {
            piktoViewDB = new PiktoViewDB(db);
            piktoViewManager = new PiktoViewManager(piktoViewDB);
            md = new MDetector();
            pos = new MarkerPosition3D(80.0f, 640.0f, 640, 480);
            toolNetwork = new ToolArtNetwork(piktoViewDB.getImageIdDic());
           
        }
        public void createScene(GraphicsDeviceControl devControl, GraphicsDevice dev)
        {
           displayComponent= piktoViewManager.createScene(devControl,dev);
        }
        public void render( Image<Bgr, Byte> img)
        {
            md.findMarkers(img.Convert<Gray, Byte>());
            if (md.isMarker())
            {
                int id = toolNetwork.recognitionPictograms(md.markers[0].getSymbolImage());
                if (id != -1)
                {
                    pos.estimate(md.markers[0]);
                    piktoViewManager.viewSceneMarker(id, pos.getTransformatinMatrix(), img.ToBitmap());

                }
                //   piktoViewMan.updateDisplayCameraLayer(img.ToBitmap());
            }
            else
            {
                if (!piktoViewManager.videoMode)
                    piktoViewManager.viewOnlyCameraImage();
                piktoViewManager.updateDisplayCameraLayer(img.ToBitmap());
      
            }
            displayComponent.displaySetContent();
        }
    }
}
