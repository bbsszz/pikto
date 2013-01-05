using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ART1Paint
{
	class Pattern : IEnumerable<float>
	{
		public IEnumerator<float> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}
