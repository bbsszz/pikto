using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.ViewModel.SimpleViewModel;
using System.Windows.Input;

namespace Pikto.View.ViewManager.ViewSimpleManager
{
	class ViewTypeMainPageManager : ViewTypeSimpleManager<MainWindow, MainWindoViewModel>
	{
		private ICommand startLearningPathCmd;
		private ICommand startExaminationPathCmd;
		private ICommand settingsCmd;
		private ICommand aboutCmd;
		private ICommand exitCmd;

		public ViewTypeMainPageManager(ICommand startLearningPathCmd, ICommand startExaminationPathCmd, ICommand settingsCmd, ICommand aboutCmd, ICommand exitCmd)
		{
			this.startLearningPathCmd = startLearningPathCmd;
			this.startExaminationPathCmd = startExaminationPathCmd;
			this.settingsCmd = settingsCmd;
			this.aboutCmd = aboutCmd;
			this.exitCmd = exitCmd;
		}

		protected override MainWindow CreateView()
		{
			var mainPage = new MainWindow();
			mainPage.DataContext = ViewModel;
			return mainPage;
		}

		protected override MainWindoViewModel CreateViewModel()
		{
			var viewModel = new MainWindoViewModel(startLearningPathCmd, startExaminationPathCmd, settingsCmd, aboutCmd, exitCmd);
			return viewModel;
		}
	}
}
