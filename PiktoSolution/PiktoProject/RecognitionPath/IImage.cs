using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Pikto.RecognitionPath
{
	public interface IImage
	{
		PixelMonoColorEnum this[int x, int y] { get; }
		int Size { get; }
	}
}
