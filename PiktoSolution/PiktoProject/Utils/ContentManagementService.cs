using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Pikto.ViewModel;
using Pikto.ViewModel.Commands;
using Pikto.Views;
using System.Windows;

namespace Pikto.Utils
{
	class ContentManagementService
	{
		private AppViewModel appViewModel;

		public ICommand LoadMainPageCommand { get; private set; }
		public ICommand CloseApplicationCommand { get; private set; }

		public ICommand HideSecondaryWindowCommand { get; private set; }

		public ICommand ShowAboutWindow { get; private set; }

		public ContentManagementService(AppViewModel appViewModel)
		{
			this.appViewModel = appViewModel;
			PrepareCommands();
		}

		private void PrepareCommands()
		{
			CloseApplicationCommand = new Command(p =>
			{
				Application.Current.Shutdown();
			});
			HideSecondaryWindowCommand = new Command(p =>
			{
				appViewModel.SecondaryViewType = ViewType.Default;
			});
			ShowAboutWindow = new Command(p =>
			{
				appViewModel.SecondaryViewType = ViewType.AboutWindow;
			});
		}
	}
}
