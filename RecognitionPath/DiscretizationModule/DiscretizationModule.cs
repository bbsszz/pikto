using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.RecognitionPath;

namespace Pikto.RecognitionPath.DiscretizationModule
{
	public class DiscretizationModule : IDiscretizer
	{
		private int destSize;

		float thresholdWeight;

		public DiscretizationModule(int destSize)
		{
			this.destSize = destSize;
		}

		public byte[,] Discretize(IImage image)
		{
			byte[,] result = new byte[destSize, destSize];

			float scale = (float)image.Size / (float)destSize;
			thresholdWeight = scale * scale / 2f;

			float fy = 0f;
			for (int py = 0; py < destSize; fy += scale, ++py)
			{
				float fx = 0f;
				for (int px = 0; px < destSize; fx += scale, ++px)
				{
					byte color = calculateDestPixel(image, fx, fy, scale);
					result[px, py] = color;
				}
			}

			return result;
		}

		private byte calculateDestPixel(IImage image, float fx, float fy, float scale)
		{
			float fxmax = fx + scale;
			float fymax = fy + scale;
			float pxmax = Math.Min((float)Math.Ceiling(fxmax), (float)image.Size);
			float pymax = Math.Min((float)Math.Ceiling(fymax), (float)image.Size);
			float weight = 0f;
			for (int py = (int)fy; py < pymax; ++py)
			{
				for (int px = (int)fx; px < pxmax; ++px)
				{
					if (image[px, py] == 0)
					{
						float pixelWeight = calculatePixelWeight(px, py, fx, fy, fxmax, fymax);
						weight += pixelWeight;
						if (weight >= thresholdWeight)
						{
							return 0;
						}
					}
				}
			}
			return 1;
		}

		private float calculatePixelWeight(float px, float py, float fxmin, float fymin, float fxmax, float fymax)
		{
			float width;
			float height;

			if (px <= fxmin)
			{
				width = px + 1f - fxmin;
			}
			else if (px + 1f <= fxmax)
			{
				width = 1f;
			}
			else
			{
				width = fxmax - px;
			}

			if (py <= fymin)
			{
				height = py + 1f - fymin;
			}
			else if (py + 1f <= fymax)
			{
				height = 1f;
			}
			else
			{
				height = fymax - py;
			}

			return width * height;
		}
	}
}
