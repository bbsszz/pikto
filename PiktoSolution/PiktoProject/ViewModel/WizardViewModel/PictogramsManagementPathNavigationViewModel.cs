using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Pikto.ViewModel.Command;
using Pikto.Utils;

namespace Pikto.ViewModel.WizardViewModel
{
	class PictogramsManagementPathNavigationViewModel : WizardNavigationViewModel<PiktogramsManagementPathViewModel>
	{
		public PictogramsManagementPathNavigationViewModel(PiktogramsManagementPathViewModel viewModel, Action<string> refreshStepAction, ICommand cancelCmd)
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
					{
						NextStep("new_picto");
						break;
					}
					case ChooseEnum.Existing:
					{
						// do nothing yet
						break;
					}
				}
			}));

			cmds.Add("new_picto", new BasicCommand(p =>
			{

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
