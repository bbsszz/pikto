using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.ViewModel;
using System.Windows.Input;
using Pikto.View;

namespace Pikto.View.ViewManager.ViewSimpleManager
{
	class ViewTypeAboutManager : ViewTypeSimpleManager<AboutView, AboutViewModel>
	{
		private ICommand okCmd;

		public ViewTypeAboutManager(ICommand okCmd)
		{
			this.okCmd = okCmd;
		}

		protected override AboutView CreateView()
		{
			var view = new AboutView();
			view.DataContext = ViewModel;
			return view;
		}

		protected override AboutViewModel CreateViewModel()
		{
			var viewModel = new AboutViewModel(okCmd);
			return viewModel;
		}
	}
}
