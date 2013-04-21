using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Pikto.ViewModel.Commands
{
    class StartCategoriesManagementPathCommand : ICommand
    {
        private IContentChange contentChange;

        public StartCategoriesManagementPathCommand(IContentChange contentChange)
		{
			this.contentChange = contentChange;
		}

        public bool CanExecute(object parameter)
        {
            return false; // not implemented
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
