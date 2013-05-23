using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.Utils;
using System.Windows.Input;

namespace Pikto.ViewModel.WizardViewModel
{
    class CategoriesManagementPathViewModel : WizardBaseViewModel
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

		public CategoriesManagementPathViewModel()
		{
			db = new DatabaseService();
			categories = db.GetAllCategories();
		}

		public double ViewWidth { get { return 420.0; } }
		public double ViewHeight { get { return 300.0; } }
	}
}
