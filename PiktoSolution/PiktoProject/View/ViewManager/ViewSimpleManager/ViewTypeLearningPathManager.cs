using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.ViewModel.SimpleViewModel;
using System.Windows.Input;

namespace Pikto.View.ViewManager.ViewSimpleManager
{
	class ViewTypeLearningPathManager : ViewTypeSimpleManager<LearningPathWindow, LearningPathViewModel>
	{
		protected override LearningPathWindow CreateView()
		{
			var view = new LearningPathWindow();
			view.DataContext = ViewModel;
			return view;
		}

		protected override LearningPathViewModel CreateViewModel()
		{
			var viewModel = new LearningPathViewModel();
			return viewModel;
		}
	}
}
