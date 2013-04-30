using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Pikto.Utils;
using Pikto.Command;

namespace Pikto.ViewModel.WizardViewModel
{
	class PictogramsManagementPathNavigationViewModel : WizardNavigationViewModel<PiktogramsManagementPathViewModel>
	{
		public PictogramsManagementPathNavigationViewModel(PiktogramsManagementPathViewModel viewModel, Action<string> refreshStepAction, ICommand cancelCmd)
			: base(viewModel, refreshStepAction, cancelCmd)
		{
		}
			
		protected override void PrepareForwardCmds(IDictionary<string, ICommand> commands)
		{
			commands.Add("", new BasicCommand(p =>
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

			commands.Add("new_picto", new BasicCommand(p =>
			{

			}));
		}
	}
}
