using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Pikto.ViewModel
{
	class WizardBaseViewModel : BaseViewModel
	{
		public ICommand ForwardCmd { get; private set; }
		public ICommand BackwardCmd { get; private set; }
		public ICommand CancelCmd { get; private set; }

		private IList<string> steps;

		public WizardBaseViewModel(ICommand forwardCmd, ICommand backwardCmd, ICommand cancelCmd, IList<string> steps)
		{
			ForwardCmd = forwardCmd;
			BackwardCmd = backwardCmd;
			CancelCmd = cancelCmd;
			this.steps = new List<string>(steps);
		}
	}
}
