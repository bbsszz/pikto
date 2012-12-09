using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptiveResonanceTheory1
{
	class OutputLayer
	{
		private OutputNeuronFactory outputNeuronFactory;
		private IList<OutputNeuron> neurons;

		private bool firstRun;

		public int Winner { get; private set; }
		public int Size { get { return neurons.Count; } }

		public OutputLayer(
			OutputNeuronFactory outputNeuronFactory,
			IList<OutputNeuron> neurons,
			int initialClusterCount = 0)
		{
			this.outputNeuronFactory = outputNeuronFactory;
			this.neurons = neurons;
			Winner = neurons.Count - 1;
		}

		public void Initialize()
		{
			firstRun = true;
		}

		public void Compute()
		{
			if (firstRun)
			{
				foreach (var neuron in neurons)
				{
					neuron.Compute();
				}
				firstRun = false;
			}
			ChooseWinner();
		}

		private void ChooseWinner()
		{
			for (int i = 0; i < neurons.Count; ++i)
			{
				if (neurons[i].CurrentInput > neurons[Winner].CurrentInput)
				{
					Winner = i;
				}
			}
		}

		public void BlockWinner()
		{
			neurons[Winner].Block();
		}

		public int AddNeuron(IEnumerable<float> data)
		{
			neurons.Add(outputNeuronFactory.Create(data));
			Winner = neurons.Count - 1;
			return Winner;
		}
	}
}
