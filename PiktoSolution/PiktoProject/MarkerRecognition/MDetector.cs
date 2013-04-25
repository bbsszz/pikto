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
    class MDetector
    {
        #region Field
        Image<Gray, Byte> grayImage; //! Obraz w skali odcieni szarości (obr wejściowy)
        Image<Gray, Byte> binaryImage; //! Obraz po binaryzacji 
        public List<Contour<Point>> contours; //! Kontury - wszystkie, wytworzone w funkcji findContours 
        public List<EContour> contoursOk;
        public List<EMarker> markers;
        public EMarker oldMarker;
        double minArea;
        int aproxCounter;
        int maxAproxCounter;
        double epsParam;
        bool markerExists;
        #endregion
        #region Constructor
        public MDetector() {
            contours = new List<Contour<Point>>();
            contoursOk=new List<EContour>();
            minArea = 100;
            aproxCounter = 4;
            maxAproxCounter = 1;
            markerExists = false;
            epsParam = 7;
            markers = new List<EMarker>();
        }
        #endregion
        public void findMarkers(Image<Gray, Byte> imgGray)
        {
            contours.Clear();
            contoursOk.Clear();
            markers.Clear();
            markerExists = false;
            grayImage = imgGray;
            binaryImage = threshold(imgGray, 127, 255);
            findContours(binaryImage.Cols / 5);
            findCandidates();
            findRelationBetweenMarker();
            findInternalFrameAndDetectMarker();

            if (markerExists)
            {
                
            rot4MarkerAndCreateMarkerElem(0);
                oldMarker = markers[0];
                aproxCounter = 0 ;
            }
            else {
                if (aproxCounter < maxAproxCounter) {
                    markers.Add(oldMarker);
                    markerExists = true;
                    aproxCounter++;
                }
            }
        }
        #region Method
        /*
         Funkcja poszukuje wszystkich konturów które są reprezentowane jako 
         * zbiór kolejnych punktów. Kontur, którego liczba punktów jest większa 
         * od parametru funkcji (minContourPoints) uznajemy za interesujacy
         * Pozwala to odrzucić niewielkie kontury. Wartosc zmiennej minContourPoints jest
         * dobrana eksperymentalnie
         */
        private void findContours(int minContourPoints)
        {
            for (Contour<Point> allContours =
                 binaryImage.FindContours(
                 Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_NONE,
                 Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST)
              ; allContours != null; allContours = allContours.HNext)
            {
                if (allContours.Total > minContourPoints)
                    contours.Add(allContours);
            }
        }
        //! Funkcja poszukuje kandydatów na markery na podstawie kilku warunków
        /*!
         Na początku metody kontury są aproksymowane przez linie, która łączy
         * za sobą punkty konturu, których odległóść od proponowanej lini jest
         * nie większa od wartości podanej w epsParam. 
         * Następnie sprawdzane są trzy warunki które pozwalają na klasyfikacje konturu
         * jako prawdopodobny marker, tj:
         *  1. Kontur ma cztery wwierzchołki  - prostokąt 
         *  2. Figura jest zamknięta
         *  3. Pole konturu jest większe od stałej zawartej w paramatrze minArea
         *  Jeśli warunki te są spełnione, kontur dodaje się do listy prawdopodobnych
         *  konturow, które otczają prawdopodobne markery 
         * 
         * [UWAGA 1] na tym etapie nie znamy zależności pomiędzy konturami. Tworzymy
         *  tylko listę tych, które spełniają ww. warunki
         * 
         * [UWAGA 2] Na koncu zamienia się kolejnośc punktów w konturze, by była ona zawsze
         *  taka sama [poprawić opis] 
         * 
         * [UWAGA 3] Lista konturów, które stanową wejści dla funkcji zostałą utworzona
         *  przez funkcje findContours
        */
        private void findCandidates()
        {
            double o;
            Contour<Point> approxCurve;
            foreach (Contour<Point> temp in contours)
            {
                approxCurve = temp.ApproxPoly(epsParam);
                if (approxCurve.Count() != 4)
                    continue;
                if (!approxCurve.Convex)
                    continue;
                if (approxCurve.Area < minArea)
                    continue;
                contoursOk.Add(new EContour(approxCurve));

                Point v1 = contoursOk.Last().subTwoPoint(1, 0);
                Point v2 = contoursOk.Last().subTwoPoint(2, 0);

                o = (v1.X * v2.Y) - (v1.Y * v2.X);
                if (o > 0.0)
                    contoursOk.Last().swapPoint13();
            }
        }
        //! Funkcja poszukuje relacji pomiedzy konturami
        /*!
         Z geometri markera wynika,że znajdują się w nim kontóry związane z wewnętrzną ramką oraz
         * prostokąt pozycjonujący. Dlatego z i-tym konturem zostaje związana lista tych kontur, które 
         * znajdują się wewnątrz niego. Oczywiscie, nie sprawdzamy konurow samych ze sobą
        */
        private void findRelationBetweenMarker()
        {
            for (int i = 0; i < contoursOk.Count; i++)
                for (int j = 0; j < contoursOk.Count; j++)
                    if (i != j)
                        if (contoursOk[i].includeOtherConture(contoursOk[j]))
                                contoursOk[i].addIncludeContour(contoursOk[j]);
        }

        
        /* Poszukujemy markera(piktogramu) poprzez testy na konturach w nim zawartych
            Jeśli uznamy, że znależliśmy wewnetrzą ramkę i prostokąt o kontur uznajemy
         * za zewnętrzny kontur markera.
         * [UWAGA 1] opis testów znajduje się przy odpowiednich metodach klasy EContour
         */
        private void findInternalFrameAndDetectMarker()
        {
            markerExists = false;
            foreach(EContour c in contoursOk){
                c.testSquereContour();
                c.testRectangle();
                if (c.getIncludeSquere() !=null && c.getRectangle() != null)
                {
                    markers.Add(new EMarker(c));
                    markerExists = true;
                }
            }
        }

        //! Funkcja wyznaczaROI i obraca algorytm
        /*! Działanie funkcji można poisać w kokach
         *  1. Wytnij z obrazu ROI ograniczono przez zewnętrzną ramkę piktogramu
         *  2. Pobierz kąt obrotu markera UWAGA - kat w zakresie  +-[0-90] 
         *  3. Pobierz współrzędne środka markera oraz środka prostokata.
         *  4. Obróc marker do jednej z czterech podstawowych poozycji
         *  5. Oblicz d, które określa o ile należy pomiejszyć ROI by usunąc
         *  pole zawarte pomiędzy wewnetrzą ramką a obrazem
         *  6. Dodaj marker do listy, zapisująć kontury ramki zewnętrznej i wewnętrznej
         *  7. Oblicz, na podstawie konturu, kąt obrotu markera do Pozycji podstawowej.
        */
        public void rot4MarkerAndCreateMarkerElem(int index)
        {
            Image<Gray, Byte> roi = grayImage.Copy(
                markers[index].getIncludeSquere().getContour().BoundingRectangle);


            PointF center = markers[index].getIncludeSquere().getCenter();
            PointF centerTopRect = markers[index].getRectangle().getCenter();

            double angle = calculateAngle360(center, centerTopRect);
            RotationMatrix2D<float> rotateBasePos = new RotationMatrix2D<float>(
                new PointF(roi.Width / 2, roi.Height / 2), angle, 1.1);
            double d = Math.Sqrt(markers[index].getIncludeSquere().getArea());
            double x = 0.125 * d;
            Image<Gray, Byte> rot = roi.WarpAffine(rotateBasePos,
                                     Emgu.CV.CvEnum.INTER.CV_INTER_AREA,
                                     Emgu.CV.CvEnum.WARP.CV_WARP_FILL_OUTLIERS
                                     , new Gray(0));
            Rectangle rectInternal = new Rectangle(rot.Width / 2 - (int)((d / 2) - x),
                          rot.Height / 2 - (int)((d / 2) - x), (int)(d - 2 * x), (int)(d - 2 * x));

         
          markers[index].setSymbolImage(rot.Copy(rectInternal));
          markers[index].setRotateAngle(angle);

         
        }
        private double calculateAngle360(PointF center, PointF centerRect) {

            PointF newPoint = new PointF();
            newPoint.X = centerRect.X - center.X;
            newPoint.Y = centerRect.Y - center.Y;
         
            double sinAngle = Math.Asin(newPoint.X / Math.Sqrt(newPoint.X * newPoint.X + newPoint.Y * newPoint.Y));
            double a=0;
            if (newPoint.X>0 && newPoint.Y>0)
                a = 90-sinAngle* 180/Math.PI+90 ;
            else
            if (newPoint.X>0 && newPoint.Y<0)
                a = sinAngle* 180 / Math.PI;   
            else
            if (newPoint.X < 0 && newPoint.Y > 0)
                a = -sinAngle * 180 / Math.PI + 180;
            else
            if (newPoint.X < 0 && newPoint.Y < 0)
              a = (90-(-sinAngle * 180 / Math.PI)) + 270; 
                   
                    return a;
        }
        private Image<Gray, Byte> threshold
          (Image<Gray, Byte> imgGray, int thresh, int maxVal)
        {
            return imgGray.ThresholdBinary
                                  (new Gray(thresh), new Gray(maxVal));
        }
        public bool isMarker() {
            return markerExists;
        }

    }
        #endregion
}
