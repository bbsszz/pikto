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

		public PatternInputPresenter(PatternInputProcessor patternInputProcessor, ART1 network)
		{
			this.patternInputProcessor = patternInputProcessor;
			this.network = network;

			patternInputProcessor.PatternEntered += new EventHandler(patternInputProcessor_PatternEntered);
		}

		void patternInputProcessor_PatternEntered(object sender, EventArgs e)
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
