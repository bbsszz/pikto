using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
namespace Pikto
{
    class PiktoViewManager
    {
        PiktoViewDB piktoViewDB;
        DisplayXNA baseSceneLayer;
        CameraImageDisplay cameraSceneLayer;
        DisplayMove moveLayerScene;
        Model3dDisplay model3dSceneLayer;
        public bool videoMode;
        public PiktoViewManager(PiktoViewDB piktoDB)
        {
            piktoViewDB = piktoDB;
            videoMode = false;

        }

        public DisplayComponent createScene(GraphicsDeviceControl devControl, GraphicsDevice dev)
        {
            baseSceneLayer = new DisplayXNA();
            baseSceneLayer.setGraphicDevice(devControl, devControl.GraphicsDeviceService.GraphicsDevice);

            cameraSceneLayer = new CameraImageDisplay(baseSceneLayer);
            cameraSceneLayer.setDisplayEnable(true);
            model3dSceneLayer = new Model3dDisplay(cameraSceneLayer);

            moveLayerScene = new DisplayMove(model3dSceneLayer);
            return moveLayerScene;
        }

        public DisplayComponent createScene(GraphicsDeviceControl devControl)
        {
            return createScene(devControl, devControl.GraphicsDeviceService.GraphicsDevice);
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
        public void viewSceneMarker(int id, AForge.Math.Matrix4x4 mtxProj, System.Drawing.Bitmap cameraImg)
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
                string mediumType = piktoViewDB.getMediaType(id);
                string mediumName = piktoViewDB.getMediaName(id);
                if (mediumName != "null")
                {
                    if (mediumType == "video")
                    {
                        viewMoveLayerAndCameraLayer();
                        moveLayerScene.setMove(mediumName);
                        moveLayerScene.playMove();
                        videoMode = true;
                    }
                    if (mediumType == "3dobject")
                    {
                        List<E3DModel> list = new List<E3DModel>();
                        list.Add(new E3DModel(mediumName, mtxProj, 80.0f));
                        view3DModelLayerAndCameraLayer();
                        model3dSceneLayer.setModels(list);
                        updateDisplayCameraLayer(cameraImg);
                    }

                }
                else
                {
                   
                    updateDisplayCameraLayer(cameraImg);
                }
            }

        }
    }
}
