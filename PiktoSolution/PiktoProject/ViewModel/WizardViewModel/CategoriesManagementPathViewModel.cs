using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.Utils;
using System.Windows.Input;
using Pikto.Database;
using Pikto.PictoModel;

namespace Pikto.ViewModel.WizardViewModel
{
    class CategoriesManagementPathViewModel : WizardBaseViewModel
	{
		private DatabaseService db;

        //private List<category> categories;

        //public List<string> Categories
        //{
        //    get { return categories.Select(x => x.name.ToString()).ToList(); }
        //}

        public List<CategoryType> CategoriesList { get; private set; }

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

        private ActionEnum editAction;
        public ActionEnum EditAction
        {
            get { return editAction; }
            set
            {
                if (editAction != value)
                {
                    editAction = value;
                    OnPropertyChanged("EditAction");
                }
            }
        }

		public CategoriesManagementPathViewModel()
		{
			db = new DatabaseService();
            SelectedIndex = -1;
		}

		public double ViewWidth { get { return 420.0; } }
		public double ViewHeight { get { return 300.0; } }

        public CategoryType currentCategory { get; private set; }

        public string CategoryName { get; set; }

        public void AddCategory()
        {
            db.AddCategory(CategoryName);
        }

        internal void HandleUpdateCategory()
        {
            CategoriesList = db.GetAllCategories().Select(x => new CategoryType(x.name)).ToList();
            OnPropertyChanged("CategoriesList");
        }

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

        internal void ChooseCategory()
        {
            currentCategory = CategoriesList[SelectedIndex];
            CategoryName = currentCategory.Name;
        }

        internal void EditCategory()
        {
            db.EditCategory((int)(db.GetCategory(currentCategory.Name).id), CategoryName);
            currentCategory = new CategoryType(CategoryName);
        }
        internal void DeleteCategory()
        {
            db.DeleteCategory((int)db.GetCategory(currentCategory.Name).id);
        }
    }
}
