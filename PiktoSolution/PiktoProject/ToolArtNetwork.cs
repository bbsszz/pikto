using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.RecognitionPath.DiscretizationModule;
using Pikto.RecognitionPath.Classifier;
using AdaptiveResonanceTheory1;
using Pikto.RecognitionPath.ClassMapper;
using Pikto.RecognitionPath;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using System.IO;
namespace Pikto
{
    class ToolArtNetwork
    {
        private RecognitionPath.RecognitionPath recognitionPath;
        private ImageFacade imageFacade;
        private Dictionary<int, int> localMap;
        public ToolArtNetwork(   Dictionary<int, Image<Gray, byte>> dic) 
        {
            var network = ART1Builder.Instance.BuildNetwork(64 * 64, 0.7f);
            var discretizer = new DiscretizationModule(64);
            var classifier = new ART1PictogramClassifier(network);
            var mapper = new ClassMapper();
            recognitionPath = new RecognitionPath.RecognitionPath(discretizer, classifier, mapper);
            localMap = new Dictionary<int, int>();
            imageFacade = new ImageFacade();
            learnNetwork(dic);
        }
         public int CheckCluster(Image<Gray, byte> image)
        {
            //iPictogram.Source = Camera.ToBitmapSource(image);
            imageFacade.Image = image.Bitmap;
            imageFacade.Lock();
            int cluster = recognitionPath.Recognize(imageFacade);
            imageFacade.Unlock();
            Console.WriteLine(cluster);
            return cluster;
        }
        private void learnNetwork(   Dictionary<int, Image<Gray, byte>> dic)
        {
            foreach (var pairElem in dic)
            {
                int c = CheckCluster(pairElem.Value);
                addMap(c, pairElem.Key);
            }
            int i = 0;
        }
        public void  addMap(int claster,int id)
        {
            if (!localMap.ContainsKey(claster))
            {
                localMap[claster] = id;
            }
        }

        public int recognitionPictograms(Image<Gray, byte> image)
        {
            int claster = CheckCluster(image);
            if (localMap.ContainsKey(claster))
            {
                return localMap[claster];
                
            }
            else
            {
                return -1;
            }
        }
        public Image<Gray, byte> byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image i = Image.FromStream(ms);
            Bitmap b = new Bitmap(i);
            return new Image<Gray, byte>(b);
            
        }
    }
} 
