using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.Util;
using System.Drawing;
using System.Collections.Generic;
namespace Pikto
{
    //!  Klasa z metodami statycznymi do rysowania kontur.
    /*!
    Funkcje  do rysowanie konturów
    */
    static class EmguTools
    {
        static public void draw4ContourAndCircle(Image<Bgr, Byte> img, 
              Contour<Point> contour) {
            img.Draw(contour, new Bgr(255, 0, 0), 3);
            for (int i = 0; i < contour.Total; i++)
            {
                PointF pkt = new PointF(contour[i].X,
                    contour[i].Y);
                img.Draw(new CircleF(pkt, 4), new Bgr(i*50, i*50, 250), 4);
            }
        
        }

        static public void drawContour(Image<Bgr, Byte> img,
          Contour<Point> c, Bgr color)
        {
            img.Draw(c, color, 3);
        }
        static public void drawAllContour(Image<Bgr, Byte> img, 
            List<Contour<Point>> c)
        {
            for (int i = 0; i < c.Count; i++)
                img.Draw(c.ElementAt(i), new Bgr(0,255,255), 1);
        }
        static public void draw3LineFromList(Image<Bgr, Byte> img, List<Point> l)
        {
            LineSegment2D line1 = new LineSegment2D(l[0], l[1]);
            LineSegment2D line2 = new LineSegment2D(l[2], l[3]);
            LineSegment2D line3 = new LineSegment2D(l[4], l[5]);
            img.Draw(line1, new Bgr(255, 0, 0), 3);
            img.Draw(line2, new Bgr(0, 255, 0), 3);
            img.Draw(line3, new Bgr(0, 0, 255), 3);
        }

    }
}