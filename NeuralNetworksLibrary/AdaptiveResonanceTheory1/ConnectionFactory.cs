using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptiveResonanceTheory1
{
	class ConnectionFactory
	{
		public Connection Create(INeuron source)
		{
			return new Connection(source);
		}
	}
}
