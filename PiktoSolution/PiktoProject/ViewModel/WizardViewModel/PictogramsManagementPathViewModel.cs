using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.Utils;
using System.Windows.Input;
using Pikto.View;
using Pikto.Database;

namespace Pikto.ViewModel.WizardViewModel
{
    class PictogramsManagementPathViewModel : WizardBaseViewModel
	{
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

		private DatabaseService db;

		public PictogramsManagementPathViewModel()
		{
			db = new DatabaseService();
			categories = db.GetAllCategories();
			piktograms = db.GetAllPiktograms();
		}

		public override void Loaded()
		{
			base.Loaded();
			Action = ChooseEnum.New;
		}

		public double ViewWidth { get { return 420.0; } }
		public double ViewHeight { get { return 300.0; } }
	}
}
