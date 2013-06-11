using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Pikto.Command;
using Pikto.Utils;
using System.Windows;
using Pikto.View;

namespace Pikto.ViewModel.WizardViewModel
{
	class ExaminationPathWizardNavigationViewModel : WizardNavigationViewModel<ExaminationPathWizardViewModel>
	{
		private ICommand startExaminationPathCmd;

		public ExaminationPathWizardNavigationViewModel(
			ExaminationPathWizardViewModel viewModel,
			Action<string> refreshStepAction,
			ICommand cancelCmd, 
			ICommand startExaminationPathCmd)
			: base(viewModel, refreshStepAction, cancelCmd)
		{
			this.startExaminationPathCmd = startExaminationPathCmd;
		}

		protected override void PrepareForwardCmds(IDictionary<string, ICommand> commands)
		{
			commands.Add("", new BasicCommand(p =>
			{
				switch (ViewModel.Action)
				{
					case ChooseEnum.New:
						NextStep("new_path");
						ViewModel.HandleNewPath();
						break;

					case ChooseEnum.Existing:
						NextStep("load_path");
						ViewModel.HandleLoadPath();
						break;
				}
			}));

			commands.Add("new_path", new BasicCommand(p =>
			{
				var param = ViewModel.ChosenExaminationPathFromNewPath;
				startExaminationPathCmd.Execute(param);
			}));

			commands.Add("load_path", new BasicCommand(p =>
			{
				var param = ViewModel.ChosenExaminationPathFromLoadPath;
				if (param == null)
                {
                    PiktoMessageBox pmb = new PiktoMessageBox("Wybierz ścieżkę egzaminacyjną.", MessageBoxButton.OK);
                    pmb.ShowDialog();
					//System.Windows.MessageBox.Show("Wybierz ścieżkę egzaminacyjną.", "Błąd", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
				}
				else
				{
					startExaminationPathCmd.Execute(param);
				}
			}));
		}
	}
}
