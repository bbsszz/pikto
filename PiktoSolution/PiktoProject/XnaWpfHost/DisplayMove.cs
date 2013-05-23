using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using AForge.Math;

namespace Pikto
{
    class DisplayMove:DisplayDecorator
    {
        private ContentManager content = null;
        Video video;
        VideoPlayer player;
        Texture2D videoTexture;
        bool loadOk;
        Rectangle screen;
        public DisplayMove(DisplayComponent d) : base(d) 
        {
            player = new VideoPlayer();
            loadOk = false;
            screen = new Rectangle(graficDevice.Viewport.X,
                  graficDevice.Viewport.Y,
                  graficDevice.Viewport.Width,
                  graficDevice.Viewport.Height);
        }
        public void setMove(string name)
        {
            if (content == null)
            {
                content = new ContentManager(graficDeviceControl.Services, "Content");
            }
            try
            {
                video = content.Load<Video>(name);
                loadOk = true;
            }
            catch (ArgumentNullException e)
            { 
            
            }
            player = new VideoPlayer();
        }
        public void setRectangleScreen(int w,int h)
        {
            screen.Width = w;
            screen.Height = h;
        }
        public void setRectangleScreen(int x,int y,int w, int h)
        {
            screen.X = x;
            screen.Y = y;
            screen.Width = w;
            screen.Height = h;
        }
        public void playMove()
        {
            if (player.State == MediaState.Stopped && loadOk)
            {
                player.IsLooped = true;
                player.Play(video);
            }
        }
        public override void displaySetContent()
        {
            base.displaySetContent();
            if (player.State != MediaState.Stopped)
            {
                videoTexture = player.GetTexture();
                if (videoTexture != null)
                {
                    mainSpriteBatch.Begin();
                    mainSpriteBatch.Draw(videoTexture, screen, Color.White);
                    mainSpriteBatch.End();
                }
            }
        }
    }
}
