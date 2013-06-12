using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;


namespace Pikto
{
    public class CameraEventArgs : EventArgs
    {
        private Image<Bgr, Byte> _image;

        public Image<Bgr, Byte> Image
        {
            get { return _image; }
        }

        public CameraEventArgs(Image<Bgr, Byte> image)
        {
            _image = image;
        }
    }
}
