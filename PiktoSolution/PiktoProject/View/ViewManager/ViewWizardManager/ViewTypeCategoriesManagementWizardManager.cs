using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Pikto.View;
using Pikto.ViewModel.WizardViewModel;

namespace Pikto.View.ViewManager.ViewWizardManager
{
    class ViewTypeCategoriesManagementWizardManager : ViewTypeWizardManager<WizardView, CategoriesManagementPathViewModel>
	{
        public ViewTypeCategoriesManagementWizardManager(Action<string> refreshStepAction, ICommand cancelCmd)
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
					var innerView = new ManageCategoriesFirstStepView();
                    innerView.DataContext = NavigationViewModel.ViewModel;
					view.StepContent = innerView;
					view.DataContext = NavigationViewModel;
					return view;
				}

				case "new_piktogram":
				{
					var view = new WizardView();
                    var innerView = new CategoryForm();
                    innerView.DataContext = NavigationViewModel.ViewModel;
                    view.StepContent = innerView;
					view.DataContext = NavigationViewModel;
					return view;
				}

				case "update_piktogram":
				{
					var view = new WizardView();
                    var innerView = new CategoryForm();
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

		protected override WizardNavigationViewModel<CategoriesManagementPathViewModel> CreateViewModel()
		{
			var viewModel = new CategoriesManagementPathViewModel();
			var navigationViewModel = new CategoriesManagementPathNavigationViewModel(viewModel, refreshStepAction, cancelCmd);
			return navigationViewModel;
		}
	}
}
