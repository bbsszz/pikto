using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Pikto.ViewModel
{
    class SettingsPageViewModel : BaseViewModel
    {
        public ICommand ManagePiktograms { get; private set; }
        public ICommand ManageCategories { get; private set; }
        public ICommand ManageCamera { get; private set; }
        public ICommand BackCmd { get; private set; }

        public SettingsPageViewModel(ICommand managePiktograms, ICommand manageCategories, ICommand manageCamera, ICommand backCmd)
        {
            ManagePiktograms = managePiktograms;
            ManageCategories = manageCategories;
            ManageCamera = manageCamera;
            BackCmd = backCmd;
        }
    }
}
