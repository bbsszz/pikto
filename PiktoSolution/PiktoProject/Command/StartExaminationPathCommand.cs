using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Pikto.View;
using Pikto.ViewModel;

namespace Pikto.Command
{
	class StartExaminationPathCommand : ICommand
	{
		private IContentChange contentChange;
		private IParameterTransfer parameterTransfer;

		public StartExaminationPathCommand(IContentChange contentChange, IParameterTransfer parameterTransfer)
		{
			this.contentChange = contentChange;
			this.parameterTransfer = parameterTransfer;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public event EventHandler CanExecuteChanged;

		public void Execute(object parameter)
		{
			parameterTransfer[ViewType.ExaminationPath] = parameter;
			System.Windows.MessageBox.Show(parameter.ToString());
			contentChange.PrimaryViewType = ViewType.ExaminationPath;
		}
	}
}
