using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Math;
using AForge.Math.Geometry;
using AForge;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.Util;
using System.Drawing;
namespace Pikto
{
    class Position3D
    {
        int imgW;
        int imgH;
        public float estimatedYaw; 
        public float estimatedPitch;
        public float estimatedRoll;
        public Vector3[] modelPoints ;
        public AForge.Point[] imagePoints;
        CoplanarPosit positAlgorithm; 
        Matrix3x3 rotationMatrix;
        Vector3 translationVector;
        float focusLenght;
        private Vector3[] axesModel = new Vector3[]
       {
             new Vector3( 0, 0, 0 ),
             new Vector3( 1, 0, 0 ),
             new Vector3( 0, 1, 0 ),
             new Vector3( 0, 0, 1 ),
       };

        public Position3D(float realSizeMarker, float f,int w,int h)
        {
        focusLenght = f;
        setModelPoints(realSizeMarker); 
        positAlgorithm =new CoplanarPosit(modelPoints,f);
        imgW = w;
        imgH = h;
        }
        public Position3D()
        {
            setModelPoints(80.0f);
            positAlgorithm = new CoplanarPosit(modelPoints, 640.0f);
            imgW = 640;
            imgH = 480;
        }
        public Vector3[] getModelPoints(){return modelPoints;}
        private void setModelPoints(float size) {
            //define left-handed coordinate system 
             modelPoints = new Vector3[]
                {           new Vector3( -size/2, 0, size/2 ),
                            new Vector3(  size/2, 0, size/2 ),
                            new Vector3(  size/2, 0, -size/2 ),
                            new Vector3( -size/2, 0, -size/2 ),
                };
        }
        public float getFocus() { return focusLenght;}
        public void setFocus(float f) { 
            focusLenght = f;
            positAlgorithm.FocalLength = f; 
        }
        public void estimate(Marker m) {
          imagePoints = new AForge.Point[]
            {
                 new AForge.Point( m.getContourExternal()[3].X
                                  , m.getContourExternal()[3].Y ),
                 new AForge.Point( m.getContourExternal()[2].X
                                  , m.getContourExternal()[2].Y ),
                 new AForge.Point( m.getContourExternal()[1].X
                                  , m.getContourExternal()[1].Y ),
                 new AForge.Point( m.getContourExternal()[0].X
                                  , m.getContourExternal()[0].Y )
         };
            //change cordinate system
          for (int i = 0; i < 4; i++) {
              if (imagePoints[i].X < imgW/2) imagePoints[i].X = -(imgW/2) + imagePoints[i].X;
              else imagePoints[i].X=imagePoints[i].X-(imgW/2);
          
              if (imagePoints[i].Y< imgH/2) imagePoints[i].Y = (imgH/2)-imagePoints[i].Y;
              else imagePoints[i].Y=-imagePoints[i].Y + (imgH/2);
          }
        positAlgorithm.EstimatePose(imagePoints,
                         out rotationMatrix,out translationVector);
    
        rotationMatrix.ExtractYawPitchRoll(out estimatedYaw,
                                    out estimatedPitch,
                                    out estimatedRoll);
        estimatedYaw *= (float)(180.0 / Math.PI);
        estimatedPitch *= (float)(180.0 / Math.PI);
        estimatedRoll *= (float)(180.0 / Math.PI);
        }
        private AForge.Point[] PerformProjection( Vector3[] model,
                        Matrix4x4 transformationMatrix, int viewSize )
        {
            AForge.Point[] projectedPoints = new AForge.Point[model.Length];
            for (int i = 0; i < model.Length; i++)
            {
                Vector3 scenePoint = (transformationMatrix *
                model[i].ToVector4()).ToVector3();
                projectedPoints[i] = new AForge.Point(
                   (int)(scenePoint.X / scenePoint.Z * viewSize),
                   (int)(scenePoint.Y / scenePoint.Z * viewSize));
            }
    return projectedPoints;
    }
   public List<System.Drawing.Point> getPointList(int cx,int cy) { 
            List<System.Drawing.Point> pktList=new List<System.Drawing.Point>();
            AForge.Point[] projectedAxes = PerformProjection(axesModel,
             Matrix4x4.CreateTranslation(translationVector) *        // 3: translate
             Matrix4x4.CreateFromRotation(rotationMatrix) *          // 2: rotate
             Matrix4x4.CreateDiagonal(new Vector4(40,40,40, 1)), // 1: scale
             cx*2);
            pktList.Add(new System.Drawing.Point(
               (int)(cx + projectedAxes[0].X), (int)(cy - projectedAxes[0].Y)));
            pktList.Add(new System.Drawing.Point(
               (int)(cx + projectedAxes[1].X), (int)(cy - projectedAxes[1].Y)));
            pktList.Add(new System.Drawing.Point(
               (int)(cx + projectedAxes[0].X), (int)(cy - projectedAxes[0].Y)));
            pktList.Add(new System.Drawing.Point(
               (int)(cx + projectedAxes[2].X), (int)(cy - projectedAxes[2].Y)));
            pktList.Add(new System.Drawing.Point(
               (int)(cx + projectedAxes[0].X), (int)(cy - projectedAxes[0].Y)));
            pktList.Add(new System.Drawing.Point(
               (int)(cx + projectedAxes[3].X), (int)(cy - projectedAxes[3].Y)));
            return pktList;
        }
        public Matrix4x4 getTransformatinMatrix() { 
        
        return    Matrix4x4.CreateTranslation( translationVector ) *
                Matrix4x4.CreateFromRotation( rotationMatrix  );
        }
 }
    
}
