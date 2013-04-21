using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.Utils;
using System.Windows.Input;
using Pikto.ViewModel.Commands;

namespace Pikto.ViewModel
{
    class PiktogramsManagementPathViewModel : WizardBaseViewModel
	{
        private List<piktogramy> piktograms;

        public List<piktogramy> Piktograms
        {
            get { return piktograms; }
            set
            {
                if (piktograms != value)
                {
                    piktograms = value;
                    OnPropertyChanged("Piktograms");
                }
            }
        }

        private DatabaseService db;
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

        public PiktogramsManagementPathViewModel(Action<string> newStepAction, ICommand cancelCmd)
			: base(cancelCmd)
		{
			action = ChooseEnum.New;
            db = new DatabaseService();
            piktograms = db.GetAllPiktograms();
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
