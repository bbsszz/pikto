using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptiveResonanceTheory1
{
	class OutputLayerBuilder
	{
		private OutputNeuronFactory outputNeuronFactory;

		public OutputLayerBuilder(OutputNeuronFactory outputNeuronFactory)
		{
			this.outputNeuronFactory = outputNeuronFactory;
		}

		public OutputLayer Build(int initialClusterCount)
		{
			IList<OutputNeuron> neurons = new List<OutputNeuron>(initialClusterCount);
			for (int i = 0; i < initialClusterCount; ++i)
			{
				OutputNeuron neuron = outputNeuronFactory.Create();
				neurons.Add(neuron);
			}

			OutputLayer outputLayer = new OutputLayer(outputNeuronFactory, neurons);

			return outputLayer;
		}
	}
}
