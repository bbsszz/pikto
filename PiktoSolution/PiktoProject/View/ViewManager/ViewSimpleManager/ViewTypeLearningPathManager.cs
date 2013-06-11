using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.ViewModel.SimpleViewModel;
using System.Windows.Input;
using Pikto.Database;

namespace Pikto.View.ViewManager.ViewSimpleManager
{
	class ViewTypeLearningPathManager : ViewTypeSimpleManager<LearningPathWindow, LearningPathViewModel>
	{
		private DatabaseService databaseService;

		public ViewTypeLearningPathManager(DatabaseService databaseService)
		{
			this.databaseService = databaseService;
		}

		protected override LearningPathWindow CreateView()
		{
			var view = new LearningPathWindow();
			view.DataContext = ViewModel;
			return view;
		}

		protected override LearningPathViewModel CreateViewModel()
		{
			var viewModel = new LearningPathViewModel(databaseService);
			return viewModel;
		}
	}
}
