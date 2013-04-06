using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.RecognitionPath.DiscretizationModule;
using Pikto.RecognitionPath.Classifier;
using Pikto.RecognitionPath.ClassMapper;

namespace Pikto.RecognitionPath
{
	class RecognitionPath
	{
		private IDiscretizer discretizer;
		private IPictogramClassifier classifier;
		private IClassMapper mapper;

		public RecognitionPath(IDiscretizer discretizer, IPictogramClassifier classifier, IClassMapper mapper)
		{
			this.discretizer = discretizer;
			this.classifier = classifier;
			this.mapper = mapper;
		}

		public int Recognize(IImage image)
		{
			var discretizedImage = discretizer.Discretize(image);
			var activeNeuron = classifier.Classify(discretizedImage);
			var cluster = mapper.Map(activeNeuron);
			return cluster;
		}
	}
}
