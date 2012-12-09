using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace AdaptiveResonanceTheory1
{
	class OrientingSubsystem
	{
		private OutputLayer outputLayer;
		private IEnumerable<float> dataFromInputLayer;
		private float vigilance;
		private int blockedNeurons;

		public IEnumerable<float> InputData { private get; set; }

		public float Vigilance
		{
			get { return vigilance; }
			set
			{
				Contract.Requires<ArgumentOutOfRangeException>(0f < value && value < 1f, "Vigilance parameter must be in (0,1) range.");
				vigilance = value;
			}
		}

		public OrientingSubsystem(InputLayer inputLayer, OutputLayer outputLayer)
		{
			this.dataFromInputLayer = inputLayer;
			this.outputLayer = outputLayer;
		}

		public void Initialize()
		{
			blockedNeurons = 0;
		}

		public bool CheckResemblance()
		{
			if (blockedNeurons == outputLayer.Size)
			{
				throw new OutOfNeuronsException();
			}
			float resemblance = ComputeResemblance();
			if (resemblance > Vigilance)
			{
				return true;
			}
			else
			{
				outputLayer.BlockWinner();
				++blockedNeurons;
				return false;
			}
		}

		private float ComputeResemblance()
		{
			IEnumerable<float> mlt = Enumerable.Zip<float, float, float>(InputData, dataFromInputLayer, (x1, x2) => 1f - x1 - x2 + 2f * x1 * x2);
			//float common = 0f;
			//foreach (var item in mlt)
			//{
			//    common += item;
			//}
			//return common / InputData.Count<float>();
			return (1f + dataFromInputLayer.Sum()) / (1f + InputData.Sum());
		}
	}
}
