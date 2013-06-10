using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Pikto.View;
using Pikto.ViewModel;
using Pikto.PictoModel;

namespace Pikto.Command
{
	class StartExaminationPathCommand : ICommand
	{
		private IContentChange contentChange;
		private IParameterInputPipe<ExaminationPathType> parameterInputPipe;

		public StartExaminationPathCommand(IContentChange contentChange, IParameterInputPipe<ExaminationPathType> parameterInputPipe)
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
			parameterInputPipe.Parameter = parameter as ExaminationPathType;
			contentChange.PrimaryViewType = ViewType.ExaminationPath;
		}
	}
}
