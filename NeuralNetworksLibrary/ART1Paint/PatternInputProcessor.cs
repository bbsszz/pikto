using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ART1Paint
{
	class PatternInputProcessor
	{
		private PatternInputTranslator patternInputTranslator;

		public Pattern Pattern { get; private set; }

		public PatternInputProcessor(PatternInputTranslator patternInputTranslator)
		{
			this.patternInputTranslator = patternInputTranslator;

			SubscribeEvents();
		}

		public void Renew(int width, int height)
		{
			patternInputTranslator.Renew(width, height);
			Pattern = new Pattern(width, height);
		}

		public void ClearPattern()
		{
			Renew(Pattern.Size.Width, Pattern.Size.Height);
		}

		private void SubscribeEvents()
		{
			patternInputTranslator.MouseDown += new EventHandler<SquareEventArgs>(patternInputTranslator_MouseDown);
			patternInputTranslator.MouseUp += new EventHandler<SquareEventArgs>(patternInputTranslator_MouseUp);
			patternInputTranslator.SquareChanged += new EventHandler<SquareEventArgs>(patternInputTranslator_SquareChanged);
			patternInputTranslator.PresentClicked += new EventHandler(patternInputTranslator_PresentClicked);
		}

		private void patternInputTranslator_MouseDown(object sender, SquareEventArgs e)
		{
			Colour(e.Button, e.X, e.Y);	
		}

		private void patternInputTranslator_MouseUp(object sender, SquareEventArgs e)
		{

		}

		private void patternInputTranslator_SquareChanged(object sender, SquareEventArgs e)
		{
			Colour(e.Button, e.X, e.Y);
		}

		private void patternInputTranslator_PresentClicked(object sender, EventArgs e)
		{
			if (PatternEntered != null)
			{
				PatternEntered(this, EventArgs.Empty);
			}
		}

		private void Colour(MouseButtons button, int x, int y)
		{
			switch (button){
				case MouseButtons.Left:
					Pattern[x, y] = PointColour.White;
					patternInputTranslator.Colour(PointColour.White, x, y);
					break;
				case MouseButtons.Right:
					Pattern[x, y] = PointColour.Black;
					patternInputTranslator.Colour(PointColour.Black, x, y);
					break;
				default:
					break;
			}
		}

		public event EventHandler PatternEntered;
	}
}
