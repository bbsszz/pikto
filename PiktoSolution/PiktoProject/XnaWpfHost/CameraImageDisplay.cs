using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Pikto
{
    class CameraImageDisplay: DisplayDecorator
    {
        Texture2D texture = null;
        System.Drawing.Bitmap cameraImage=null;
        public CameraImageDisplay(DisplayComponent d) : base(d) { }
        public void setCameraImage(System.Drawing.Bitmap cameraImg)
        {
            cameraImage = cameraImg;
        }
        public override void displaySetContent()
        {
            base.displaySetContent();
            if (texture != null)
            {
                texture.Dispose();
                texture = null;
            }

            if (cameraImage != null)
            {
                texture = Tools.XNATextureFromBitmap(
                   cameraImage,graficDevice);

                // draw texture containing video frame
                mainSpriteBatch.Begin(0, BlendState.Opaque);
                mainSpriteBatch.Draw(texture,
                    new Rectangle(0,0,(int)graficDeviceControl.ActualWidth
                                                ,(int)graficDeviceControl.ActualHeight),Color.White);
                mainSpriteBatch.End();

                // restore state of some graphics device's properties after 2D graphics,
                // so 3D rendering will work fine
                graficDevice.BlendState = BlendState.AlphaBlend;
                graficDevice.DepthStencilState = DepthStencilState.Default;

                graficDevice.SamplerStates[0] = new SamplerState
                {
                    AddressU = TextureAddressMode.Wrap,
                    AddressV = TextureAddressMode.Wrap
                };
            }
           
        }

    }
}
