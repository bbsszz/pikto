using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Pikto.ViewModel;

namespace Pikto.Views
{
    class ViewTypeCategoriesManagementWizardManager : ViewTypeWizardManager<WizardView>
	{
		private CategoriesManagementPathViewModel viewModel;

		private ICommand cancelCmd;

        public ViewTypeCategoriesManagementWizardManager(Action<string> refreshStepAction, ICommand cancelCmd)
			: base(refreshStepAction)
		{
			this.cancelCmd = cancelCmd;
		}

		protected override WizardView Create(object parameter)
		{
			var step = parameter as string;

			if (viewModel == null)
			{
				viewModel = new CategoriesManagementPathViewModel(refreshStepAction, cancelCmd);
			}

			switch (step)
			{
				case "":
				case "source":
				{
					var view = new WizardView();
					var innerView = new ManageCategoriesFirstStep();
                    innerView.DataContext = viewModel;
					view.StepContent = innerView;
					view.DataContext = viewModel;
					return view;
				}

				case "new_piktogram":
				{
					var view = new WizardView();
                    var innerView = new CategoryForm();
                    innerView.DataContext = viewModel;
                    view.StepContent = innerView;
					view.DataContext = viewModel;
					return view;
				}

				case "update_piktogram":
				{
					var view = new WizardView();
                    var innerView = new CategoryForm();
                    innerView.DataContext = viewModel;
                    view.StepContent = innerView;
					view.DataContext = viewModel;
					return view;
				}

				default:
				{
					throw new InvalidOperationException("Step not supported in the wizard.");
				}
			}
		}
	}
}
