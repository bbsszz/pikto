using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.ViewModel.SimpleViewModel;
using System.Windows.Input;

namespace Pikto.View.ViewManager.ViewSimpleManager
{
	class ViewTypeStartLearningPathManager : ViewTypeSimpleManager<StartLearningPathView, StartLearningPathViewModel>
	{
		private ICommand startLearningPathCmd;

		public ViewTypeStartLearningPathManager(ICommand startLearningPathCmd)
		{
			this.startLearningPathCmd = startLearningPathCmd;
		}

		protected override StartLearningPathView CreateView()
		{
			var view = new StartLearningPathView();
			view.DataContext = ViewModel;
			return view;
		}

		protected override StartLearningPathViewModel CreateViewModel()
		{
			var viewModel = new StartLearningPathViewModel(startLearningPathCmd);
			return viewModel;
		}
	}
}
