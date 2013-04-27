using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Pikto.View.ViewManager.ViewSimpleManager
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
