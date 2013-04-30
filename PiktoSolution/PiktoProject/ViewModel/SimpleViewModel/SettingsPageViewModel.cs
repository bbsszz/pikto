using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Pikto.ViewModel.SimpleViewModel
{
    class SettingsWindowViewModel : BaseViewModel
    {
        public ICommand ManagePictogramsCmd { get; private set; }
        public ICommand ManageCategoriesCmd { get; private set; }
        public ICommand ManageCameraCmd { get; private set; }
        public ICommand BackCmd { get; private set; }

        public SettingsWindowViewModel(ICommand managePictogramsCmd, ICommand manageCategoriesCmd, ICommand manageCameraCmd, ICommand backCmd)
        {
            ManagePictogramsCmd = managePictogramsCmd;
            ManageCategoriesCmd = manageCategoriesCmd;
            ManageCameraCmd = manageCameraCmd;
            BackCmd = backCmd;
        }
    }
}
