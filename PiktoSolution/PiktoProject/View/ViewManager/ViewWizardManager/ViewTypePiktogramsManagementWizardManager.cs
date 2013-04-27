using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.ViewModel;
using System.Windows.Input;
using Pikto.ViewModel.WizardViewModel;

namespace Pikto.View.ViewManager.ViewWizardManager
{
    class ViewTypePiktogramsManagementWizardManager : ViewTypeWizardManager<WizardView, PiktogramsManagementPathViewModel>
	{
        public ViewTypePiktogramsManagementWizardManager(Action<string> refreshStepAction, ICommand cancelCmd)
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
					var view = new WizardView();
					var innerView = new ManagePiktogramsFirstStepView();
                    innerView.DataContext = NavigationViewModel.ViewModel;
					view.StepContent = innerView;
					view.DataContext = NavigationViewModel;
					return view;
				}

				case "new_picto":
				{
					var view = new WizardView();
                    var innerView = new PiktogramForm();
                    innerView.DataContext = NavigationViewModel.ViewModel;
                    view.StepContent = innerView;
					view.DataContext = NavigationViewModel;
					return view;
				}

				case "update_picto":
				{
					var view = new WizardView();
                    var innerView = new ManagePiktogramsSecondStepView();
                    innerView.DataContext = NavigationViewModel.ViewModel;
                    view.StepContent = innerView;
					view.DataContext = NavigationViewModel;
					return view;
				}

				default:
				{
					throw new InvalidOperationException("Step not supported in the wizard.");
				}
			}
		}

		protected override WizardNavigationViewModel<PiktogramsManagementPathViewModel> CreateViewModel()
		{
			var viewModel = new PiktogramsManagementPathViewModel();
			var navigationViewModel = new PictogramsManagementPathNavigationViewModel(viewModel, refreshStepAction, cancelCmd);
			return navigationViewModel;
		}
	}
}
