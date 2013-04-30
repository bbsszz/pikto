using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.ViewModel.SimpleViewModel;
using System.Windows.Input;

namespace Pikto.View.ViewManager.ViewSimpleManager
{
	class ViewTypeLearningPathManager : ViewTypeSimpleManager<LearningPathPromptView, StartLearningPathViewModel>
	{
		private ICommand startLearningPathCmd;

		public ViewTypeLearningPathManager(ICommand startLearningPathCmd)
		{
			this.startLearningPathCmd = startLearningPathCmd;
		}

		protected override LearningPathPromptView CreateView()
		{
			var view = new LearningPathPromptView();
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
