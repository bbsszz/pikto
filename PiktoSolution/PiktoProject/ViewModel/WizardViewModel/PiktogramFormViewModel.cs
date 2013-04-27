using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.Utils;
using System.Windows.Input;
using Pikto.ViewModel.Command;

namespace Pikto.ViewModel.WizardViewModel
{
    class PiktogramFormViewModel : WizardBaseViewModel
	{
        private DatabaseService db;

        private List<category> categories;

        public List<string> Categories
        {
            get { return categories.Select(x => x.name.ToString()).ToList(); }
        }

        private List<piktogramy> piktograms;

        public List<string> Piktograms
        {
            get { return piktograms.Select(x => x.name.ToString()).ToList(); }
        }

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

        public PiktogramFormViewModel(Action<string> refreshStepAction, ICommand cancelCmd)
			//: base(refreshStepAction, cancelCmd)
		{
			action = ChooseEnum.New;
            db = new DatabaseService();
            categories = db.GetAllCategories();
            piktograms = db.GetAllPiktograms();
		}

		/*protected override IDictionary<string, ICommand> PrepareForwardCommands()
		{
			IDictionary<string, ICommand> cmds = new Dictionary<string, ICommand>();
			return cmds;
		}

		protected override IDictionary<string, ICommand> PrepareBackwardCommands()
		{
			IDictionary<string, ICommand> cmds = new Dictionary<string, ICommand>();
			return cmds;
		}*/
	}
}
