using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptiveResonanceTheory1
{
	class InputLayer : IEnumerable<float>
	{
		private OutputLayer outputLayer;
		private OrientingSubsystem orientingSubsystem;

		private IList<InputNeuron> neurons;

		public int Size { get { return neurons.Count; } }
		public IEnumerable<InputNeuron> Neurons { get { return neurons; } }

		public void Activate(IEnumerable<float> data)
		{
			IEnumerator<float> input = data.GetEnumerator();
			foreach (var neuron in neurons)
			{
				neuron.Activate(input.Current);
				input.MoveNext();
			}
			outputLayer.Compute();
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
