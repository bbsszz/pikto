using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptiveResonanceTheory1
{
	class InputLayerBuilder
	{
		private InputNeuronFactory inputNeuronFactory;

		public InputLayerBuilder(InputNeuronFactory inputNeuronFactory)
		{
			this.inputNeuronFactory = inputNeuronFactory;
		}

		public InputLayer Build(int inputSize)
		{
			IList<InputNeuron> neurons = new List<InputNeuron>(inputSize);
			for (int i = 0; i < inputSize; ++i)
			{
				neurons.Add(inputNeuronFactory.Create());
			}

			InputLayer inputLayer = new InputLayer(neurons);

			return inputLayer;
		}
	}
}
