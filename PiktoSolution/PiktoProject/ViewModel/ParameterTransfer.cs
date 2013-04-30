using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.View;

namespace Pikto.ViewModel
{
	class ParameterTransfer : IParameterTransfer
	{
		private IDictionary<ViewType, object> parameters;

		public ParameterTransfer()
		{
			this.parameters = new Dictionary<ViewType, object>();
		}

		public object this[ViewType viewType]
		{
			get
			{
				var param = parameters[viewType];
				parameters.Remove(viewType);
				return param;
			}
			set
			{
				parameters.Add(viewType, value);
			}
		}
	}
}
