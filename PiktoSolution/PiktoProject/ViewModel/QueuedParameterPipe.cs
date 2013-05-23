using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pikto.ViewModel
{
	class QueuedParameterPipe<T> : IParameterInputPipe<T>, IParameterOutputPipe<T> where T : class
	{
		private Queue<T> data;

		public QueuedParameterPipe()
		{
			data = new Queue<T>();
		}

		public T Parameter
		{
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException();
				}
				data.Enqueue(value);
			}
			get
			{
				if (data.Count == 0)
				{
					throw new NotSupportedException("No element found.");
				}
				return data.Dequeue();
			}
		}
	}
}
