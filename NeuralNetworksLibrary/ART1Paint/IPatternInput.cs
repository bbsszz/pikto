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
		event MouseEventHandler MouseDown;
		event MouseEventHandler MouseUp;
		event MouseEventHandler MouseMove;

		event EventHandler PresentClicked;

		SizeF InputSize { get; }
	}
}
