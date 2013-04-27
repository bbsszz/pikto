﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.Utils;
using System.Windows.Input;
using Pikto.ViewModel.Commands;

namespace Pikto.ViewModel
{
    class CategoriesManagementPathViewModel : WizardBaseViewModel
	{
        private ChooseEnum action;

		public ChooseEnum Action
		{
			get { return action; }
			set
			{
				if (action != value)
				{
					action = value;
					OnPropertyChanged("Action");
				}
			}
		}

        public CategoriesManagementPathViewModel(Action<string> refreshStepAction, ICommand cancelCmd)
			//: base(refreshStepAction, cancelCmd)
		{
			action = ChooseEnum.New;
            
		}

		/*protected override IDictionary<string, ICommand> PrepareForwardCommands()
		{
			IDictionary<string, ICommand> cmds = new Dictionary<string, ICommand>();
			return cmds;
		}

		protected override IDictionary<string, ICommand> PrepareBackwardCommands()
		{
			IDictionary<string, ICommand> cmds = new Dictionary<string, ICommand>();
			return cmds;
		}*/
	}
}
