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

		public ExaminationPathViewModel(Action<string> newStepAction, ICommand cancelCmd)
			: base(new Command(p =>
				{

				}),
				new Command(p =>
				{

				}),
				cancelCmd, null)
		{
		}
	}
}
