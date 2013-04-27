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
				SecondaryViewTypeWithStep(value, "");
			}
		}

		public string WizardStep
		{
			get { return wizardStep; }
		}

		public void SecondaryViewTypeWithStep(ViewType viewType, string step)
		{
			if (step != wizardStep || viewType != secondaryViewType)
			{
				wizardStep = step;
				secondaryViewType = viewType;
				OnPropertyChanged("SecondaryViewType");
				OnPropertyChanged("WizardStep");
			}
		}
	}
}
