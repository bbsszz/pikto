using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptiveResonanceTheory1
{
	class InputNeuron : INeuron
	{
		private IList<Connection> connections;

		public IEnumerable<Connection> Connections { get { return connections; } }
		public float Input { get; private set; }
		public float Output { get; private set; }

		public InputNeuron()
		{
			connections = new List<Connection>();
		}

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
			float pInput = /*connection.Source.Output */ connection.Weight;
			Output = Input * pInput;
		}

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder("Cs [");
			foreach (var connection in connections)
			{
				builder.Append(connection.Weight);
				builder.Append(", ");
			}
			builder.Remove(builder.Length - 2, 2);
			builder.Append("]");
			return builder.ToString();
		}
	}
}
