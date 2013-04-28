using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Pikto.ViewModel;
using Pikto.ViewModel.Command;
using Pikto.View;
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

			public ICommand ShowStartLearningPathCommand { get; private set; }
		    public ICommand ShowStartExaminationPathWizardCommand { get; private set; }
		    public ICommand ShowAboutWindowCommand { get; private set; }
        #endregion

        #region SettingsPage
            public ICommand ShowSettingsPageCommand { get; private set; }
            public ICommand ShowStartPiktogramsManagementPathWizardCommand { get; private set; }
            public ICommand ShowStartCategoriesManagementPathWizardCommand { get; private set; }
            public ICommand ShowStartCameraCalibrationWizardCommand { get; private set; }
        #endregion

        public ContentManagementService(IContentChange appViewModel)
		{
			this.contentChange = appViewModel;
			PrepareCommands();
		}

		private void PrepareCommands()
		{
			CloseApplicationCommand = new BasicCommand(p =>
			{
				Application.Current.Shutdown();
			});
			HideSecondaryWindowCommand = new BasicCommand(p =>
			{
				contentChange.SecondaryViewType = ViewType.Default;
			});

            LoadMainPageCommand = new BasicCommand(p =>
            {
                contentChange.PrimaryViewType = ViewType.MainPage;
                contentChange.SecondaryViewType = ViewType.Default;
            });

			ShowStartLearningPathCommand = new StartLearningPathCommand(contentChange);

			ShowStartExaminationPathWizardCommand = new StartExaminationPathCommand(contentChange);

			ShowAboutWindowCommand = new BasicCommand(p =>
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
			contentChange.SecondaryViewTypeWithStep(viewType, step);
		}
	}
}
