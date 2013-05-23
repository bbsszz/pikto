using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Pikto.ViewModel.SimpleViewModel
{
    class SettingsWindowViewModel : BaseViewModel
    {
        public ICommand OpenPictogramsManagementWizardCmd { get; private set; }
        public ICommand OpenCategoriesManagementWizardCmd { get; private set; }
		public ICommand OpenCameraCalibrationToolCmd { get; private set; }
        public ICommand ReturnToMainWindowCmd { get; private set; }

		public SettingsWindowViewModel(
			ICommand openPictogramsManagementWizardCmd,
			ICommand openCategoriesManagementWizardCmd,
			ICommand openCameraCalibrationToolCmd,
			ICommand returnToMainWindowCmd)
        {
			OpenPictogramsManagementWizardCmd = openPictogramsManagementWizardCmd;
            OpenCategoriesManagementWizardCmd = openCategoriesManagementWizardCmd;
            OpenCameraCalibrationToolCmd = openCameraCalibrationToolCmd;
            ReturnToMainWindowCmd = returnToMainWindowCmd;
        }
    }
}
