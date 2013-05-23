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
    class DisplayXNA:DisplayComponent
    {
        public override void displaySetContent()
        {
           
        }
        
        public void setGraphicDevice(GraphicsDeviceControl devControl,
                                                 GraphicsDevice dev) {
           graficDeviceControl=devControl;
           graficDevice = dev;
           mainSpriteBatch = new SpriteBatch(dev);
           if (!watch.IsRunning)
               watch.Start();
        }
    }
}
