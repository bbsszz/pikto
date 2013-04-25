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
using AForge.Math;
namespace Pikto
{
    class DisplayModel
    {
        private ContentManager content = null;
        Model model = null;
        ModelMesh mesh = null;

        private Texture2D texture = null;
        private SpriteBatch mainSpriteBatch;
        private Xna3DViewer.ModelsCollection modelsCollection =
                                      Xna3DViewer.ModelsCollection.Instance;
        GraphicsDeviceControl graficDeviceControl;
        GraphicsDevice graficDevice;
        private Stopwatch watch = new Stopwatch();
        public DisplayModel(GraphicsDeviceControl devControl,GraphicsDevice dev) {
           graficDeviceControl=devControl;
           graficDevice = dev;
           mainSpriteBatch = new SpriteBatch(dev);
              if (!watch.IsRunning)
                      watch.Start();
            
        }
        public void setTexture2D(System.Drawing.Bitmap bitmap) {
            if (texture != null)
            {
                texture.Dispose();
                texture = null;
            }

            if (bitmap != null)
            {
                texture = Tools.XNATextureFromBitmap(bitmap, graficDevice);

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
        public void setModels(List<E3DModel> models) {
          if ( models.Count != 0 )
           {
                    // create camera view matrix
                    Matrix viewMatrix = Matrix.CreateLookAt(
                        new Microsoft.Xna.Framework.Vector3( 0, 0, 3 ),
                            Microsoft.Xna.Framework.Vector3.Zero,
                            Microsoft.Xna.Framework.Vector3.Up );
                    // create projection matrix
                    Matrix projectionMatrix = Matrix.CreatePerspective(
                        1, 1 /graficDevice.Viewport.AspectRatio, 1f, 10000 );

                    // display all models
                    foreach (E3DModel virtualModel in models)
                    {
                    if (virtualModel.Size <= 0)
                        continue;
                    if (content == null)
                     {
                        content = new ContentManager(graficDeviceControl.Services, "Content");
                     }

                    
                        Model model = content.Load<Model>(virtualModel.Name);
                        Matrix4x4 modelTransformaton = virtualModel.Transformation;
                        float yaw, pitch, roll;
                        modelTransformaton.ExtractYawPitchRoll( out yaw, out pitch, out roll );
                        Matrix rotation = Matrix.CreateFromYawPitchRoll( -yaw, -pitch, roll );
                        Matrix translation = Matrix.CreateTranslation(
                                modelTransformaton.V03, modelTransformaton.V13, -modelTransformaton.V23 );

                        Matrix[] transforms = new Matrix[model.Bones.Count];
                        model.CopyAbsoluteBoneTransformsTo( transforms );

                        // create scaling matrix, so model fits its glyph
                        Matrix scaling = Matrix.CreateScale( virtualModel.Size );

                            // display all meshes of the model
                            // (note: the code will fine only for model with single mesh so far)
                            // (to make it work with complex models, it is required to get routine
                            // (for calculation of model's radius, not just mesh radius)
                            foreach ( ModelMesh mesh in model.Meshes )
                            {
                                Matrix world = 
                                    transforms[mesh.ParentBone.Index] *
                                    Matrix.CreateScale( 1 / mesh.BoundingSphere.Radius ) *
                                    scaling * rotation * translation;

                                // set matrices for all effects
                                foreach ( Effect effect in mesh.Effects )
                                {
                                    if ( effect is BasicEffect )
                                    {
                                        BasicEffect basicEffect = (BasicEffect) effect;

                                        basicEffect.EnableDefaultLighting( );

                                        basicEffect.World = world;
                                        basicEffect.View = viewMatrix;
                                        basicEffect.Projection = projectionMatrix;
                                    }
                                    else
                                    {
                                        EffectParameter param = effect.Parameters["World"];
                                        if ( param != null )
                                        {
                                            param.SetValue( world );
                                        }

                                        param = effect.Parameters["View"];
                                        if ( param != null )
                                        {
                                            param.SetValue( viewMatrix );
                                        }

                                        param = effect.Parameters["Projection"];
                                        if ( param != null )
                                        {
                                            param.SetValue( projectionMatrix );
                                        }
                                    }
                                }

                                mesh.Draw( );
                            }
                        
                       
                    }
                }
            }      
        }
    
}
