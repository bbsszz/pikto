using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.Views;
using System.Windows;

namespace Pikto.ViewModel
{
	class AppViewModel : BaseViewModel
	{
		private ViewType primaryViewType;
		private ViewType secondaryViewType;

		public ViewType PrimaryViewType
		{
			get { return primaryViewType; }
			set
			{
				if (primaryViewType != value)
				{
					primaryViewType = value;
					OnPropertyChanged("PrimaryViewType");
				}
			}
		}

		public ViewType SecondaryViewType
		{
			get { return secondaryViewType; }
			set
			{
				if (secondaryViewType != value)
				{
					secondaryViewType = value;
					OnPropertyChanged("SecondaryViewType");
				}
			}
		}
	}
}
