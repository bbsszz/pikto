using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Pikto.Views;

namespace Pikto.ViewModel.Commands
{
	class SettingsCommand : ICommand
	{
        private IContentChange contentChange;

		public SettingsCommand(IContentChange contentChange)
		{
			this.contentChange = contentChange;
		}

		public bool CanExecute(object parameter)
		{
			return true; // not implemented
		}

		public event EventHandler CanExecuteChanged;

		public void Execute(object parameter)
		{
            contentChange.PrimaryViewType = ViewType.SettingsPage;
		}
	}
}
