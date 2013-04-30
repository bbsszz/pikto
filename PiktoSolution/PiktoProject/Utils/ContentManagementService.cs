using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Pikto.ViewModel;
using Pikto.View;
using System.Windows;
using Pikto.Command;

namespace Pikto.Utils
{
	class ContentManagementService
	{
		private IContentChange contentChange;
		private IParameterTransfer parameterTransfer;

        #region MainPage
            public ICommand LoadMainPageCommand { get; private set; }
		    public ICommand CloseApplicationCommand { get; private set; }

		    public ICommand HideSecondaryWindowCommand { get; private set; }

			public ICommand MenuStartLearningPathCommand { get; private set; }
			public ICommand MenuExaminationPathWizardCommand { get; private set; }

			public ICommand StartLearningPathCommand { get; private set; }
			public ICommand StartExaminationPathCommand { get; private set; }

		    public ICommand AboutWindowCommand { get; private set; }
        #endregion

        #region SettingsPage
            public ICommand ShowSettingsPageCommand { get; private set; }
            public ICommand ShowStartPiktogramsManagementPathWizardCommand { get; private set; }
            public ICommand ShowStartCategoriesManagementPathWizardCommand { get; private set; }
            public ICommand ShowStartCameraCalibrationWizardCommand { get; private set; }
        #endregion

        public ContentManagementService(IContentChange appViewModel, IParameterTransfer parameterTransfer)
		{
			this.contentChange = appViewModel;
			this.parameterTransfer = parameterTransfer;
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

			MenuStartLearningPathCommand = new MenuStartLearningPathCommand(contentChange);
			MenuExaminationPathWizardCommand = new MenuExaminationPathWizardCommand(contentChange);

			StartLearningPathCommand = new StartLearningPathCommand(contentChange);
			StartExaminationPathCommand = new StartExaminationPathCommand(contentChange, parameterTransfer);

			AboutWindowCommand = new BasicCommand(p =>
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
