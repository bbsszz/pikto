using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Pikto.ViewModel.SimpleViewModel;

namespace Pikto.View.ViewManager.ViewSimpleManager
{
    class ViewTypeSettingsWindowManager : ViewTypeSimpleManager<SettingsWindow, SettingsWindowViewModel>
	{
		private ICommand openPictogramsManagementWizardCmd;
		private ICommand openCategoriesManagementWizardCmd;
		private ICommand openCameraCalibrationToolCmd;
		private ICommand returnToMainWindowCmd;

		public ViewTypeSettingsWindowManager(
			ICommand openPictogramsManagementWizardCmd,
			ICommand openCategoriesManagementWizardCmd,
			ICommand openCameraCalibrationToolCmd,
			ICommand returnToMainWindowCmd)
		{
			this.openPictogramsManagementWizardCmd = openPictogramsManagementWizardCmd;
            this.openCategoriesManagementWizardCmd = openCategoriesManagementWizardCmd;
            this.openCameraCalibrationToolCmd = openCameraCalibrationToolCmd;
            this.returnToMainWindowCmd = returnToMainWindowCmd;
		}

		protected override SettingsWindow CreateView()
		{
			var settingsPage = new SettingsWindow();
			settingsPage.DataContext = ViewModel;
			return settingsPage;
		}

		protected override SettingsWindowViewModel CreateViewModel()
		{
			var viewModel = new SettingsWindowViewModel(openPictogramsManagementWizardCmd, openCategoriesManagementWizardCmd, openCameraCalibrationToolCmd, returnToMainWindowCmd);
			return viewModel;
		}
	}
}
