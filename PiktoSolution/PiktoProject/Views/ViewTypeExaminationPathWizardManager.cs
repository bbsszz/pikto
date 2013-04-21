using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.ViewModel;

namespace Pikto.Views
{
	class ViewTypeExaminationPathWizardManager : ViewTypeWizardManager<WizardView>
	{
		private ExaminationPathViewModel viewModel;

		protected override WizardView Create(object parameter)
		{
			var step = parameter as string;

			if (viewModel == null)
			{
				viewModel = new ExaminationPathViewModel();
			}

			switch (step)
			{
				case "":
				case "source":
				{
					var view = new WizardView();
					var innerView = new ExaminationPathSourceView();
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
