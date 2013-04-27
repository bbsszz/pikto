using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Pikto.ViewModel.Command;

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
				throw new NotImplementedException();
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
