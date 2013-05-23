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
    class EContour
    {
        Contour<Point> contour;
        List<EContour> includeContour;
        EContour includeSquere;
        EContour rect;
        double [] coeff;

        public EContour() {
            contour = new Contour<Point>(new MemStorage());
            includeContour = new List<EContour>();
            rect = null;
            includeSquere = null;
            coeff = new double [2];
            coeff[0] = 3.8;
            coeff[1] = 4.2;
        }
        public EContour(EContour c) {
            contour = c.getContour();
            includeContour = c.getIncludeContour();
            includeSquere = c.getIncludeSquere();
            rect = c.getRectangle();
        }
        public EContour(Contour<Point> c)
        {
            contour = c;
            includeContour = new List<EContour>();
            rect = null;

            coeff = new double[2];
            coeff[0] = 3.8;
            coeff[1] = 4.2;
        }
        public void setCoeff(double minC, double maxC){
            coeff[0] = minC;
            coeff[1] = maxC;
        }
        public Point elementAt(int i) {
            if (i > (contour.Total - 1))
                return new Point(-1, -1);
            else
                return contour[i];
        }
        public Contour<Point> getContour() { 
            return contour; 
        }
        public List<EContour> getIncludeContour() { 
            return includeContour; 
        }
        public int getCountIncludeContour() { 
            return includeContour.Count; 
        }
        public EContour getRectangle() { 
            return rect; 
        }
        public EContour getIncludeSquere()
        {
            return includeSquere;
        }
        public void addIncludeContour(EContour c) { 
                includeContour.Add(c);
        }
        public double getContourArea()
        {
            return contour.Area;
        }
        public float getAngle() {
            return contour.GetMinAreaRect().angle;
        }
        public PointF getCenter()
        {
            return contour.GetMinAreaRect().center;
        }
        public double getArea()
        {
            return contour.Area;
        }
        public Point subTwoPoint(int i, int j)
        {
            if (contour.Total == 0)
                return new Point(-1, -1);
            else
                return new Point(contour[i].X - contour[j].X,
                                 contour[i].Y - contour[j].Y);

        }
        public bool swapPoint13()
        {
            if (contour.Total == 0)
                return false;
            Point temp1 = contour.Pop();
            Point temp2 = contour.Pop();
            Point temp3 = contour.Pop();
            contour.Push(temp1);
            contour.Push(temp2);
            contour.Push(temp3);
            return true;
        }
        public bool includeOtherConture(EContour c)
        {
            if (contour.InContour(c.elementAt(0)) < 0) return false;
            if (contour.InContour(c.elementAt(1)) < 0) return false;
            if (contour.InContour(c.elementAt(2)) < 0) return false;
            return true;
        }
        public void includeOtherContourAndAdd(EContour c) {
            if (includeOtherConture(c)) 
                    addIncludeContour(c);
        }
        /* Funkcja poszukuje wewnetrznej ramki markera wśród listy kontór, które
         * znajdują się wewnątrz konturu
         * Funkcja sprawdza stosunek pól konturu oraz każdego z kontur w nim
         * zawartych. Jeśli zawiera się on w przedziale [3.8,4.2] 
         * (przedział wyznaczony eksperymentalnie - w idealniej sytuacji Area(i)/Area(include(i))=4.0;
         * uznajemy, że j-ty kontór jest wewnętrzną ramką markera. 
        */
        public void testSquereContour()
        {
            double tempCoeff = 0;
            for (int j = 0; j < includeContour.Count; j++) { 
                tempCoeff = contour.Area/includeContour[j].getContourArea();
                if (tempCoeff > coeff[0] && tempCoeff < coeff[1])
                    includeSquere = includeContour[j];
            }
        }
        //! Funkcja poszukuje  ramki związanej z prostokątem markera (zalezność zawierania kontór)
        /*! Funkcja sprawdza, czy istnieje kontur zawarty w ramce zewnętrznej(ozn. i) oraz 
         * nie zawarty w ramce wewnętrznej. Jeśli taka istnieje, uznajemy że to szukany
         * prostokąt.
        */

        public void testRectangle()
        {
            if (!(includeSquere==null))
            {

                foreach (EContour c in includeContour)
                {
                    if (!includeSquere.includeOtherConture(c))
                        rect = c;

                }
            }
        }

    }
}
