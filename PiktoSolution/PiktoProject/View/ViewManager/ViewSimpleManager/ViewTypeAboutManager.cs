using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.ViewModel;
using System.Windows.Input;
using Pikto.View;

namespace Pikto.View.ViewManager.ViewSimpleManager
{
	class ViewTypeAboutManager : ViewTypeSimpleManager<AboutView>
	{
		private ICommand okCmd;

		public ViewTypeAboutManager(ICommand okCmd)
		{
			this.okCmd = okCmd;
		}

		protected override AboutView Create()
		{
			var viewModel = new AboutViewModel(okCmd);
			var view = new AboutView();
			view.DataContext = viewModel;
			return view;
		}
	}
}
