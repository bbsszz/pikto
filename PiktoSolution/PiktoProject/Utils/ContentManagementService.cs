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
        #region MainPage
            public ICommand LoadMainPageCommand { get; private set; }
		    public ICommand CloseApplicationCommand { get; private set; }

		    public ICommand HideSecondaryWindowCommand { get; private set; }

		    public ICommand ShowStartExaminationPathWizardCommand { get; private set; }
		    public ICommand ShowAboutWindowCommand { get; private set; }
        #endregion

        #region SettingsPage
            public ICommand ShowSettingsPageCommand { get; private set; }
            public ICommand ShowStartPiktogramsManagementPathWizardCommand { get; private set; }
            public ICommand ShowStartCategoriesManagementPathWizardCommand { get; private set; }
            public ICommand ShowStartCameraCalibrationWizardCommand { get; private set; }
        #endregion

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

            LoadMainPageCommand = new Command(p =>
            {
                contentChange.PrimaryViewType = ViewType.MainPage;
                contentChange.SecondaryViewType = ViewType.Default;
            });

			ShowStartExaminationPathWizardCommand = new StartExaminationPathCommand(contentChange);

            
			ShowAboutWindowCommand = new Command(p =>
			{
				contentChange.SecondaryViewType = ViewType.AboutWindow;
			});

            ShowSettingsPageCommand = new SettingsCommand(contentChange);
            ShowStartPiktogramsManagementPathWizardCommand = new StartPiktogramsManagementPathCommand(contentChange);
            ShowStartCategoriesManagementPathWizardCommand = new StartCategoriesManagementPathCommand(contentChange);
            ShowStartCameraCalibrationWizardCommand = new StartCameraCalibrationCommand(contentChange);
		}

		public void RefreshSecondaryView(ViewType viewType, string step)
		{
			contentChange.SecondaryViewType = viewType;
			contentChange.WizardStep = step;
		}
	}
}
