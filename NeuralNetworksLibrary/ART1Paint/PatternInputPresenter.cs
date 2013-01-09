using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdaptiveResonanceTheory1;

namespace ART1Paint
{
	class PatternInputPresenter
	{
		private PatternInputProcessor patternInputProcessor;
		private ART1 network;

		public PatternInputPresenter(PatternInputProcessor patternInputProcessor)
		{
			this.patternInputProcessor = patternInputProcessor;

			patternInputProcessor.PatternEntered += new EventHandler(patternInputProcessor_PatternEntered);
		}

		public void Renew(int width, int height, float vigilance)
		{
			network = ART1Builder.Instance.BuildNetwork(width * height, vigilance);
			patternInputProcessor.Renew(width, height);
		}

		public void ClearPattern()
		{
			patternInputProcessor.ClearPattern();
		}

		public void LoadPattern(Pattern pattern)
		{
			patternInputProcessor.LoadPattern(pattern);
		}

		private void patternInputProcessor_PatternEntered(object sender, EventArgs e)
		{
			int cluster = network.Present(patternInputProcessor.Pattern);
			RaisePatternPresented(new PatternEventArgs(cluster, patternInputProcessor.Pattern));
		}

		private void RaisePatternPresented(PatternEventArgs e)
		{
			if (PatternPresented != null)
			{
				PatternPresented(this, e);
			}
		}

		public event EventHandler<PatternEventArgs> PatternPresented;
	}
}
