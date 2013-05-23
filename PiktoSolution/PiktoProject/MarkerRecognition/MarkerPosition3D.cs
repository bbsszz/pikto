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
    class MarkerPosition3D
    {
        int imageWidth;
        int imageHeight;
        CoplanarPosit positAlgorithm;
        AForge.Point[] imagePoints;
        Matrix3x3 rotationMatrix;
        Matrix4x4 transfMtx;
        Vector3 translationVector;
        Vector3 oldTranslationVector = new Vector3(0);
        bool firstGet=true;
        float testNorm;
        public float estimatedYaw;
        public float estimatedPitch;
        public float estimatedRoll;

        public MarkerPosition3D(float realSizeMarker, float focalLength
            , int imgW, int imgH)
        {
        imageWidth = imgW;
        imageHeight = imgH;
        positAlgorithm = new CoplanarPosit(
            new Vector3[]
           { new Vector3( -realSizeMarker/2, 0, realSizeMarker/2 ),
             new Vector3(  realSizeMarker/2, 0, realSizeMarker/2 ),
             new Vector3(  realSizeMarker/2, 0, -realSizeMarker/2 ),
             new Vector3( -realSizeMarker/2, 0, -realSizeMarker/2 ),
           }
           , focalLength);
      }

        public void estimate(EMarker m) { 
             imagePoints = new AForge.Point[]
            {
                 new AForge.Point( m.getContour()[3].X
                                  , m.getContour()[3].Y ),
                 new AForge.Point( m.getContour()[2].X
                                  , m.getContour()[2].Y ),
                 new AForge.Point( m.getContour()[1].X
                                  ,m.getContour()[1].Y ),
                 new AForge.Point( m.getContour()[0].X
                                 , m.getContour()[0].Y )};
            //change cordinate system
          for (int i = 0; i < 4; i++) {
              if (imagePoints[i].X < imageWidth / 2) imagePoints[i].X = -(imageWidth / 2) + imagePoints[i].X;
              else imagePoints[i].X = imagePoints[i].X - (imageWidth / 2);

              if (imagePoints[i].Y < imageHeight / 2) imagePoints[i].Y = (imageHeight / 2) - imagePoints[i].Y;
              else imagePoints[i].Y = -imagePoints[i].Y + (imageHeight / 2);
          }
          positAlgorithm.EstimatePose(imagePoints,
                         out rotationMatrix,out translationVector);
          
            rotationMatrix.ExtractYawPitchRoll(out estimatedYaw,
                                  out estimatedPitch,
                                  out estimatedRoll);
          
          rotationMatrix = Matrix3x3.CreateFromYawPitchRoll(estimatedYaw,
            estimatedPitch, estimatedRoll);

        }
        public Matrix4x4 getTransformatinMatrix()
        {
            //if (firstGet || testChangeTranslateVector(translationVector, oldTranslationVector))
            //{
                firstGet = false;
                transfMtx = Matrix4x4.CreateTranslation(translationVector) *
                        Matrix4x4.CreateFromRotation(rotationMatrix);
                 return transfMtx;
          //  }
          //  else
            //    return transfMtx;
        }
        public bool testChangeTranslateVector(Vector3 vec, Vector3 oldVec)
        {
            if ((vec - oldVec).Norm > testNorm) return true;
            else return false;
        }
    }
}
