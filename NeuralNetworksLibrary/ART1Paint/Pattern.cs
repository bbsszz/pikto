using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ART1Paint
{
	public class Pattern : IEnumerable<float>
	{
		private PointColour[,] patternData;

		public Pattern(int width, int height)
		{
			patternData = new PointColour[width, height];
		}

		public IEnumerator<float> GetEnumerator()
		{
			return Enumerable.Select<PointColour, float>(Enumerable.Cast<PointColour>(patternData), c => c == PointColour.Black ? 0f : 1f).GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public PointColour this[int i, int j]
		{
			get { return patternData[i, j]; }
			set { patternData[i, j] = value; }
		}

		public Size Size
		{
			get { return new Size(patternData.GetLength(0), patternData.GetLength(1)); }
		}
	}
}
