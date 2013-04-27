using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Pikto.ViewModel.Commands;

namespace Pikto.ViewModel
{
	abstract class WizardBaseViewModel : BaseViewModel
	{
		private readonly IDictionary<string, ICommand> forwardCmds;
		private readonly IDictionary<string, ICommand> backwardCmds;

		private readonly ICommand justBackward;

		private Stack<string> steps;

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
					return justBackward;
				}
			}
		}

		public ICommand CancelCmd { get; private set; }

		public Action<string> refreshStepAction;

		public WizardBaseViewModel(Action<string> refreshStepAction, ICommand cancelCmd)
		{
			steps = new Stack<string>();
			steps.Push("");
			this.refreshStepAction = s =>
				{
					steps.Push(s);
					refreshStepAction(s);
				};

			CancelCmd = new Command(p =>
				{
					cancelCmd.Execute(p);
					Reset();
				}, cancelCmd.CanExecute);

			forwardCmds = PrepareForwardCommands();
			backwardCmds = PrepareBackwardCommands();

			justBackward = new Command(p =>
				{
					steps.Pop();
					refreshStepAction(steps.Peek());
				}, p =>
				{
					return steps.Count > 1;
				});
		}

		public override void Reset()
		{
			steps.Clear();
			steps.Push("");
		}

		protected abstract IDictionary<string, ICommand> PrepareForwardCommands();
		protected abstract IDictionary<string, ICommand> PrepareBackwardCommands();
	}
}
