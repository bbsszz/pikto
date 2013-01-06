using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ART1Paint
{
	interface IMainForm
	{
		event EventHandler NewClicked;
		event EventHandler ClearClicked;

		float Vigilance { get; }
		int ClustersCount { get; }

		void SelectCluster(int cluster, Pattern pattern);
		void ClearRememberedPatterns();
	}
}
