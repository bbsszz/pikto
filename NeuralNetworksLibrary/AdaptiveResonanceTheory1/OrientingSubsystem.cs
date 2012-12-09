using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptiveResonanceTheory1
{
	class OrientingSubsystem
	{
		private OutputLayer outputlayer;

		public IEnumerable<float> InputData { private get; set; }
		public IEnumerable<float> InputFromInputLayer { private get; set; }

		public float Vigilance { private get; set; }

		public bool CheckResemblance()
		{
			if (ComputeResemblance() > Vigilance)
			{
				return true;
			}
			else
			{
				Reset();
				return false;
			}
		}

		private float ComputeResemblance()
		{
			IEnumerable<float> mlt = Enumerable.Zip<float, float, float>(InputData, InputFromInputLayer, (x1, x2) => 1f - x1 - x2 + 2f * x1 * x2);
			float common = 0f;
			foreach (var item in mlt)
			{
				common += item;
			}
			return common / InputData.Count<float>();
		}

		private void Reset()
		{
			outputlayer.BlockWinner();
		}
	}
}
