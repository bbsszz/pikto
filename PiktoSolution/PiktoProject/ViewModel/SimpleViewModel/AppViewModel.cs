using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.View;
using System.Windows;

namespace Pikto.ViewModel.SimpleViewModel
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
					secondaryViewType = ViewType.Default;
					OnPropertyChanged("PrimaryViewType");
					OnPropertyChanged("SecondaryViewType");
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
				secondaryViewType = viewType;
				wizardStep = step;
				OnPropertyChanged("SecondaryViewType");
				OnPropertyChanged("WizardStep");
			}
		}
	}
}
