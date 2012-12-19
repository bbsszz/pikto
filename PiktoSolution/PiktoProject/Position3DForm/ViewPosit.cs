using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using AForge.Math;
using AForge.Math.Geometry;
using Emgu.CV;
using Emgu.CV.Structure;
namespace Pikto.Position3DForm
{
    class ViewPosit
    {
      
        List<Point> pktList;
        List<Bgr> colorList;
        public int sizeRect;
        public int wImg;
        public int hImg;
        private Point center;
        public Matrix4x4 worldMatrix = new Matrix4x4();
        public Matrix4x4 viewMatrix = new Matrix4x4();
        public Matrix4x4 perspectiveMatrix = new Matrix4x4();
        private Vector3[] objectScenePoints = null;
        private AForge.Point[] projectedPoints = null;
        private readonly Vector3[] copositObject = new Vector3[4]
        { 
            new Vector3( -1f, -1f, 0 ),
            new Vector3(  1f, -1f, 0 ),
            new Vector3(  1f,  1f, 0 ),
            new Vector3( -1f,  1f, 0 ),
        };
        public ViewPosit(int w,int h) {
            sizeRect = 50;
            wImg = w;
            hImg = h;
            center = new Point(w / 2, h / 2);
            pktList = new System.Collections.Generic.List<Point>();
            pktList.Add(new Point(center.X + sizeRect, center.Y + sizeRect));
            pktList.Add(new Point(center.X - sizeRect, center.Y + sizeRect));
            pktList.Add(new Point(center.X - sizeRect, center.Y - sizeRect));
            pktList.Add(new Point(center.X + sizeRect, center.Y - sizeRect));
            
            colorList = new System.Collections.Generic.List<Bgr>();
            colorList.Add(new Bgr(255,0,0));
            colorList.Add(new Bgr(0,255,0));
            colorList.Add(new Bgr(0,0,255));
            colorList.Add(new Bgr(255,0,255));

            worldMatrix = Matrix4x4.Identity;
            viewMatrix = Matrix4x4.CreateLookAt(new Vector3(0, 0, 5), new Vector3(0, 0, 0));
            perspectiveMatrix = Matrix4x4.CreatePerspective(1, 1, 1, 1000);

        }
        public void drawPoint(Image<Bgr,Byte> img){
                 for (int i=0;i<4;i++) {
                CircleF c = new CircleF(pktList[i], 3);
                img.Draw(c, colorList[i], 2);
            }
            drawLine(img);
        }
        private void drawLine(Image<Bgr, Byte> img) {
            LineSegment2D l1 = new LineSegment2D(pktList[0], pktList[1]);
            img.Draw(l1, new Bgr(0, 255, 0), 1);
            LineSegment2D l2 = new LineSegment2D(pktList[1], pktList[2]);
            img.Draw(l2, new Bgr(0, 255, 0), 1);
            LineSegment2D l3 = new LineSegment2D(pktList[2], pktList[3]);
            img.Draw(l3, new Bgr(0, 255, 0), 1);
            LineSegment2D l4 = new LineSegment2D(pktList[3], pktList[0]);
            img.Draw(l4, new Bgr(0, 255, 0), 1);
        }
        public void updateAngle(float y,float p,float r){
        
                worldMatrix =
                    Matrix4x4.CreateTranslation(new Vector3(0, 0, 0)) *
                    Matrix4x4.CreateFromYawPitchRoll(y, p, r);
                Recalculate();
         
        }
        private void Recalculate()
        {
            int pointsCount = 4;
            objectScenePoints = new Vector3[pointsCount];
            projectedPoints = new AForge.Point[pointsCount];

            int cx = wImg / 2;
            int cy = hImg / 2;

            for (int i = 0; i < pointsCount; i++)
            {
                objectScenePoints[i] = (perspectiveMatrix *
                                       (viewMatrix *
                                       (worldMatrix * copositObject[i].ToVector4()))).ToVector3();

                projectedPoints[i] = new AForge.Point(
                    (int)(cx * objectScenePoints[i].X),
                    (int)(cy * objectScenePoints[i].Y));
            }
            pktList.Clear();
            for (int i = 0, n = projectedPoints.Length; i < n; i++)
            {
                pktList.Add(new Point((int)(cx + projectedPoints[i].X),
                                             (int)(cy - projectedPoints[i].Y)));
            }
  //          Invalidate();
        }

      
    }
}
