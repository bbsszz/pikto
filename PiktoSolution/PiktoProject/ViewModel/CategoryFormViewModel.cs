using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.Utils;
using System.Windows.Input;
using Pikto.ViewModel.Commands;

namespace Pikto.ViewModel
{
    class CategoryFormViewModel : WizardBaseViewModel
	{
        private DatabaseService db;

        private List<category> categories;

        public List<string> Categories
        {
            get { return categories.Select(x => x.name.ToString()).ToList(); }
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

        public CategoryFormViewModel(Action<string> newStepAction, ICommand cancelCmd)
			: base(cancelCmd)
		{
			action = ChooseEnum.New;
            db = new DatabaseService();
            categories = db.GetAllCategories();
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
