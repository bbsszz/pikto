using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ART1Paint
{
	class ART1PaintPresenter
	{
		private IMainForm mainForm;
		private PatternInputPresenter patternInputPresenter;

		public ART1PaintPresenter(IMainForm mainForm, PatternInputPresenter patternInputPresenter)
		{
			this.mainForm = mainForm;
			this.patternInputPresenter = patternInputPresenter;

			patternInputPresenter.PatternPresented += new EventHandler<PatternEventArgs>(patternInputPresenter_PatternPresented);
			mainForm.NewClicked += new EventHandler(mainForm_NewClicked);
			mainForm.ClearClicked += new EventHandler(mainForm_ClearClicked);
		}

		private void patternInputPresenter_PatternPresented(object sender, PatternEventArgs e)
		{
			mainForm.SelectCluster(e.Cluster, e.Pattern);
		}

		private void mainForm_NewClicked(object sender, EventArgs e)
		{
			patternInputPresenter.Renew(50, 50, mainForm.Vigilance);
			mainForm.ClearRememberedPatterns();
		}

		private void mainForm_ClearClicked(object sender, EventArgs e)
		{
			patternInputPresenter.ClearPattern();
		}
	}
}
