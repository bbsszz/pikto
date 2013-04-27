using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.ViewModel;
using System.Windows.Input;

namespace Pikto.Views
{
	class ViewTypeExaminationPathWizardManager : ViewTypeWizardManager<WizardView>
	{
		private WizardNavigationViewModel<ExaminationPathViewModel> navigationViewModel;

		private ICommand cancelCmd;

		public ViewTypeExaminationPathWizardManager(Action<string> refreshStepAction, ICommand cancelCmd)
			: base(refreshStepAction)
		{
			this.cancelCmd = cancelCmd;
		}

		protected override WizardView Create(object parameter)
		{
			var step = parameter as string;

			if (navigationViewModel == null)
			{
				var viewModel = new ExaminationPathViewModel();
				navigationViewModel = new ExaminationPathWizardNavigationViewModel(viewModel, refreshStepAction, cancelCmd);
			}

			switch (step)
			{
				case "":
				{
					// view
					var view = new WizardView();
					var innerView = new ExaminationPathSourceView();
					view.StepContent = innerView;

					// view model
					view.DataContext = navigationViewModel;
					innerView.DataContext = navigationViewModel.ViewModel;

					return view;
				}

				case "new_path":
				{
					var view = new WizardView();
					// TODO inner content here
					view.StepContent = "NEW PATH";
					view.DataContext = navigationViewModel;
					return view;
				}

				case "load_path":
				{
					var view = new WizardView();
					view.StepContent = "LOAD PATH";
					// TODO inner content here
					view.DataContext = navigationViewModel;
					return view;
				}

				default:
				{
					throw new InvalidOperationException("Step not supported in the wizard.");
				}
			}
		}

		/*public override void Reset()
		{
			if (viewModel != null)
			{
				viewModel.Reset();
			}
			if (navigationViewModel != null)
			{
				navigationViewModel.Reset();
			}
		}*/
	}
}
