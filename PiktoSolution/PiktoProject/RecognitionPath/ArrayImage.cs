using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pikto.RecognitionPath
{
	public class ArrayImage : IImage
	{
		private byte[,] image;

		public ArrayImage(int size)
		{
			image = new byte[size, size];
		}

		public PixelMonoColorEnum this[int x, int y]
		{
			get { return image[x, y] == 0 ? PixelMonoColorEnum.Black : PixelMonoColorEnum.White; }
			set { image[x, y] = (byte)value; }
		}

		public int Size
		{
			get { return image.GetLength(0); }
		}
	}
}
