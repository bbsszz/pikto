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
		private ICommand StartPiktogramsManagementPathCmd;
		private ICommand StartCategoriesManagementPathCmd;
		private ICommand StartCameraCalibrationCmd;
		private ICommand BackCmd;

        public ViewTypeSettingsWindowManager(ICommand startPiktogramsManagementPathCmd, ICommand startCategoriesManagementPathCmd, ICommand startCameraCalibrationCmd, ICommand backCmd)
		{
            this.StartPiktogramsManagementPathCmd = startPiktogramsManagementPathCmd;
            this.StartCategoriesManagementPathCmd = startCategoriesManagementPathCmd;
            this.StartCameraCalibrationCmd = startCameraCalibrationCmd;
            this.BackCmd = backCmd;
		}

		protected override SettingsWindow CreateView()
		{
			var settingsPage = new SettingsWindow();
			settingsPage.DataContext = ViewModel;
			return settingsPage;
		}

		protected override SettingsWindowViewModel CreateViewModel()
		{
			var viewModel = new SettingsWindowViewModel(StartPiktogramsManagementPathCmd, StartCategoriesManagementPathCmd, StartCameraCalibrationCmd, BackCmd);
			return viewModel;
		}
	}
}
