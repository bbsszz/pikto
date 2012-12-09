using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptiveResonanceTheory1
{
	class InputLayer : IEnumerable<float>
	{
		private IList<InputNeuron> neurons;

		public int Size { get { return neurons.Count; } }
		public IEnumerable<InputNeuron> Neurons { get { return neurons; } }

		public InputLayer(IList<InputNeuron> neurons)
		{
			this.neurons = neurons;
		}

		public void Activate(IEnumerable<float> data)
		{
			IEnumerator<float> input = data.GetEnumerator();
			foreach (var neuron in neurons)
			{
				input.MoveNext();
				neuron.Activate(input.Current);
			}
		}

		public void Compute(int winner)
		{
			foreach (var neuron in neurons)
			{
				neuron.Compute(winner);
			}
		}

		public IEnumerator<float> GetEnumerator()
		{
			return neurons.Select<InputNeuron, float>(n => n.Output).GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
