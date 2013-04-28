using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Pikto.ViewModel;

namespace Pikto.View.ViewManager.ViewSimpleManager
{
	abstract class ViewTypeSimpleManager<V, VM> : ViewTypeManager<V> where V : UIElement where VM : BaseViewModel
	{
		private V view;
		private VM viewModel;

		protected VM ViewModel
		{
			get
			{
				if (viewModel == null)
				{
					viewModel = CreateViewModel();
				}
				return viewModel;
			}
		}

		public V GetView(object parameter)
		{
			if (view == null)
			{
				view = CreateView();
			}
			return view;
		}

		protected abstract V CreateView();
		protected abstract VM CreateViewModel();

		public void Reset() { }
	}
}
