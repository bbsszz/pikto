using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pikto.ViewModel
{
	class SingleParameterPipe<T> : IParameterInputPipe<T>, IParameterOutputPipe<T> where T : class
	{
		private T parameter;

		public SingleParameterPipe()
		{
			parameter = null;
		}

		public T Parameter
		{
			set
			{
				if (parameter != null)
				{
					throw new FieldAccessException("Prior parameter not consumed.");
				}
				parameter = value;
			}
			get
			{
				if (parameter == null)
				{
					throw new FieldAccessException("No parameter found.");
				}
				var p = parameter;
				parameter = null;
				return p;
			}
		}
	}
}
