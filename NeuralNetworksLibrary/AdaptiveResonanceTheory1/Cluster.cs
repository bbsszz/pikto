using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptiveResonanceTheory1
{
	public class Cluster
	{
		public int Index { get; private set; }
		public IEnumerable<float> BottomUpConnections { get; private set; }
		public IEnumerable<float> TopDownConnections { get; private set; }

		public Cluster(int index, IEnumerable<float> bot, IEnumerable<float> top)
		{
			Index = index;
			BottomUpConnections = new List<float>(bot);
			TopDownConnections = new List<float>(top);
		}
	}
}
