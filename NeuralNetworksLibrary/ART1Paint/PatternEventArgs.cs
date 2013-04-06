using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ART1Paint
{
	class PatternEventArgs : EventArgs
	{
		public int Cluster { get; private set; }
		public Pattern Pattern { get; private set; }

		public PatternEventArgs(int cluster, Pattern pattern)
		{
			Cluster = cluster;
			Pattern = pattern;
		}
	}
}
