using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.Utils;
using System.Windows.Input;

namespace Pikto.ViewModel.WizardViewModel
{
	class ExaminationPathWizardViewModel : WizardBaseViewModel
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

		public override void Reset()
		{
			base.Reset();
			Action = ChooseEnum.New;
		}

		public double ViewWidth { get { return 420.0; } }
		public double ViewHeight { get { return 300.0; } }
	}
}
