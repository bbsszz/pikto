using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.RecognitionPath;

namespace Pikto.RecognitionPath.DiscretizationModule
{
	public interface IDiscretizer
	{
		byte[,] Discretize(IImage image);
	}
}
