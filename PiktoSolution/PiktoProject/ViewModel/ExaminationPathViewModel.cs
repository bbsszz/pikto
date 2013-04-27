using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.Utils;
using Pikto.ViewModel.Commands;
using System.Windows.Input;

namespace Pikto.ViewModel
{
	class ExaminationPathViewModel : WizardBaseViewModel
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

		public ExaminationPathViewModel(Action<string> refreshStepAction, ICommand cancelCmd)
			: base(refreshStepAction, cancelCmd)
		{
			action = ChooseEnum.New;
		}

		protected override IDictionary<string, ICommand> PrepareForwardCommands()
		{
			IDictionary<string, ICommand> cmds = new Dictionary<string, ICommand>();

			cmds.Add("", new Command(p =>
				{
					switch (action)
					{
						case ChooseEnum.New:
							refreshStepAction("new_path");
							break;

						case ChooseEnum.Existing:
							refreshStepAction("load_path");
							break;
					}
				}));

			cmds.Add("new_path", new Command(p =>
				{
					System.Windows.MessageBox.Show("CREATED");
				}));

			cmds.Add("load_path", new Command(p =>
				{
					System.Windows.MessageBox.Show("LOADED");
				}));

			return cmds;
		}

		protected override IDictionary<string, ICommand> PrepareBackwardCommands()
		{
			IDictionary<string, ICommand> cmds = new Dictionary<string, ICommand>();
			return cmds;
		}
	}
}
