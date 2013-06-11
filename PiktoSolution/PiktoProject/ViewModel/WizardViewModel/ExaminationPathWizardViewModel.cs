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
		private ExaminationPathWizardNewViewModel examinationPathWizardNewViewModel;
		private ExaminationPathWizardChooseViewModel examinationPathWizardChooseViewModel;

		public double ViewWidth { get { return 560.0; } }
		public double ViewHeight { get { return 480.0; } }

		public ExaminationPathWizardViewModel(ExaminationPathWizardNewViewModel examinationPathWizardNewViewModel, ExaminationPathWizardChooseViewModel examinationPathWizardChooseViewModel)
		{
			this.examinationPathWizardNewViewModel = examinationPathWizardNewViewModel;
			this.examinationPathWizardChooseViewModel = examinationPathWizardChooseViewModel;
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
			get { return examinationPathWizardNewViewModel.ChosenExaminationPath; }
		}

		internal void HandleNewPath()
		{
			examinationPathWizardNewViewModel.Load();
		}
		#endregion

		#region Load path
		public IList<ExaminationPathType> ExaminationPaths
		{
			get { return examinationPathWizardChooseViewModel.ExaminationPaths; }
		}

		public int SelectedIndex
		{
			get { return examinationPathWizardChooseViewModel.SelectedIndex; }
			set { examinationPathWizardChooseViewModel.SelectedIndex = value; }
		}

		public ExaminationPathType ChosenExaminationPathFromLoadPath
		{
			get { return examinationPathWizardChooseViewModel.ChosenExaminationPath; }
		}

		internal void HandleLoadPath()
		{
			examinationPathWizardChooseViewModel.Load();
		}
		#endregion
	}
}
