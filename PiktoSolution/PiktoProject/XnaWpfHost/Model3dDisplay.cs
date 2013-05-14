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
    class Model3dDisplay:DisplayDecorator
    {
        Model model = null;
        ModelMesh mesh = null;
        private ContentManager content = null;

        List<E3DModel> models = new List<E3DModel>();
        public Model3dDisplay(DisplayComponent d) : base(d) { }
        public void setModels(List<E3DModel> models)
        {
            this.models = models;
        }
        public override void displaySetContent()
        {
            base.displaySetContent();
            if (models.Count != 0)
            {
                // create camera view matrix
                Matrix viewMatrix = Matrix.CreateLookAt(
                    new Microsoft.Xna.Framework.Vector3(0, 0, 3),
                        Microsoft.Xna.Framework.Vector3.Zero,
                        Microsoft.Xna.Framework.Vector3.Up);
                // create projection matrix
                Matrix projectionMatrix = Matrix.CreatePerspective(
                    1, 1 / graficDevice.Viewport.AspectRatio, 1f, 10000);

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
                    modelTransformaton.ExtractYawPitchRoll(out yaw, out pitch, out roll);
                    Matrix rotation = Matrix.CreateFromYawPitchRoll(-yaw, -pitch, roll);
                    Matrix translation = Matrix.CreateTranslation(
                            modelTransformaton.V03, modelTransformaton.V13, -modelTransformaton.V23);

                    Matrix[] transforms = new Matrix[model.Bones.Count];
                    model.CopyAbsoluteBoneTransformsTo(transforms);

                    // create scaling matrix, so model fits its glyph
                    Matrix scaling = Matrix.CreateScale(virtualModel.Size);

                    // display all meshes of the model
                    // (note: the code will fine only for model with single mesh so far)
                    // (to make it work with complex models, it is required to get routine
                    // (for calculation of model's radius, not just mesh radius)
                    foreach (ModelMesh mesh in model.Meshes)
                    {
                        Matrix world =
                            transforms[mesh.ParentBone.Index] *
                            Matrix.CreateScale(1 / mesh.BoundingSphere.Radius) *
                            scaling * rotation * translation;

                        // set matrices for all effects
                        foreach (Effect effect in mesh.Effects)
                        {
                            if (effect is BasicEffect)
                            {
                                BasicEffect basicEffect = (BasicEffect)effect;

                                basicEffect.EnableDefaultLighting();

                                basicEffect.World = world;
                                basicEffect.View = viewMatrix;
                                basicEffect.Projection = projectionMatrix;
                            }
                            else
                            {
                                EffectParameter param = effect.Parameters["World"];
                                if (param != null)
                                {
                                    param.SetValue(world);
                                }

                                param = effect.Parameters["View"];
                                if (param != null)
                                {
                                    param.SetValue(viewMatrix);
                                }

                                param = effect.Parameters["Projection"];
                                if (param != null)
                                {
                                    param.SetValue(projectionMatrix);
                                }
                            }
                        }

                        mesh.Draw();
                    }


                }
            }
        }
    }
}
