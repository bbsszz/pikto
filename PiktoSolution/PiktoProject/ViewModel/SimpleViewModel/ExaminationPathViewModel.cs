using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pikto.ViewModel.SimpleViewModel
{
	class ExaminationPathViewModel : BaseViewModel
	{
		private IParameterTransfer parameterTransfer;

		public ExaminationPathViewModel(IParameterTransfer parameterTransfer)
		{
			this.parameterTransfer = parameterTransfer;
		}
	}
}
