using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptiveResonanceTheory1
{
	class InputNeuron : INeuron
	{
		private IList<Connection> connections;

		public float Input { get; private set; }
		public float Output { get; private set; }

		public void AddConnection(Connection connection)
		{
			connections.Add(connection);
		}

		public void Activate(float data)
		{
			Input = data;
			Output = data;
		}

		public void Compute(int winner)
		{
			Connection connection = connections[winner];
			float pInput = connection.Source.Output * connection.Weight;
			Output = Input * pInput;
		}
	}
}
