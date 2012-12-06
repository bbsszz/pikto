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

    //!  Klasa do rozpoznawania piktogramów (markerów)
    /*!
      Klasa została oparta o metody EmguCV. Korzysta z zależnośći geometrycznych które
     * występują w markerze. Algorytm realizujący rozpoznawanie jest został opisany w komentarzach
     * metod klasy.
     * Jak korzystać z klasy
     * 1. Zainicjuj egzemplarz klasy np. MarkerDetector md = new MarkerDetector();
     * 2. wywołuj cyklicznie metodę findMarkers, która w parametrze przyjmuje
     * obraz w skali odcieni szarości. md:
     *  md.findMarkers(image.getGray()); 
     *  Uwaga. Jeśli dysponujemy obrazem BGR, to:
     *   md.findMarkers(image.Convert<Gray, Byte>());
     *   
     * gdy na obrazie jest jeden makrer, pobierz go i narysuj kontury: 
            if (md.getMarkerCount() == 1) {
                EmguTools.draw4ContourAndCircle(image,md.markerAt(0).getContourExternal());
            }
     * można również rysować wiele markerów:
     * for(Marker m: md.getMarkers())
     *      EmguTools.draw4ContourAndCircle(image,m.getContourExternal());
     * 
    */
    class MarkerDetector
    {
        Image<Gray, Byte> grayImage; //! Obraz w skali odcieni szarości (obr wejściowy)
        Image<Gray, Byte> binaryImage; //! Obraz po binaryzacji 
        public List<Contour<Point>> contours; //! Kontury - wszystkie, wytworzone w funkcji findContours 
        public ExtendContours contourPassibleMarkers; //! Kontury które mogą być markerami. W szczególności prostokąty
        public PossibleMarkers possibleMarkers; //! opis zależności pomiędzy konturami dla każdego z konturów
        public List<Marker> markers; //! lista rozpoznanych markerów (piktogramów)
        public List<PointF> listPkt;
        public PointF waznePkt;
        private double minArea;
        private double epsParam;
        //! Konstruktor
        /*!
         Inizjalizacja pól klasy MarkerDetector
        */
        public MarkerDetector()
        {
            contours = new List<Contour<Point>>();
            contourPassibleMarkers = new ExtendContours();
            possibleMarkers = new PossibleMarkers();
            waznePkt = new PointF();
            markers = new List<Marker>();
            listPkt = new List<PointF>();
            minArea = 100.0;       
            epsParam = 7;
        }
        //! funkcja zbiorcza - realizuje cały algorytm
        /*!
         Funkcja rozpoczyna pracę odwyczyszczenia kontenerów zawierających kontury
         * marker oraz zalezności pomiędzy konturami zawarte w klasie PossibleMarkers.
         * Nastepnie wywoływanie są funkcje składowe algorytmu
         * \param imgGray - obraz wejściowy w skali docieni szarości
        */
        public void findMarkers(Image<Gray, Byte> imgGray){
            markers.Clear();
            contours.Clear();
            contourPassibleMarkers.contourClear();
            possibleMarkers.Clear();
            setGrayImage(imgGray);
            binaryImage = threshold(imgGray, 127, 255);
            findContours(binaryImage,contours, binaryImage.Cols /5);
            findCandidates(contours,minArea);
            findRelationAndDeletePassibleMarker(possibleMarkers);
            findInternalFrame(possibleMarkers);
            findTopRectangle(possibleMarkers);
            
        for (int i = 0; i < possibleMarkers.getCount(); i++)
              if (possibleMarkers.isMarkerAt(i))  
                  rot4MarkerAndCreateMarkerElem(i);
              
          
        }
        //! Funkcja poszukuje wszyskich kontur na obrazie
        /*!
          Metoda korzysta z wbudowanej w EmguCV metody findContours
         * Jej parametry pozwalają ustawić metodę aproksymacji konturów oraz formę,
         * w jakiej będą zwracane. W tym przypadku nie ma aproksymacji a kontury zwracane
         * są w formie listy. 
         * Kontur jest dodawany do listy contours, jeżeli liczba punktów, z których się składa
         * jest większa od paramteru minContourPointsAllowed
         * /param imgBin - obraz Binarny
         * /param c - lista kontur 
         * /param minContourPointsAllowed - minamalna liczba punktów w konturze
        */
        private void findContours(Image<Gray, Byte> imgBin,
            List<Contour<Point>> c,int minContourPointsAllowed)
        {       
           for( Contour<Point> allContours =
                imgBin.FindContours(
                Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_NONE,
                Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST)
             ;allContours != null;allContours =allContours.HNext)
            {   
              if (allContours.Total > minContourPointsAllowed)
                 c.Add(allContours);
            }   
        }
        //! Funkcja poszukuje kandydatów na markery na podstawie kilku warunków
        /*!
         Na początku metody kontury są aproksymowane przez linie, która łączy
         * za sobą punkty konturu, których odległóść od proponowanej lini jest
         * nie większa od wartości podanej w epsParam. 
         * Następnie sprawdzane są trzy warunki które pozwalają na klasyfikacje konturu
         * jako prawdopodobny marker, tj:
         * 1. Kontur ma cztery wwierzchołki  - prostokąt 
         * 2. Figura jest zamknięta
         * 3. Pole konturu jest większe od stałej zawartej w paramatrze minArea
         *  Jeśli warunki te są spełnione, kontur dodaje się do listy prawdopodobnych
         *  konturow, które otczają prawdopodobne markery 
         *  [UWAGA] kontury związane z prawdopodobnym markerem nie opisują zależności pomiędzy
         *  nimi, jest to tylko lista. 
         *  [do poprawy] Na koncu zamienia się kolejnośc punktów w konturze, by była ona zawsze
         *  taka sama 
         *  /param c- lista kontur
         *  /param minArea - minimalne pole
        */
        private void findCandidates(List<Contour<Point>> c, double minArea)
        {
            double o;
            Contour<Point> approxCurve;
            foreach (Contour<Point> temp in c)
            {
               approxCurve = temp.ApproxPoly(epsParam);
               if (approxCurve.Count() != 4) 
                   continue;
               if (!approxCurve.Convex)
                   continue;
               if (approxCurve.Area < minArea) 
                   continue;
               contourPassibleMarkers.addContour(approxCurve);
                 
               Point v1 = contourPassibleMarkers.subTwoPointLast(1, 0);
               Point v2 = contourPassibleMarkers.subTwoPointLast(2, 0);
               
                o = (v1.X * v2.Y) - (v1.Y * v2.X);
                if (o > 0.0)
                  contourPassibleMarkers.swapPoint13Last();             
            }
        }
        //! Funkcja poszukuje relacji pomiedzy kandydatami na markery
        /*!
         Z geometri markera wynika, że conajmniej jeden kontur (wewnętrzna ramka) zawiara
         * się w markerze opisanym za pomocą zewnetrznej ramki. Dlatego poszukuje się realizacji
         * przeglądając liste kontur. Gdy kontur j zawiera się w całości w konturze i to
         * kontur i uznaje się za prawdopodobny kontur związany z markerem, i dodaje się
         * jego numer do struktury possibleMarkers. Dodatkowo, dzieki strukturze
         * PossibleMarkers, kojarzymy kontór j z konturem i, w ten sposób, że kontór i zawiera
         * kontur j. Oczywiśćie, kontur i może zawierać wewnatrz wiele kontur (tj, j1,j2...jn)
        */
        private void findRelationAndDeletePassibleMarker(PossibleMarkers pM)
        {
            bool constructor = true;
            for (int i = 0; i < contourPassibleMarkers.getCount(); i++)
            {
                for (int j = 0; j < contourPassibleMarkers.getCount(); j++){
                    if (i != j){
                        if (contourPassibleMarkers.includeContour(i, j))
                        {
                            if (constructor) { 
                                constructor = false; 
                                pM.addPossibleMarker(i); 
                            }
                            pM.addIncludeContourAtLast(j);
                        }
                    }
                }
                constructor = true;
            }
        }
        //! Funkcja poszukuje wewnetrznej ramki markera (zalezność stosunku pól)
        /*! Funkcja sprawdza stosunek pól prawdopodobnej ramki zewnętrznej(ozn. i) oraz 
         * każdego z kontur zawartych w i. Jeśli zawiera się on w przedziale [3.8,4.2] 
         * (przedział wyznaczony eksperymentalnie - w idealniej sytuacji Area(i)/Area(include(i))=4.0;
         * uznajemy, że ramka zawarta w i jest wewnętrzną ramką markera. Jej nuumer wpisujemy
         * do struktury PossibleMArker, w elemencie związanym z konturem (i)
         * w polu numberInternalFrame.
        */
        private void findInternalFrame(PossibleMarkers pM)
        {
            for (int i = 0; i < pM.getCount(); i++)
            {
                for (int j = 0; j < pM.getCountIncludeContourAt(i); j++)
                {
                    int numIncludeFrame = pM.getNumberIncludeContourAt(i, j);
                    double wsp = contourPassibleMarkers.
                                    getContourAreaAt(pM.getNumberBaseAt(i)) /
                            (double)contourPassibleMarkers.
                                    getContourAreaAt(numIncludeFrame);
                    if (wsp > 3.8 && wsp < 4.2)
                    {
                        pM.setInternalFrameAt(i, numIncludeFrame);
                        break;
                    }
                }
            }
        }
        //! Funkcja poszukuje  ramki związanej z prostokątem markera (zalezność zawierania kontór)
        /*! Funkcja sprawdza, czy istnieje kontur zawarty w ramce zewnętrznej(ozn. i) oraz 
         * nie zawarty w ramce wewnętrznej. Jeśli taka istnieje, uznajemy że to szukany
         * prostokąt, a numer kontury z nim związanego wpisujemy do struktury 
         * PossibleMArker, w elemencie związanym z konturem (i)
         * w polu numberFrameRect.
        */
       
        private void findTopRectangle(PossibleMarkers pM)
        {
            for (int i = 0; i < pM.getCount(); i++) {
                int tempBase = pM.getNumberBaseAt(i);                
                    if (pM.getNumberInternalFrameAt(i) != -1) {
                        int internalFrame = pM.getNumberInternalFrameAt(i);
                        for (int j = 0; j < pM.getCountIncludeContourAt(i); j++)
                        {
                            int contourNumber=pM.getNumberIncludeContourAt(i,j);
                            if (contourPassibleMarkers.
                                includeContour(tempBase, contourNumber) &&
                                !contourPassibleMarkers.
                                includeContour(internalFrame, contourNumber))
                                pM.setTopRectAt(i, contourNumber);             
                        }   
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
        public void rot4MarkerAndCreateMarkerElem(int indexPM)
        {    
            Image<Gray, Byte> roi = grayImage.Copy(
           contourPassibleMarkers.getContourAt(
           possibleMarkers.getNumberInternalFrameAt(indexPM))
                                            .BoundingRectangle);          
           double angle =contourPassibleMarkers.getAngleAt(
                  possibleMarkers.getNumberInternalFrameAt(indexPM));
        
           listPkt.Clear();
           PointF center = contourPassibleMarkers.getCenterAt(
                    possibleMarkers.getNumberBaseAt(indexPM));
           PointF centerTopRect = contourPassibleMarkers.getCenterAt(
                    possibleMarkers.getNumberTopRectAt(indexPM));
          RotationMatrix2D<float> rotateBasePos = new RotationMatrix2D<float>(
              new PointF(roi.Width/2,roi.Height/2),angle,1);
          double d=   Math.Sqrt(contourPassibleMarkers.getContourAreaAt(indexPM) );
                     double x = 0.125 * d;
        Image<Gray, Byte> rot= roi.WarpAffine(rotateBasePos,
                                 Emgu.CV.CvEnum.INTER.CV_INTER_AREA,
                                 Emgu.CV.CvEnum.WARP.CV_WARP_FILL_OUTLIERS
                                 ,new Gray(0));
        Rectangle rectInternal= new Rectangle(rot.Width/2-(int)((d/2)-x),
                      rot.Height/2-(int)((d/2)-x),(int)(d-2*x),(int)(d-2*x));
 
            
            markers.Add(new Marker(
contourPassibleMarkers.getContourAt(possibleMarkers.getNumberInternalFrameAt(indexPM)),
contourPassibleMarkers.getContourAt(possibleMarkers.getNumberBaseAt(indexPM)),
           rot.Copy(rectInternal)));
                 markers.Last().angle=calculateAngle(center, centerTopRect, angle);
          
}
        //! Funkcja wylicza kąt obrotu na podstawie wewnętrznego prostokąta
        /*! Funkcja oblicza, w jakich współrzędnych znajdzie się środek prostokąta 
         * po jego obrocie wokół środką markera o kąr 90,180,270. Kąt, dla krórego współrzędna Y
         * jest najmniejsza, jest kątem, o który należy obrócić marker, by znalazł się on w podstawowej pozycji
         * Jednak, po wcześniejszym obrocie do czterech podstawowcyh pocycji, kąt obliczony w pierwszym kroku
         * jest niepoprawny, poprawne kąty wyznaczono eksperymentalnie w zależności od kąta obrotu prostokąta oraz
         * kątu obrotu markera do jednaj z podstawowych pozycji.
        */

        public int calculateAngle(PointF markerCenter, PointF rectCenter, double angle)
        {
            listPkt.Clear();
            listPkt.Add(new PointF(markerCenter.X - rectCenter.X,
                                       markerCenter.Y - rectCenter.Y));
            PointF pktPrim = listPkt.First();
            listPkt.Add(new PointF(-pktPrim.Y, pktPrim.X)); //90
            listPkt.Add(new PointF(-pktPrim.X, -pktPrim.Y)); //180
            listPkt.Add(new PointF(pktPrim.Y, -pktPrim.X)); //270

            float temp = listPkt.First().Y;
            int wsk = 0;
            for (int i = 1; i < 4; i++)
            {
                if (listPkt.ElementAt(i).Y < temp)
                {
                    wsk = i;
                }
            }
            if (angle > -45)
            {
                switch (wsk)
                {
                    case 0: return 180;
                    case 1: return 180;
                    case 2: return -90;
                    case 3: return 0;
                }
            }
            else
            {
                switch (wsk)
                {
                    case 0: return 90;
                    case 1: return 180;
                    case 2: return -90;
                    case 3: return -90;
                }

            }
            return 0;
        }
        private Image<Gray, Byte> threshold
            (Image<Gray, Byte> imgGray, int thresh, int maxVal)
        {
         return   imgGray.ThresholdBinary
                               (new Gray(thresh), new Gray(maxVal));
        }

        public void setGrayImage(Image<Gray, Byte> imgGray)
        {
            grayImage = imgGray;
        }

        public Image<Gray, Byte> getBinaryImage()
        {
            return binaryImage;
        }
        public List<Marker> getMarkers() {
            return markers;
        }
        public Marker markerAt(int index) {
            return markers.ElementAt(index);
        }
        public int getMarkerCount() { return markers.Count; }
    }
}
