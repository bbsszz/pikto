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
		event EventHandler LoadClicked;

		float Vigilance { get; }
		int ClustersCount { get; }

		void SelectCluster(int cluster, Pattern pattern);
		void ClearRememberedPatterns();
	}
}
