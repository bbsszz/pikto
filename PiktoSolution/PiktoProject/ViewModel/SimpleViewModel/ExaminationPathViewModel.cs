using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pikto.ViewModel.SimpleViewModel
{
	class ExaminationPathViewModel : BaseViewModel
	{
		private IParameterOutput<string> parameterOutput;

		public ExaminationPathViewModel(IParameterOutput<string> parameterOutput)
		{
			this.parameterOutput = parameterOutput;
		}

		public override void Loaded()
		{
			System.Windows.MessageBox.Show(parameterOutput.Parameter);
		}
	}
}
