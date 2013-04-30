using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Pikto.Command;

namespace Pikto.ViewModel.WizardViewModel
{
	class CategoriesManagementPathNavigationViewModel : WizardNavigationViewModel<CategoriesManagementPathViewModel>
	{
		public CategoriesManagementPathNavigationViewModel(
			CategoriesManagementPathViewModel viewModel, 
			Action<string> refreshStepAction, 
			ICommand cancelCmd)
			: base(viewModel, refreshStepAction, cancelCmd)
		{
		}

		protected override void PrepareForwardCmds(IDictionary<string, ICommand> commands)
		{
			commands.Add("", new BasicCommand(p =>
			{
				throw new NotImplementedException();
			}));
		}
	}
}
