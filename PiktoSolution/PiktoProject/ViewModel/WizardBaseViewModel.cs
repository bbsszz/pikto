using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Pikto.ViewModel
{
	abstract class WizardBaseViewModel : BaseViewModel
	{
		private ICommand forwardCmd;
		private ICommand backwardCmd;

		public ICommand ForwardCmd
		{
			get { return forwardCmd; }
			set { forwardCmd = PrepareForwardCommand(); }
		}

		public ICommand BackwardCmd
		{
			get { return backwardCmd; }
			set { backwardCmd = PrepareBackwardCommand(); }
		}

		public ICommand CancelCmd { get; private set; }

		public WizardBaseViewModel(ICommand cancelCmd)
		{
			CancelCmd = cancelCmd;
		}

		protected abstract ICommand PrepareForwardCommand();
		protected abstract ICommand PrepareBackwardCommand();
	}
}
