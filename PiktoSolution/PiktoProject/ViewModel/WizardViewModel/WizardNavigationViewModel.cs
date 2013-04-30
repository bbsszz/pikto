using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Pikto.Command;

namespace Pikto.ViewModel.WizardViewModel
{
	abstract class WizardNavigationViewModel<VM> : BaseViewModel where VM : BaseViewModel
	{
		private Action<string> refreshStepAction;

		private Stack<string> steps;
		private IDictionary<string, ICommand> forwardCmds;
		private IDictionary<string, ICommand> backwardCmds;

		private ICommand standardBackward;

		public VM ViewModel { get; private set; }

		public ICommand ForwardCmd
		{
			get
			{
				return forwardCmds[steps.Peek()];
			}
		}

		public ICommand BackwardCmd
		{
			get
			{
				if (backwardCmds.ContainsKey(steps.Peek()))
				{
					return backwardCmds[steps.Peek()];
				}
				else
				{
					return standardBackward;
				}
			}
		}

		public ICommand CancelCmd { get; private set; }

		public WizardNavigationViewModel(VM viewModel, Action<string> refreshStepAction, ICommand cancelCmd)
		{
			ViewModel = viewModel;
			this.refreshStepAction = refreshStepAction;

			steps = new Stack<string>();
			steps.Push("");

			forwardCmds = ForwardCmds();
			backwardCmds = BackwardCmds();

			standardBackward = new BasicCommand(p => PreviousStep(), p => steps.Count > 1);

			CancelCmd = cancelCmd;
		}

		private IDictionary<string, ICommand> ForwardCmds()
		{
			IDictionary<string, ICommand> cmds = new Dictionary<string, ICommand>();
			PrepareForwardCmds(cmds);
			return cmds;
		}

		private IDictionary<string, ICommand> BackwardCmds()
		{
			IDictionary<string, ICommand> cmds = new Dictionary<string, ICommand>();
			PrepareBackwardCmds(cmds);
			return cmds;
		}

		protected abstract void PrepareForwardCmds(IDictionary<string, ICommand> commands);
		protected virtual void PrepareBackwardCmds(IDictionary<string, ICommand> commands) { }

		protected void NextStep(string newStep)
		{
			steps.Push(newStep);
			refreshStepAction(newStep);
			OnPropertyChanged("ForwardCmd");
			OnPropertyChanged("BackwardCmd");
		}

		protected void PreviousStep()
		{
			steps.Pop();
			refreshStepAction(steps.Peek());
			OnPropertyChanged("ForwardCmd");
			OnPropertyChanged("BackwardCmd");
		}

		public override void Loaded()
		{
			ViewModel.Loaded();
		}

		public override void Unloaded()
		{
			ViewModel.Unloaded();
		}
	}
}
