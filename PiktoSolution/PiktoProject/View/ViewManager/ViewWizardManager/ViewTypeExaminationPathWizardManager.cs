using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.ViewModel;
using System.Windows.Input;
using Pikto.ViewModel.WizardViewModel;
using System.Windows;

namespace Pikto.View.ViewManager.ViewWizardManager
{
	class ViewTypeExaminationPathWizardManager : ViewTypeWizardManager<WizardView, ExaminationPathWizardViewModel>
	{
		private ICommand startExaminationPathCmd;

		public ViewTypeExaminationPathWizardManager(Action<string> refreshStepAction, ICommand cancelCmd, ICommand startExaminationPathCmd)
			: base(refreshStepAction, cancelCmd)
		{
			this.startExaminationPathCmd = startExaminationPathCmd;
		}

		protected override object CreateView(object parameter)
		{
			var step = parameter as string;

			switch (step)
			{
				case "":
				{
					var view = new ExaminationPathWizardSourceView();
					view.DataContext = NavigationViewModel.ViewModel;
					return view;
				}

				case "new_path":
				{
					return "NEW PATH";
				}

				case "load_path":
				{
					var view = new ChooseExaminationPathView();
					view.DataContext = NavigationViewModel.ViewModel;
					return view;
				}

				default:
				{
					throw new InvalidOperationException("Step not supported in the wizard.");
				}
			}
		}

		protected override WizardView CreateWizardView()
		{
			var wizardView = new WizardView();
			wizardView.DataContext = NavigationViewModel;
			return wizardView;
		}

		protected override void ChangeStepContent(object content)
		{
			WizardView.StepContent = content;
		}

		protected override WizardNavigationViewModel<ExaminationPathWizardViewModel> CreateViewModel()
		{
			var chooseExaminationPathViewModel = new ChooseExaminationPathViewModel();
			var manageExaminationPathsViewModel = new ManageExaminationPathsViewModel();
			var viewModel = new ExaminationPathWizardViewModel(manageExaminationPathsViewModel, chooseExaminationPathViewModel);
			var navigationViewModel = new ExaminationPathWizardNavigationViewModel(viewModel, refreshStepAction, cancelCmd, startExaminationPathCmd);
			return navigationViewModel;
		}
	}
}
