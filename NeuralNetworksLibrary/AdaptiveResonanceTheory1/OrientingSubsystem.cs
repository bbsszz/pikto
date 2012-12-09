using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptiveResonanceTheory1
{
	class OrientingSubsystem
	{
		private OutputLayer outputLayer;

		public IEnumerable<float> InputData { private get; set; }

		private IEnumerable<float> inputFromInputLayer;

		public float Vigilance { private get; set; }

		public OrientingSubsystem(InputLayer inputLayer, OutputLayer outputLayer)
		{
			this.inputFromInputLayer = inputLayer;
			this.outputLayer = outputLayer;
		}

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
			IEnumerable<float> mlt = Enumerable.Zip<float, float, float>(InputData, inputFromInputLayer, (x1, x2) => 1f - x1 - x2 + 2f * x1 * x2);
			float common = 0f;
			foreach (var item in mlt)
			{
				common += item;
			}
			return common / InputData.Count<float>();
		}

		private void Reset()
		{
			outputLayer.BlockWinner();
		}
	}
}
