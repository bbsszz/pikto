using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Pikto.ViewModel.Commands;
using Pikto.Utils;

namespace Pikto.ViewModel
{
    class PiktogramsManagementSecondStepViewModel : WizardBaseViewModel
    {
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

        private DatabaseService db;

        public PiktogramsManagementSecondStepViewModel(Action<string> refreshStepAction, ICommand cancelCmd)
            //: base(refreshStepAction, cancelCmd)
        {
            db = new DatabaseService();
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
