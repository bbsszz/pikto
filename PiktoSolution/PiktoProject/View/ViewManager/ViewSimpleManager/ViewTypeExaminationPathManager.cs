using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.ViewModel.SimpleViewModel;
using Pikto.ViewModel;
using Pikto.PictoModel;

namespace Pikto.View.ViewManager.ViewSimpleManager
{
	class ViewTypeExaminationPathManager : ViewTypeSimpleManager<ExaminationPathWindow, ExaminationPathViewModel>
	{
		private IParameterOutputPipe<ExaminationPathType> parameterOutput;

		public ViewTypeExaminationPathManager(IParameterOutputPipe<ExaminationPathType> parameterOutput)
		{
			this.parameterOutput = parameterOutput;
		}

		protected override ExaminationPathWindow CreateView()
		{
			var view = new ExaminationPathWindow();
			view.DataContext = ViewModel;
			return view;
		}

		protected override ExaminationPathViewModel CreateViewModel()
		{
			var viewModel = new ExaminationPathViewModel(parameterOutput);
			return viewModel;
		}
	}
}
