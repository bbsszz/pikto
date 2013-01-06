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

		private float squareWidth;
		private float squareHeight;

		private Point previousLocation;

		public PatternInputTranslator(IPatternInput patternInput, int sqrHorizontally = 0, int sqrVertically = 0)
		{
			this.patternInput = patternInput;

			SubscribeEvents();

			ComputeSquareSize(sqrHorizontally, sqrVertically);
		}

		public void Colour(PointColour colour, int i, int j)
		{
			patternInput.DrawRectangle(colour, (float)i * squareWidth, (float)j * squareHeight, squareWidth, squareHeight);
		}

		public void Renew(int width, int height)
		{
			ComputeSquareSize(width, height);
			patternInput.Clear(PointColour.Black);
		}

		private void ComputeSquareSize(int sqrHorizontally, int sqrVertically)
		{
			squareWidth = patternInput.InputSize.Width / (float)sqrHorizontally;
			squareHeight = patternInput.InputSize.Height / (float)sqrVertically;
		}

		private void SubscribeEvents()
		{
			patternInput.PatternMouseMove += new MouseEventHandler(patternInput_PatternMouseMove);
			patternInput.PatternMouseDown += new MouseEventHandler(patternInput_PatternMouseDown);
			patternInput.PatternMouseUp += new MouseEventHandler(patternInput_PatternMouseUp);
		}

		private void patternInput_PatternMouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.None)
			{
				Point newLocation = ComputePoint(e.X, e.Y);
				if (newLocation != previousLocation)
				{
					previousLocation = newLocation;
					RaiseEvent(SquareChanged, new SquareEventArgs(e.Button, newLocation.X, newLocation.Y));
				}
			}
		}

		private void patternInput_PatternMouseDown(object sender, MouseEventArgs e)
		{
			Point pp = ComputePoint(e.X, e.Y);
			RaiseEvent(MouseDown, new SquareEventArgs(e.Button, pp.X, pp.Y));
		}

		private void patternInput_PatternMouseUp(object sender, MouseEventArgs e)
		{
			Point pp = ComputePoint(e.X, e.Y);
			RaiseEvent(MouseUp, new SquareEventArgs(e.Button, pp.X, pp.Y));
		}

		private Point ComputePoint(int x, int y)
		{
			int nx = (int)((float)x / squareWidth);
			int ny = (int)((float)y / squareHeight);
			return new Point(nx, ny);
		}

		private void RaiseEvent(EventHandler<SquareEventArgs> evnt, SquareEventArgs e)
		{
			if (evnt != null)
			{
				evnt(this, e);
			}
		}

		public event EventHandler<SquareEventArgs> MouseDown;
		public event EventHandler<SquareEventArgs> MouseUp;
		public event EventHandler<SquareEventArgs> SquareChanged;

		public event EventHandler PresentClicked
		{
			add { patternInput.PresentClicked += value; }
			remove { patternInput.PresentClicked -= value; }
		}
	}
}
