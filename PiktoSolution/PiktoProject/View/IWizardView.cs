using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Pikto.View
{
	interface IWizardView
	{
		object StepContent { set; }

		event RoutedEventHandler Loaded;
		event RoutedEventHandler Unloaded;
	}
}
