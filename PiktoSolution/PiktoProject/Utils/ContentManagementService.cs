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
		public ICommand OpenPictogramsManagementWizardCommand { get; private set; }
		public ICommand OpenCategoriesManagementWizardCommand { get; private set; }
		public ICommand OpenCameraCalibrationToolCommand { get; private set; }
		public ICommand ReturnToMainWindowCommand { get; private set; }
		#endregion

		public ICommand StartLearningPathCommand { get; private set; }
		public ICommand StartExaminationPathCommand { get; private set; }
		public SingleParameterPipe<string> ToExaminationPathPipe { get; private set; } // the type should be changed appropriately

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
			{
				StartLearningPathCommand = new StartLearningPathCommand(contentChange);
			}
			OpenExaminationPathWizardCommand = new OpenExaminationPathWizardCommand(contentChange);
			{
				ToExaminationPathPipe = new SingleParameterPipe<string>();
				StartExaminationPathCommand = new StartExaminationPathCommand(contentChange, ToExaminationPathPipe);
			}
			OpenSettingsWindowCommand = new OpenSettingsWindowCommand(contentChange);
			{
				OpenPictogramsManagementWizardCommand = new OpenPictogramsManagementWizardCommand(contentChange);
				OpenCategoriesManagementWizardCommand = new OpenCategoriesManagementWizardCommand(contentChange);
				OpenCameraCalibrationToolCommand = new OpenCameraCalibrationToolCommand(contentChange);
				ReturnToMainWindowCommand = LoadMainPageCommand;
			}
			ShowAboutWindowCommand = new ShowAboutCommand(contentChange);
			CloseApplicationCommand = new CloseApplicationCommand();
		}

		public void RefreshSecondaryView(ViewType viewType, string step)
		{
			contentChange.SecondaryViewTypeWithStep(viewType, step);
		}
	}
}
