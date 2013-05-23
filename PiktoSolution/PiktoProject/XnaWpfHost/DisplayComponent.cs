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
    abstract class DisplayComponent
    {
        public GraphicsDeviceControl graficDeviceControl;
        public GraphicsDevice graficDevice;
        public SpriteBatch mainSpriteBatch;
        public Stopwatch watch = new Stopwatch();

        public abstract void displaySetContent();
    }
}
