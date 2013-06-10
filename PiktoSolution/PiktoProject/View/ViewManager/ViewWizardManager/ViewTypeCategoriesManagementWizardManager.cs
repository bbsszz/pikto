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
        ICommand finishCmd;
        public ViewTypeCategoriesManagementWizardManager(Action<string> refreshStepAction, ICommand cancelCmd, ICommand finishedCmd)
			: base(refreshStepAction, cancelCmd)
		{
            finishCmd = finishedCmd;
		}

		protected override object CreateView(object parameter)
		{
			var step = parameter as string;

			switch (step)
			{
				case "":
				{
					var view = new ManageCategoriesActionView();
                    view.DataContext = NavigationViewModel.ViewModel;
					return view;
				}

				case "new_category":
				{
					var view = new ManageCategoriesNewView();
                    view.DataContext = NavigationViewModel.ViewModel;
					return view;
				}

				case "update_category":
				{
                    var view = new ManageCategoriesChooseView();
                    view.DataContext = NavigationViewModel.ViewModel;
					return view;
				}


                case "edit_category":
                {
                    var view = new ManageCategoriesEditView();
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

		protected override WizardNavigationViewModel<CategoriesManagementPathViewModel> CreateViewModel()
		{
			var viewModel = new CategoriesManagementPathViewModel();
			var navigationViewModel = new CategoriesManagementPathNavigationViewModel(viewModel, refreshStepAction, cancelCmd, finishCmd);
			return navigationViewModel;
		}
	}
}
