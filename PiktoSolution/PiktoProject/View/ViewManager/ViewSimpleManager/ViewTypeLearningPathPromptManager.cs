using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.ViewModel.SimpleViewModel;
using System.Windows.Input;

namespace Pikto.View.ViewManager.ViewSimpleManager
{
	class ViewTypeLearningPathPromptManager : ViewTypeSimpleManager<LearningPathPromptView, LearningPathPromptViewModel>
	{
		private ICommand startLearningPathCmd;

		public ViewTypeLearningPathPromptManager(ICommand startLearningPathCmd)
		{
			this.startLearningPathCmd = startLearningPathCmd;
		}

		protected override LearningPathPromptView CreateView()
		{
			var view = new LearningPathPromptView();
			view.DataContext = ViewModel;
			return view;
		}

		protected override LearningPathPromptViewModel CreateViewModel()
		{
			var viewModel = new LearningPathPromptViewModel(startLearningPathCmd);
			return viewModel;
		}
	}
}
