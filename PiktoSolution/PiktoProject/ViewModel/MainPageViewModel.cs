using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Pikto.ViewModel
{
	class MainPageViewModel : BaseViewModel
	{
		public ICommand StartLearningPathCmd { get; private set; }
		public ICommand StartExaminationPathCmd { get; private set; }
		public ICommand SettingsCmd { get; private set; }
		public ICommand AboutCmd { get; private set; }
		public ICommand ExitCmd { get; private set; }

		public MainPageViewModel(ICommand startLearningPathCmd, ICommand startExaminationPathCmd, ICommand settingsCmd, ICommand aboutCmd, ICommand exitCmd)
		{
			StartLearningPathCmd = startLearningPathCmd;
			StartExaminationPathCmd = startExaminationPathCmd;
			SettingsCmd = settingsCmd;
			AboutCmd = aboutCmd;
			ExitCmd = exitCmd;
		}
	}
}
