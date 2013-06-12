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
        private ICommand returnToMainWindowCmd;


        public ViewTypeLearningPathManager(DatabaseService databaseService, ICommand returnToMainWindowCmd)
		{
			this.databaseService = databaseService;
            this.returnToMainWindowCmd = returnToMainWindowCmd;
		}

		protected override LearningPathWindow CreateView()
		{
			var view = new LearningPathWindow();
			view.DataContext = ViewModel;
			return view;
		}

		protected override LearningPathViewModel CreateViewModel()
		{
			var viewModel = new LearningPathViewModel(databaseService, returnToMainWindowCmd);
			return viewModel;
		}
	}
}
