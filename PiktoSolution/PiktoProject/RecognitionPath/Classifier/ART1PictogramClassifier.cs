using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdaptiveResonanceTheory1;

namespace Pikto.RecognitionPath.Classifier
{
	class ART1PictogramClassifier : IPictogramClassifier
	{
		private ART1 art1Network;

		public ART1PictogramClassifier(ART1 art1Network)
		{
			this.art1Network = art1Network;
		}

		public int Classify(byte[,] image, bool forceLearning = false)
		{
			return art1Network.Present(image.Cast<float>(), forceLearning);
		}
	}
}
