using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pikto.PictoModel
{
	class ExaminationPathType
	{
		public string Name { get; private set; }
		public IList<PictogramType> Pictograms { get; private set; }

		public ExaminationPathType(string name, IList<PictogramType> pictograms)
		{
			Name = name;
			Pictograms = pictograms;
		}
	}
}
