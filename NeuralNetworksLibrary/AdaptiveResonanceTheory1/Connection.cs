using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptiveResonanceTheory1
{
	class Connection
	{
		public INeuron Source { get; private set; }
		public float Weight { get; set; }

		public Connection(INeuron source)
		{
			Source = source;
		}
	}
}
