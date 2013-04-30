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

		public ICommand LoadMainPageCommand { get; private set; }
		public ICommand HideSecondaryWindowCommand { get; private set; }

		#region MainPage
		public ICommand OpenLearningPathPromptCommand { get; private set; }
		public ICommand OpenExaminationPathWizardCommand { get; private set; }
		public ICommand OpenSettingsWindowCommand { get; private set; }
		public ICommand ShowAboutWindowCommand { get; private set; }
		public ICommand CloseApplicationCommand { get; private set; }
		#endregion

		#region SettingsPage
		public ICommand ShowStartPiktogramsManagementPathWizardCommand { get; private set; }
		public ICommand ShowStartCategoriesManagementPathWizardCommand { get; private set; }
		public ICommand ShowStartCameraCalibrationWizardCommand { get; private set; }
		#endregion

		public ICommand StartLearningPathCommand { get; private set; }
		public ICommand StartExaminationPathCommand { get; private set; }
		public ParameterPipe<string> ToExaminationPathPipe { get; private set; }

		public ContentManagementService(IContentChange appViewModel, IParameterTransfer parameterTransfer)
		{
			this.contentChange = appViewModel;
			this.parameterTransfer = parameterTransfer;
			PrepareCommands();
		}

		private void PrepareCommands()
		{
			LoadMainPageCommand = new ShowMainWindowCommand(contentChange);
			HideSecondaryWindowCommand = new HideSecondaryWindowCommand(contentChange);

			OpenLearningPathPromptCommand = new OpenLearningPathPromptCommand(contentChange);
			OpenExaminationPathWizardCommand = new OpenExaminationPathWizardCommand(contentChange);
			OpenSettingsWindowCommand = new OpenSettingsWindowCommand(contentChange);
			ShowAboutWindowCommand = new ShowAboutCommand(contentChange);
			CloseApplicationCommand = new CloseApplicationCommand();

			StartLearningPathCommand = new StartLearningPathCommand(contentChange);
			ToExaminationPathPipe = new ParameterPipe<string>();
			StartExaminationPathCommand = new StartExaminationPathCommand(contentChange, ToExaminationPathPipe);


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
