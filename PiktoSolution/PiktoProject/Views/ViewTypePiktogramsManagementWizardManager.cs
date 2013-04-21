using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.ViewModel;
using System.Windows.Input;

namespace Pikto.Views
{
    class ViewTypePiktogramsManagementWizardManager : ViewTypeWizardManager<WizardView>
	{
		private PiktogramsManagementPathViewModel viewModel;

		private Action<string> refreshStepAction;
		private ICommand cancelCmd;

        public ViewTypePiktogramsManagementWizardManager(Action<string> refreshStepAction, ICommand cancelCmd)
		{
			this.refreshStepAction = refreshStepAction;
			this.cancelCmd = cancelCmd;
		}

		protected override WizardView Create(object parameter)
		{
			var step = parameter as string;

			if (viewModel == null)
			{
				viewModel = new PiktogramsManagementPathViewModel(refreshStepAction, cancelCmd);
			}

			switch (step)
			{
				case "":
				case "source":
				{
					var view = new WizardView();
					var innerView = new ManagePiktogramsFirstStep();
					view.StepContent = innerView;
					view.DataContext = viewModel;
					return view;
				}

				case "new_path":
				{
					var view = new WizardView();
					// TODO inner content here
					view.DataContext = viewModel;
					return view;
				}

				case "load_path":
				{
					var view = new WizardView();
					// TODO inner content here
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
