using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.View;

namespace Pikto.ViewModel
{
	interface IParameterTransfer
	{
		object this[ViewType viewType] { get; set; }
	}
}
