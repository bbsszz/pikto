using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptiveResonanceTheory1
{
	class OutputLayer
	{
		private const float L = 4f;

		//private GainController gainController;
		private InputLayer inputLayer;

		private IList<OutputNeuron> neurons;
		private OutputNeuron winner;
		private int blocked;

		public int Winner { get { return neurons.IndexOf(winner); } }

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
			int winner = ChooseWinner();
			//gainController.Block();
			inputLayer.Compute(winner);
		}

		private int ChooseWinner()
		{
			int winnerI = 0;
			winner = neurons[0];
			for (int i = 0; i < neurons.Count; ++i)
			{
				if (neurons[i].CurrentInput > winner.CurrentInput)
				{
					winnerI = i;
					winner = neurons[i];
				}
			}
			return winnerI;
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
			IList<Connection> connections = new List<Connection>(inputLayer.Size);
			float sum = data.Sum();
			foreach (var inputNeuron in inputLayer.Neurons)
			{
				Connection connection = new Connection(inputNeuron);
				connection.Weight = L / (L - 1f + sum);
				connections.Add(connection);
			}

			OutputNeuron neuron = new OutputNeuron(connections); // move it to a factory
			foreach (var inputNeuron in inputLayer.Neurons)
			{
				Connection connection = new Connection(neuron);
				connection.Weight = 1f;
				inputNeuron.AddConnection(connection);
			}

			neurons.Add(neuron);

			return neurons.Count - 1;
		}
	}
}
