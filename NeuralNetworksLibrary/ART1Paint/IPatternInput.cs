using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ART1Paint
{
	interface IPatternInput
	{
		event MouseEventHandler PatternMouseDown;
		event MouseEventHandler PatternMouseUp;
		event MouseEventHandler PatternMouseMove;

		event EventHandler PresentClicked;

		SizeF InputSize { get; }

		void DrawRectangle(PointColour colour, float x, float y, float squareWidth, float squareHeight);
		void Clear(PointColour colour);
		void RefreshView();
	}
}
