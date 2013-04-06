using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Pikto.RecognitionPath
{
	class ImageFacade : IImage
	{
		private UnsafeBitmap bmp;

		public Bitmap Image
		{
			set { bmp = new UnsafeBitmap(value); }
		}

		public PixelMonoColorEnum this[int x, int y]
		{
			get
			{
				return bmp.GetPixel(x, y).GetBrightness() < 0.5f ? PixelMonoColorEnum.Black : PixelMonoColorEnum.White;
			}
		}

		public int Size
		{
			get { return bmp.Bitmap.Width; }
		}

		public void Lock()
		{
			bmp.LockBitmap();
		}

		public void Unlock()
		{
			bmp.UnlockBitmap();
		}
	}
}
