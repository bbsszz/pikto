using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Pikto.ViewModel.Command;
using Pikto.Utils;

namespace Pikto.ViewModel.WizardViewModel
{
	class ExaminationPathWizardNavigationViewModel : WizardNavigationViewModel<ExaminationPathViewModel>
	{
		public ExaminationPathWizardNavigationViewModel(ExaminationPathViewModel viewModel, Action<string> refreshStepAction, ICommand cancelCmd)
			: base(viewModel, refreshStepAction, cancelCmd)
		{
		}

		protected override IDictionary<string, ICommand> PrepareForwardCmds()
		{
			IDictionary<string, ICommand> cmds = new Dictionary<string, ICommand>();

			cmds.Add("", new BasicCommand(p =>
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

			cmds.Add("new_path", new BasicCommand(p =>
			{
				System.Windows.MessageBox.Show("CREATED");
			}));

			cmds.Add("load_path", new BasicCommand(p =>
			{
				System.Windows.MessageBox.Show("LOADED");
			}));

			return cmds;
		}

		protected override IDictionary<string, ICommand> PrepareBackwardCmds()
		{
			IDictionary<string, ICommand> cmds = new Dictionary<string, ICommand>();
			return cmds;
		}
	}
}
