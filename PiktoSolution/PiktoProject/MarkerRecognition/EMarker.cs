using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.Util;
using System.Drawing;
namespace Pikto
{
    class EMarker: EContour
    {

        Image<Gray, Byte> symbolImage;
        double rotateAngle;
        public EMarker(Contour<Point> cc)
            : base(cc)
        {}
        public EMarker(EContour ec)
            : base(ec)
        { }
        public EMarker(Image<Gray, Byte> rImg, Contour<Point> cc):base(cc)
        {
           symbolImage = rImg;
        }
        public void setSymbolImage(Image<Gray, Byte> rImg) {
            symbolImage = rImg;
        }
        public Image<Gray, Byte> getSymbolImage() {
            return symbolImage;
        }
        public void setRotateAngle(double a) { rotateAngle = a; }
        public float getRotateAngle() { return (float)rotateAngle; }
    }
}
