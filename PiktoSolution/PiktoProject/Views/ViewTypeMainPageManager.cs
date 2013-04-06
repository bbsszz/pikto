using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.ViewModel;
using System.Windows.Input;

namespace Pikto.Views
{
	class ViewTypeMainPageManager : ViewTypeSimpleManager<MainPage>
	{
		private ICommand startLearningPathCmd;
		private ICommand startExaminationPathCmd;
		private ICommand settingsCmd;
		private ICommand exitCmd;

		public ViewTypeMainPageManager(ICommand startLearningPathCmd, ICommand startExaminationPathCmd, ICommand settingsCmd, ICommand exitCmd)
		{
			this.startLearningPathCmd = startLearningPathCmd;
			this.startExaminationPathCmd = startExaminationPathCmd;
			this.settingsCmd = settingsCmd;
			this.exitCmd = exitCmd;
		}

		protected override MainPage Create()
		{
			var mainPage = new MainPage();
			mainPage.DataContext = new MainPageViewModel(startLearningPathCmd, startExaminationPathCmd, settingsCmd, exitCmd);
			return mainPage;
		}
	}
}
