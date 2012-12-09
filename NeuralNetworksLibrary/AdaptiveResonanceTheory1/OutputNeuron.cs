using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptiveResonanceTheory1
{
	class OutputNeuron : INeuron
	{
		private IList<Connection> connections;

		public float Output { get; private set; }
		public float CurrentInput { get; private set; }

		public OutputNeuron(IList<Connection> connections)
		{
			this.connections = connections;
		}

		public void Compute()
		{
			CurrentInput = 0f;
			foreach (Connection connection in connections)
			{
				CurrentInput += connection.Source.Output * connection.Weight;
			}
		}

		public void Block()
		{
			CurrentInput = 0f;
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
