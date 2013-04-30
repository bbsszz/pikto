using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.ViewModel.SimpleViewModel;
using System.Windows.Input;

namespace Pikto.View.ViewManager.ViewSimpleManager
{
	class ViewTypeMainWindowManager : ViewTypeSimpleManager<MainWindow, MainWindowViewModel>
	{
		private ICommand openLearningPathPromptCmd;
		private ICommand openExaminationPathWizardCmd;
		private ICommand openSettingsCmd;
		private ICommand showAboutCmd;
		private ICommand exitCmd;

		public ViewTypeMainWindowManager(
			ICommand openLearningPathPromptCmd,
			ICommand openExaminationPathWizardCmd,
			ICommand openSettingsCmd,
			ICommand showAboutCmd,
			ICommand exitCmd)
		{
			this.openLearningPathPromptCmd = openLearningPathPromptCmd;
			this.openExaminationPathWizardCmd = openExaminationPathWizardCmd;
			this.openSettingsCmd = openSettingsCmd;
			this.showAboutCmd = showAboutCmd;
			this.exitCmd = exitCmd;
		}

		protected override MainWindow CreateView()
		{
			var mainPage = new MainWindow();
			mainPage.DataContext = ViewModel;
			return mainPage;
		}

		protected override MainWindowViewModel CreateViewModel()
		{
			var viewModel = new MainWindowViewModel(openLearningPathPromptCmd, openExaminationPathWizardCmd, openSettingsCmd, showAboutCmd, exitCmd);
			return viewModel;
		}
	}
}
