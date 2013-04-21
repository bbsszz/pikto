using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.Views;
using System.Windows;

namespace Pikto.ViewModel
{
	class AppViewModel : BaseViewModel, IContentChange
	{
		private ViewType primaryViewType;
		private ViewType secondaryViewType;
		private string wizardStep;

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
					wizardStep = "";
					secondaryViewType = value;
					OnPropertyChanged("SecondaryViewType");
				}
			}
		}

		public string WizardStep
		{
			get { return wizardStep; }
			set
			{
				if (wizardStep != value)
				{
					wizardStep = value;
					OnPropertyChanged("SecondaryViewType");
				}
			}
		}
	}
}
