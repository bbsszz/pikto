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
			: base(cancelCmd)
		{
			action = ChooseEnum.New;
		}

		protected override ICommand PrepareForwardCommand()
		{
			return new Command(p =>
			{
				switch (action)
				{
					case ChooseEnum.New:

						break;

					case ChooseEnum.Existing:

						break;
				}
			});
		}

		protected override ICommand PrepareBackwardCommand()
		{
			return new Command(p =>
			{

			});
		}
	}
}
