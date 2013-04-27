using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Pikto.View.ViewManager.ViewSimpleManager
{
	abstract class ViewTypeSimpleManager<V> : ViewTypeManager<V> where V : UIElement
	{
		protected V view;

		public V GetView(object parameter)
		{
			if (view == null)
			{
				view = Create();
			}
			return view;
		}

		protected abstract V Create();

		public void Reset() { }
	}
}
