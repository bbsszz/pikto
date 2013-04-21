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
		private ICommand startPiktogramsManagementPathCmd;
		private ICommand startCategoriesManagementPathCmd;
		private ICommand startCameraCalibrationCmd;
		private ICommand backCmd;

        public ViewTypeSettingsPageManager(ICommand startPiktogramsManagementPathCmd, ICommand startCategoriesManagementPathCmd, ICommand startCameraCalibrationCmd, ICommand backCmd)
		{
            this.startPiktogramsManagementPathCmd = startPiktogramsManagementPathCmd;
            this.startCategoriesManagementPathCmd = startCategoriesManagementPathCmd;
            this.startCameraCalibrationCmd = startCameraCalibrationCmd;
            this.backCmd = backCmd;
		}

		protected override SettingsPage Create()
		{
			var settingsPage = new SettingsPage();
            settingsPage.DataContext = new SettingsPageViewModel(startPiktogramsManagementPathCmd, startCategoriesManagementPathCmd, startCameraCalibrationCmd, backCmd);
			return settingsPage;
		}
	}
}
