using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ART1Paint
{
	class SquareEventArgs : EventArgs
	{
		public MouseButtons Button { get; private set; }
		public int X { get; private set; }
		public int Y { get; private set; }

		public SquareEventArgs(MouseButtons button, int x, int y)
		{
			Button = button;
			X = x;
			Y = y;
		}
	}
}
