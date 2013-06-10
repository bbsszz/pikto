using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.PictoModel;

namespace Pikto.ViewModel.SimpleViewModel
{
	class ExaminationPathViewModel : BaseViewModel
	{
		private IParameterOutputPipe<ExaminationPathType> parameterOutputPipe;
		private ExaminationPathType currentExaminationPath;

		public ExaminationPathViewModel(IParameterOutputPipe<ExaminationPathType> parameterOutputPipe)
		{
			this.parameterOutputPipe = parameterOutputPipe;
		}

		public override void Loaded()
		{
			currentExaminationPath = parameterOutputPipe.Parameter;
		}
	}
}
