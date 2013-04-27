using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.ViewModel;
using System.Windows.Input;
using Pikto.ViewModel.WizardViewModel;

namespace Pikto.View.ViewManager.ViewWizardManager
{
	class ViewTypeExaminationPathWizardManager : ViewTypeWizardManager<WizardView, ExaminationPathViewModel>
	{
		public ViewTypeExaminationPathWizardManager(Action<string> refreshStepAction, ICommand cancelCmd)
			: base(refreshStepAction, cancelCmd)
		{
		}

		protected override WizardView CreateView(object parameter)
		{
			var step = parameter as string;

			switch (step)
			{
				case "":
				{
					// view
					var view = new WizardView();
					var innerView = new ExaminationPathSourceView();
					view.StepContent = innerView;

					// view model
					view.DataContext = NavigationViewModel;
					innerView.DataContext = NavigationViewModel.ViewModel;

					return view;
				}

				case "new_path":
				{
					var view = new WizardView();
					// TODO inner content here
					view.StepContent = "NEW PATH";
					view.DataContext = NavigationViewModel;
					return view;
				}

				case "load_path":
				{
					var view = new WizardView();
					view.StepContent = "LOAD PATH";
					// TODO inner content here
					view.DataContext = NavigationViewModel;
					return view;
				}

				default:
				{
					throw new InvalidOperationException("Step not supported in the wizard.");
				}
			}
		}

		protected override WizardNavigationViewModel<ExaminationPathViewModel> CreateViewModel()
		{
			var viewModel = new ExaminationPathViewModel();
			var navigationViewModel = new ExaminationPathWizardNavigationViewModel(viewModel, refreshStepAction, cancelCmd);
			return navigationViewModel;
		}
	}
}
