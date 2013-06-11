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
    //defauld mode: Center
    //start Screen: (x:centerScreenX,y:centerScreenY,w:0,h:0)

    class DisplayMove : DisplayDecorator
    {
        public enum Mode { Center, LeftTop, RightButton }
        private ContentManager content = null;
        Video video;
        VideoPlayer player;
        Texture2D videoTexture;
        bool loadOk;
        Rectangle screen;
        Mode currentMode;
        int maxWidth;
        int maxHeight;
        int step;
        bool moveStop;
        int centerX;
        int centerY;
        public DisplayMove(DisplayComponent d)
            : base(d)
        {
            player = new VideoPlayer();
            loadOk = false;
            step = 2;
            currentMode = Mode.Center;
            centerX = (graficDevice.Viewport.Width - graficDevice.Viewport.X) / 2;
            centerY = (graficDevice.Viewport.Height - graficDevice.Viewport.Y) / 2;
            screen = new Rectangle(centerX, centerY, 0, 0);
            maxHeight = 500;
            maxWidth = 400;
            moveStop = true;
        }
        public void setMode(Mode m)
        {
            currentMode = m;
            if (currentMode == Mode.RightButton)
            {
                screen.X = graficDevice.Viewport.Width;
                screen.Y = graficDevice.Viewport.Height;
            }
        }
        public void setStep(int s)
        {
            step = s;
        }
        public bool getMoveStop()
        {
            return moveStop;
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
        public void setMaxScreen(int w, int h)
        {
            maxWidth = w;
            maxHeight = h;
        }
        public void playMove()
        {
            if (player.State == MediaState.Stopped && loadOk)
            {
                // player.IsLooped = true;
                player.Play(video);
                moveStop = false;
            }
        }
        public override void displaySetContent()
        {
            base.displaySetContent();
            if (displayEnable)
            {
                if (player.State != MediaState.Stopped)
                {
                    if (screen.Width < maxWidth && screen.Height < maxHeight)
                    {
                        switch (currentMode)
                        {
                            case Mode.Center:
                                screen.X -= step;
                                screen.Y -= step;
                                screen.Width += 2 * step;
                                screen.Height += 2 * step;
                                break;
                            case Mode.LeftTop:
                                screen.X = 0;
                                screen.Y = 0;
                                screen.Width += step;
                                screen.Height += step;
                                break;
                            case Mode.RightButton:
                                screen.X -= step;
                                screen.Y -= step;
                                screen.Width = graficDevice.Viewport.Width - screen.X;
                                screen.Height = graficDevice.Viewport.Height - screen.Y;
                                break;
                        }
                    }
                    else
                    {
                  //      screen = new Rectangle(centerX, centerY, 0, 0);
                           
                    }
                    videoTexture = player.GetTexture();
                    if (videoTexture != null)
                    {
                        mainSpriteBatch.Begin();
                        mainSpriteBatch.Draw(videoTexture, screen, Color.White);
                        mainSpriteBatch.End();
                    }
                }
                else
                {
                    moveStop = true;
                }
            }
        }
    }
}
