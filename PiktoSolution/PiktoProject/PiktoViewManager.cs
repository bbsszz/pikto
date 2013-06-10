using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
namespace Pikto
{
    class PiktoViewManager
    {
        int currentCatagoryId;
        Dictionary<int, string> pictoObjectType;
        Dictionary<int, string> pictoObjectName;
        Database.DatabaseService db;
        DisplayXNA baseSceneLayer;
        CameraImageDisplay cameraSceneLayer;
        DisplayMove moveLayerScene;
        Model3dDisplay model3dSceneLayer;
        bool videoMode;
        public PiktoViewManager(int catagoryId, Database.DatabaseService dbService)
        {
            currentCatagoryId = catagoryId;
            db = dbService;
            pictoObjectType = new Dictionary<int, string>();
            pictoObjectName = new Dictionary<int, string>();
            createListAvailableId();
            int i = 0;
            videoMode = false;

        }
        private void createListAvailableId()
        {
            pictoObjectType.Add(1, "video");
            pictoObjectName.Add(1, "Bear");

            pictoObjectType.Add(2, "3dobject");
            pictoObjectName.Add(2, "ship1");

            pictoObjectType.Add(3, "3dobject");
            pictoObjectName.Add(3, "ship1");

            pictoObjectType.Add(4, "3dobject");
            pictoObjectName.Add(4, "ship2");

            pictoObjectType.Add(5, "3dobject");
            pictoObjectName.Add(5, "ship3");
        }
        public DisplayComponent createScene(GraphicsDeviceControl devControl,
                                                 GraphicsDevice dev)
        {
            baseSceneLayer = new DisplayXNA();
            baseSceneLayer.setGraphicDevice(devControl, dev);

            cameraSceneLayer = new CameraImageDisplay(baseSceneLayer);
            cameraSceneLayer.setDisplayEnable(true);
            model3dSceneLayer = new Model3dDisplay(cameraSceneLayer);

            moveLayerScene = new DisplayMove(model3dSceneLayer);
            return moveLayerScene;
        }
        public void viewOnlyCameraImage()
        {
            model3dSceneLayer.setDisplayEnable(false);
            moveLayerScene.setDisplayEnable(false);

            cameraSceneLayer.setDisplayEnable(true);
        }
        public void viewMoveLayerAndCameraLayer()
        {
            model3dSceneLayer.setDisplayEnable(false);
            moveLayerScene.setDisplayEnable(true);
            cameraSceneLayer.setDisplayEnable(true);
        }
        public void view3DModelLayerAndCameraLayer()
        {
            model3dSceneLayer.setDisplayEnable(true);
            moveLayerScene.setDisplayEnable(false);
            cameraSceneLayer.setDisplayEnable(true);
        }
        public void updateDisplayCameraLayer(System.Drawing.Bitmap cameraImg)
        {
            cameraSceneLayer.setCameraImage(cameraImg);
        }
        public void viewSceneMarker(int id,AForge.Math.Matrix4x4 mtxProj, System.Drawing.Bitmap cameraImg)
        {
            if (videoMode)
            {

                //  viewMoveLayerAndCameraLayer();
                updateDisplayCameraLayer(cameraImg);
                if (moveLayerScene.getMoveStop())
                {
                    videoMode = false;
                }

            }
            else
            {
                if (pictoObjectType.ContainsKey(id))
                {
                    if (pictoObjectType[id] == "video")
                    {
                        viewMoveLayerAndCameraLayer();
                        moveLayerScene.setMove(pictoObjectName[id]);
                        moveLayerScene.playMove();
                        videoMode = true;
                    }
                    if (pictoObjectType[id] == "3dobject")
                    {
                        List<E3DModel> list = new List<E3DModel>();
                        list.Add(new E3DModel(pictoObjectName[id],mtxProj, 80.0f));
                        view3DModelLayerAndCameraLayer();
                        model3dSceneLayer.setModels(list);

                    }

                }
                else
                {
                    viewOnlyCameraImage();
                    updateDisplayCameraLayer(cameraImg);
                }
            }
        }
    }
}
