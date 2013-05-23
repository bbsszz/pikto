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
		private IParameterInputPipe<string> parameterInputPipe;

		public StartExaminationPathCommand(IContentChange contentChange, IParameterInputPipe<string> parameterInputPipe)
		{
			this.contentChange = contentChange;
			this.parameterInputPipe = parameterInputPipe;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public event EventHandler CanExecuteChanged;

		public void Execute(object parameter)
		{
			parameterInputPipe.Parameter = parameter as string;
			contentChange.PrimaryViewType = ViewType.ExaminationPath;
		}
	}
}
