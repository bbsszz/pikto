using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.PictoModel;

namespace Pikto.ViewModel.WizardViewModel
{
	class ChooseExaminationPathViewModel
	{
		public IList<ExaminationPathType> ExaminationPaths { get; private set; }

		public int SelectedIndex { get; set; }

		public ExaminationPathType ChosenExaminationPath
		{
			get
			{
				if (SelectedIndex >= 0)
				{
					return ExaminationPaths[SelectedIndex];
				}
				else
				{
					return null;
				}
			}
		}

		public ChooseExaminationPathViewModel()
		{
			ExaminationPaths = new List<ExaminationPathType>();
			SelectedIndex = -1;
		}

		public void Load()
		{
			// load from DB
			ExaminationPaths.Add(new ExaminationPathType("Path number 1", null));
			ExaminationPaths.Add(new ExaminationPathType("Animals", null));
		}

	}
}
