using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Pikto.ViewModel.Commands
{
	sealed class Command : ICommand
	{
		private Action<object> action;
		private Predicate<object> canExecutePredicate;

		public Command(Action<object> action)
			: this(action, null)
		{ }

		public Command(Action<object> action, Predicate<object> canExecutePredicate)
		{
			this.action = action;
			this.canExecutePredicate = canExecutePredicate;
		}

		public bool CanExecute(object parameter)
		{
			return canExecutePredicate == null ? true : canExecutePredicate(parameter);
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void Execute(object parameter)
		{
			action(parameter);
		}
	}
}
