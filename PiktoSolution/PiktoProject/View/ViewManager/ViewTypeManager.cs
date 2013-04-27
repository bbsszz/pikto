using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Pikto.View.ViewManager
{
	interface ViewTypeManager<out V> where V : UIElement
	{
		V GetView(object parameter);
		void Reset();
	}
}
