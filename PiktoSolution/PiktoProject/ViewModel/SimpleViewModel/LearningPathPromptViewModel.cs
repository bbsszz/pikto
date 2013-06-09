using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Pikto.ViewModel.SimpleViewModel
{
	class LearningPathPromptViewModel : BaseViewModel
	{
		public ICommand StartLearningPathCmd { get; private set; }

		public LearningPathPromptViewModel(ICommand startLearningPathCmd)
		{
			StartLearningPathCmd = startLearningPathCmd;
		}
	}
}
