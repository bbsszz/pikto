using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Pikto.ViewModel.Commands;

namespace Pikto.ViewModel
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

		//public ICommand FinishCmd { get; private set; }
		public ICommand CancelCmd { get; private set; }

		public WizardNavigationViewModel(VM viewModel, Action<string> refreshStepAction, ICommand cancelCmd)
		{
			ViewModel = viewModel;
			this.refreshStepAction = refreshStepAction;

			steps = new Stack<string>();
			steps.Push("");

			forwardCmds = PrepareForwardCmds();
			backwardCmds = PrepareBackwardCmds();

			standardBackward = new Command(p => PreviousStep(), p => steps.Count > 1);

			CancelCmd = new Command(p =>
			{
				Reset();
				cancelCmd.Execute(p);
			}, cancelCmd.CanExecute);
		}

		protected abstract IDictionary<string, ICommand> PrepareForwardCmds();
		protected abstract IDictionary<string, ICommand> PrepareBackwardCmds();

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

		public override void Reset()
		{
			steps.Clear();
			steps.Push("");
			ViewModel.Reset();
			OnPropertyChanged("ForwardCmd");
			OnPropertyChanged("BackwardCmd");
		}
	}
}
