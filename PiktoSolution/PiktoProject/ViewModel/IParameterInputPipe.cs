﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pikto.ViewModel
{
	interface IParameterInputPipe<T> where T : class
	{
		T Parameter { set; }
	}
}
