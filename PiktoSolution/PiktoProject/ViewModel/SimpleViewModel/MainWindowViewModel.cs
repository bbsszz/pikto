using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Pikto.ViewModel.SimpleViewModel
{
	class MainWindowViewModel : BaseViewModel
	{
		public ICommand OpenLearningPathPromptCmd { get; private set; }
		public ICommand OpenExaminationPathWizardCmd { get; private set; }
		public ICommand OpenSettingsCmd { get; private set; }
		public ICommand ShowAboutCmd { get; private set; }
		public ICommand ExitCmd { get; private set; }

		public MainWindowViewModel(
			ICommand openLearningPathPromptCmd,
			ICommand openExaminationPathWizardCmd,
			ICommand openSettingsCmd,
			ICommand showAboutCmd,
			ICommand exitCmd)
		{
			OpenLearningPathPromptCmd = openLearningPathPromptCmd;
			OpenExaminationPathWizardCmd = openExaminationPathWizardCmd;
			OpenSettingsCmd = openSettingsCmd;
			ShowAboutCmd = showAboutCmd;
			ExitCmd = exitCmd;
		}
	}
}
