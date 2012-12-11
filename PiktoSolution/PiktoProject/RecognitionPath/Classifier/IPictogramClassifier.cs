using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pikto.RecognitionPath.Classifier
{
	interface IPictogramClassifier
	{
		int Classify(byte[,] image, bool forceLearning = false);
	}
}
