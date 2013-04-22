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

        public PiktogramsManagementSecondStepViewModel(Action<string> newStepAction, ICommand cancelCmd)
            : base(cancelCmd)
        {
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
