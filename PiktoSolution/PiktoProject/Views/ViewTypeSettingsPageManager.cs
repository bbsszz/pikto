using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Pikto.ViewModel;

namespace Pikto.Views
{
    class ViewTypeSettingsPageManager : ViewTypeSimpleManager<SettingsPage>
	{
		private ICommand StartPiktogramsManagementPathCmd;
		private ICommand StartCategoriesManagementPathCmd;
		private ICommand StartCameraCalibrationCmd;
		private ICommand BackCmd;

        public ViewTypeSettingsPageManager(ICommand startPiktogramsManagementPathCmd, ICommand startCategoriesManagementPathCmd, ICommand startCameraCalibrationCmd, ICommand backCmd)
		{
            this.StartPiktogramsManagementPathCmd = startPiktogramsManagementPathCmd;
            this.StartCategoriesManagementPathCmd = startCategoriesManagementPathCmd;
            this.StartCameraCalibrationCmd = startCameraCalibrationCmd;
            this.BackCmd = backCmd;
		}

		protected override SettingsPage Create()
		{
			var settingsPage = new SettingsPage();
            settingsPage.DataContext = new SettingsPageViewModel(StartPiktogramsManagementPathCmd, StartCategoriesManagementPathCmd, StartCameraCalibrationCmd, BackCmd);
			return settingsPage;
		}
	}
}
