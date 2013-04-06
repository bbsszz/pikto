using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.Utils;

namespace Pikto.ViewModel
{
	class ExaminationPathSourceViewModel : BaseViewModel
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
	}
}
