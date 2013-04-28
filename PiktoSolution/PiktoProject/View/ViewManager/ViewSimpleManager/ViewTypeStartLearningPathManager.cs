using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.ViewModel.SimpleViewModel;

namespace Pikto.View.ViewManager.ViewSimpleManager
{
	class ViewTypeStartLearningPathManager : ViewTypeSimpleManager<StartLearningPathView, StartLearningPathViewModel>
	{
		protected override StartLearningPathView CreateView()
		{
			var view = new StartLearningPathView();
			view.DataContext = ViewModel;
			return view;
		}

		protected override StartLearningPathViewModel CreateViewModel()
		{
			var viewModel = new StartLearningPathViewModel();
			return viewModel;
		}
	}
}
