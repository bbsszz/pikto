using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.View;

namespace Pikto.ViewModel
{
	interface IContentChange
	{
		ViewType PrimaryViewType { set; }

		ViewType SecondaryViewType { get; set; }
		string WizardStep { get; }
		void SecondaryViewTypeWithStep(ViewType viewType, string step);
	}
}
