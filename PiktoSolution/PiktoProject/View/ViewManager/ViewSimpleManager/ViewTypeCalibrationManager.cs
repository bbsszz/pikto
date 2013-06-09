using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.ViewModel.SimpleViewModel;
using System.Windows.Input;

namespace Pikto.View.ViewManager.ViewSimpleManager
{
	class ViewTypeCalibrationManager : ViewTypeSimpleManager<CalibrationToolView, CalibrationToolViewModel>
	{
		protected override CalibrationToolView CreateView()
		{
			var view = new CalibrationToolView();
			view.DataContext = ViewModel;
			return view;
		}

		protected override CalibrationToolViewModel CreateViewModel()
		{
			var viewModel = new CalibrationToolViewModel();
			return viewModel;
		}
	}
}
