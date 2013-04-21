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
		private IContentChange contentChange;

		public ICommand LoadMainPageCommand { get; private set; }
		public ICommand CloseApplicationCommand { get; private set; }

		public ICommand HideSecondaryWindowCommand { get; private set; }

		public ICommand ShowStartExaminationPathWizardCommand { get; private set; }
		public ICommand ShowAboutWindowCommand { get; private set; }

        public ICommand ShowSettingsPageCommand { get; private set; }
		

		public ContentManagementService(AppViewModel appViewModel)
		{
			this.contentChange = appViewModel;
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
				contentChange.SecondaryViewType = ViewType.Default;
			});
			ShowStartExaminationPathWizardCommand = new StartExaminationPathCommand(contentChange);
			ShowAboutWindowCommand = new Command(p =>
			{
				contentChange.SecondaryViewType = ViewType.AboutWindow;
			});
		}
	}
}
