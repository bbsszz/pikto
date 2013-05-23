using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pikto.ViewModel.SimpleViewModel
{
	class ExaminationPathViewModel : BaseViewModel
	{
		private IParameterOutputPipe<string> parameterOutputPipe;

		public ExaminationPathViewModel(IParameterOutputPipe<string> parameterOutputPipe)
		{
			this.parameterOutputPipe = parameterOutputPipe;
		}

		public override void Loaded()
		{
			System.Windows.MessageBox.Show(parameterOutputPipe.Parameter);
		}
	}
}
