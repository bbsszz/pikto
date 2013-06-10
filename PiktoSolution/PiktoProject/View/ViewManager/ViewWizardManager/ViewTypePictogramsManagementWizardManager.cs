using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.ViewModel;
using System.Windows.Input;
using Pikto.ViewModel.WizardViewModel;

namespace Pikto.View.ViewManager.ViewWizardManager
{
    class ViewTypePictogramsManagementWizardManager : ViewTypeWizardManager<WizardView, PictogramsManagementPathViewModel>
	{
        ICommand finishCmd;
        public ViewTypePictogramsManagementWizardManager(Action<string> refreshStepAction, ICommand cancelCmd, ICommand finishedCmd)
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
					var view = new ManagePictogramsActionView();
                    view.DataContext = NavigationViewModel.ViewModel;
					return view;
				}

				case "new_picto":
				{
                    var view = new ManagePictogramsNewView();
                    view.DataContext = NavigationViewModel.ViewModel;
					return view;
				}

				case "update_picto":
				{
                    var view = new ManagePictogramsChooseView();
                    view.DataContext = NavigationViewModel.ViewModel;
					return view;
				}

                case "picto_camera":
                {
                    var view = new ManagePictogramsGetPictoFromCameraView();
                    view.DataContext = NavigationViewModel.ViewModel;
                    return view;
                }

                case "picto_medium":
                {
                    var view = new ManagePictogramsChooseMediaView();
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

		protected override WizardNavigationViewModel<PictogramsManagementPathViewModel> CreateViewModel()
		{
			var viewModel = new PictogramsManagementPathViewModel();
            var navigationViewModel = new PictogramsManagementPathNavigationViewModel(viewModel, refreshStepAction, cancelCmd, finishCmd);
			return navigationViewModel;
		}
	}
}
