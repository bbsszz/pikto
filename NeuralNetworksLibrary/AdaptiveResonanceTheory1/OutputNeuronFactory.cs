using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptiveResonanceTheory1
{
	class OutputNeuronFactory
	{
		private const float L = 4f;
		private const float C = 0.5f;
		private readonly Random random = new Random();

		private InputLayer inputLayer;

		readonly float weightUpperBound;

		public OutputNeuronFactory(InputLayer inputLayer)
		{
			this.inputLayer = inputLayer;

			weightUpperBound = L / (L - 1f + inputLayer.Size);
		}

		public OutputNeuron Create()
		{
			return Create(
				() =>
					(1f - (float)random.NextDouble()) * weightUpperBound,
				() =>
					C + (1f - (float)random.NextDouble()) * (1f - C)
				);
		}

		public OutputNeuron Create(IEnumerable<float> data)
		{
			IEnumerator<float> enumerator = data.GetEnumerator();
			return Create(
				() =>
					L / (L - 1f + data.Sum()),
				delegate()
				{
					float val = enumerator.Current;
					enumerator.MoveNext();
					return val;
				}
				);
		}

		private OutputNeuron Create(Func<float> bottomUp, Func<float> topDown)
		{
			IList<Connection> connections = new List<Connection>(inputLayer.Size);
			foreach (var inputNeuron in inputLayer.Neurons)
			{
				Connection connection = new Connection(inputNeuron);
				connection.Weight = bottomUp();
				connections.Add(connection);
			}

			OutputNeuron neuron = new OutputNeuron(connections);
			foreach (var inputNeuron in inputLayer.Neurons)
			{
				Connection connection = new Connection(neuron);
				connection.Weight = topDown();
				inputNeuron.AddConnection(connection);
			}

			return new OutputNeuron(connections);
		}
	}
}
