using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.Utils;
using System.Windows.Input;
using Pikto.PictoModel;

namespace Pikto.ViewModel.WizardViewModel
{
	class ExaminationPathWizardViewModel : WizardBaseViewModel
	{
		private ManageExaminationPathsViewModel manageExaminationPathsViewModel;
		private ChooseExaminationPathViewModel chooseExaminationPathViewModel;

		public double ViewWidth { get { return 420.0; } }
		public double ViewHeight { get { return 300.0; } }

		public ExaminationPathWizardViewModel(ManageExaminationPathsViewModel manageExaminationPathsViewModel, ChooseExaminationPathViewModel chooseExaminationPathViewModel)
		{
			this.manageExaminationPathsViewModel = manageExaminationPathsViewModel;
			this.chooseExaminationPathViewModel = chooseExaminationPathViewModel;
		}

		public override void Loaded()
		{
			Action = ChooseEnum.New;
		}

		#region Source
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
		#endregion

		#region New path
		public ExaminationPathType ChosenExaminationPathFromNewPath
		{
			get { return manageExaminationPathsViewModel.ChosenExaminationPath; }
		}

		internal void HandleNewPath()
		{
			manageExaminationPathsViewModel.Load();
		}
		#endregion

		#region Load path
		public IList<ExaminationPathType> ExaminationPaths
		{
			get { return chooseExaminationPathViewModel.ExaminationPaths; }
		}

		public int SelectedIndex
		{
			get { return chooseExaminationPathViewModel.SelectedIndex; }
			set { chooseExaminationPathViewModel.SelectedIndex = value; }
		}

		public ExaminationPathType ChosenExaminationPathFromLoadPath
		{
			get { return chooseExaminationPathViewModel.ChosenExaminationPath; }
		}

		internal void HandleLoadPath()
		{
			chooseExaminationPathViewModel.Load();
		}
		#endregion
	}
}
