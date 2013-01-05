using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ART1Paint
{
	class PatternInputProcessor
	{
		private PatternInputTranslator patternInputTranslator;

		public Pattern Pattern { get; private set; }

		public PatternInputProcessor(PatternInputTranslator patternInputTranslator)
		{
			this.patternInputTranslator = patternInputTranslator;
		}

		public event EventHandler PatternEntered;
	}
}
