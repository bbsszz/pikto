using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Pikto.View;
using Pikto.ViewModel;

namespace Pikto.Command
{
	class OpenSettingsWindowCommand : ICommand
	{
        private IContentChange contentChange;

		public OpenSettingsWindowCommand(IContentChange contentChange)
		{
			this.contentChange = contentChange;
		}

		public bool CanExecute(object parameter)
		{
			return true; 
		}

		public event EventHandler CanExecuteChanged;

		public void Execute(object parameter)
		{
            contentChange.PrimaryViewType = ViewType.SettingsWindow;
            contentChange.SecondaryViewType = ViewType.Default;
		}
	}
}
