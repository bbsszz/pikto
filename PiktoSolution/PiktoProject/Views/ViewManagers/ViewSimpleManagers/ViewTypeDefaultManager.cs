using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Pikto.Views
{
	class ViewTypeDefaultManager : ViewTypeManager<UIElement>
	{
		public UIElement GetView(object parameter)
		{
			return null;
		}

		public void Reset() { }
	}
}
