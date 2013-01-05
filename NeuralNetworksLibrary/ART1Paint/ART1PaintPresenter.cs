using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ART1Paint
{
	class ART1PaintPresenter
	{
		private IMainForm mainForm;

		public ART1PaintPresenter(IMainForm mainForm)
		{
			this.mainForm = mainForm;
		}
	}
}
