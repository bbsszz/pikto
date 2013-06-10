using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.Utils;
using System.Windows.Input;
using Pikto.View;
using Pikto.Database;
using Pikto.PictoModel;

namespace Pikto.ViewModel.WizardViewModel
{
    class PictogramsManagementPathViewModel : WizardBaseViewModel
	{
        //private List<category> categories;

        //public List<string> Categories
        //{
        //    get { return categories.Select(x => x.name.ToString()).ToList(); }
        //}


        public List<CategoryType> CategoriesList { get; private set; }

		private List<piktogramy> piktograms;

		public List<string> Piktograms
		{
			get { return piktograms.Select(x => x.name.ToString()).ToList(); }
		}

        public PictogramType Piktogram { get; private set; }

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

        public int SelectedIndex
        {
            get;
            set;
        }

        public CategoryType ChosenCategory
        {
            get
            {
                if (SelectedIndex >= 0)
                {
                    return CategoriesList[SelectedIndex];
                }
                else
                {
                    return null;
                }
            }
        }

        public string PictoName { get; set; }

		public PictogramsManagementPathViewModel()
		{
			db = new DatabaseService();
            //categories = db.GetAllCategories();
            //piktograms = db.GetAllPiktograms();
            SelectedIndex = -1;
		}

		public override void Loaded()
		{
			base.Loaded();
			Action = ChooseEnum.New;
		}

		public double ViewWidth { get { return 420.0; } }
		public double ViewHeight { get { return 300.0; } }

        internal void HandleCategories()
        {
            CategoriesList = db.GetAllCategories().Select(x => new CategoryType(x.name)).ToList();
            OnPropertyChanged("CategoriesList");
        }

        public void PreparePictogram()
        {
            Piktogram = new PictogramType();
        }

        public void PutName()
        {
            Piktogram.Name = PictoName;
        }

        public void PutCategory()
        {
            Piktogram.Categories = ChosenCategory;
        }
    }
}
