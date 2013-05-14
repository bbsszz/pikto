using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework.Graphics;
namespace Pikto
{
    abstract class DisplayDecorator:DisplayComponent
    {
        protected DisplayComponent disp;

        public DisplayDecorator(DisplayComponent d)
        {
            disp = d;
            graficDevice=d.graficDevice;
            graficDeviceControl = d.graficDeviceControl;
            mainSpriteBatch=d.mainSpriteBatch;
            watch=d.watch;
        }
        public override void displaySetContent()
        {
            if (disp != null)
                disp.displaySetContent();
        }
    }
}
