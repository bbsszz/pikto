using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ART1Paint
{
	class PatternInputTranslator
	{
		private IPatternInput patternInput;

		private readonly float squareWidth;
		private readonly float squareHeight;

		public PatternInputTranslator(IPatternInput patternInput, int sqrHorizontally, int sqrVertically)
		{
			this.patternInput = patternInput;

			SubscribeEvents();

			squareWidth = patternInput.InputSize.Width / (float)sqrHorizontally;
			squareHeight = patternInput.InputSize.Height / (float)sqrVertically;
		}

		private void SubscribeEvents()
		{
			patternInput.MouseMove += new MouseEventHandler(patternInput_MouseMove);
			patternInput.MouseDown += new MouseEventHandler(patternInput_MouseDown);
			patternInput.MouseUp += new MouseEventHandler(patternInput_MouseUp);
			patternInput.PresentClicked += new EventHandler(patternInput_PresentClicked);
		}

		private void patternInput_MouseMove(object sender, MouseEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void patternInput_MouseDown(object sender, MouseEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void patternInput_MouseUp(object sender, MouseEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void patternInput_PresentClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private Point ComputePoint(int x, int y)
		{
			return new Point();
		}

		public event EventHandler<SquareEventArgs> MouseDown;
		public event EventHandler<SquareEventArgs> MouseUp;
		public event EventHandler<SquareEventArgs> SquareChanged;
	}
}
