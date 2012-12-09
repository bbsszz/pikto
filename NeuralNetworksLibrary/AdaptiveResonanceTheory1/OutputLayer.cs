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

		private OutputNeuron winner;
		private int winnerI;

		private int blocked;

		public int Winner { get { return winnerI/*neurons.IndexOf(winner)*/; } }

		public OutputLayer(
			OutputNeuronFactory outputNeuronFactory,
			IList<OutputNeuron> neurons,
			int initialClusterCount = 0)
		{
			this.neurons = neurons;
		}

		public void Initialize()
		{
			blocked = 0;
		}

		public void Compute()
		{
			if (blocked == 0)
			{
				foreach (var neuron in neurons)
				{
					neuron.Compute();
				}
			}
			ChooseWinner();
		}

		private void ChooseWinner()
		{
			winnerI = 0;
			winner = neurons[0];
			for (int i = 0; i < neurons.Count; ++i)
			{
				if (neurons[i].CurrentInput > winner.CurrentInput)
				{
					winnerI = i;
					winner = neurons[i];
				}
			}
		}

		public void BlockWinner()
		{
			if (blocked == neurons.Count)
			{
				throw new Exception("Run out of clustering neurons.");
			}
			winner.Block();
			++blocked;
		}

		public int AddNeuron(IEnumerable<float> data)
		{
			neurons.Add(outputNeuronFactory.Create(data));
			return neurons.Count - 1;
		}
	}
}
