using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Pikto.ViewModel.SimpleViewModel
{
	class StartLearningPathViewModel : BaseViewModel
	{
		public ICommand StartLearningPathCmd { get; private set; }

		public StartLearningPathViewModel(ICommand startLearningPathCmd)
		{
			StartLearningPathCmd = startLearningPathCmd;
		}
	}
}
