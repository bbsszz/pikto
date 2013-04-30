using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Pikto.ViewModel.SimpleViewModel
{
	class MainWindoViewModel : BaseViewModel
	{
		public ICommand StartLearningPathCmd { get; private set; }
		public ICommand ExaminationPathWizardCmd { get; private set; }
		public ICommand SettingsCmd { get; private set; }
		public ICommand AboutCmd { get; private set; }
		public ICommand ExitCmd { get; private set; }

		public MainWindoViewModel(ICommand startLearningPathCmd, ICommand examinationPathWizardCmd, ICommand settingsCmd, ICommand aboutCmd, ICommand exitCmd)
		{
			StartLearningPathCmd = startLearningPathCmd;
			ExaminationPathWizardCmd = examinationPathWizardCmd;
			SettingsCmd = settingsCmd;
			AboutCmd = aboutCmd;
			ExitCmd = exitCmd;
		}
	}
}
