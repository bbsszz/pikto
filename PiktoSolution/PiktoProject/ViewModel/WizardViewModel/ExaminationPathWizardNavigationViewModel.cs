using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Pikto.Command;
using Pikto.Utils;

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
						break;

					case ChooseEnum.Existing:
						NextStep("load_path");
						break;
				}
			}));

			commands.Add("new_path", new BasicCommand(p =>
			{
				startExaminationPathCmd.Execute("Param from new_path");
			}));

			commands.Add("load_path", new BasicCommand(p =>
			{
				startExaminationPathCmd.Execute("Param from load_path");
			}));
		}
	}
}
