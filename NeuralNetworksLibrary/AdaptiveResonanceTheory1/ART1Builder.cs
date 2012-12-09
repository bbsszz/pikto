using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace AdaptiveResonanceTheory1
{
	public class ART1Builder
	{
		private ART1Builder() { }

		private static ART1Builder instance;

		public ART1Builder Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new ART1Builder();
				}
				return instance;
			}
		}

		public ART1 BuildNetwork(int inputSize, float vigilance = 0.5f, int initialClusterCount = 0)
		{
			Contract.Requires<ArgumentOutOfRangeException>(0 < inputSize, "Size of the input vector must be positive.");
			Contract.Requires<ArgumentOutOfRangeException>(0f < vigilance && vigilance < 1f, "Vigilance parameter must be in (0,1) range.");
			Contract.Requires<ArgumentOutOfRangeException>(0 <= initialClusterCount, "Initial cluster count must be nonnegative.");

			InputNeuronFactory inputNeuronFactory = new InputNeuronFactory();
			InputLayerBuilder inputLayerBuilder = new InputLayerBuilder(inputNeuronFactory);
			InputLayer inputLayer = inputLayerBuilder.Build(inputSize);

			OutputNeuronFactory outputNeuronFactory = new OutputNeuronFactory(inputLayer);
			OutputLayerBuilder outputLayerBuilder = new OutputLayerBuilder(outputNeuronFactory);
			OutputLayer outputLayer = outputLayerBuilder.Build(initialClusterCount);

			OrientingSubsystem orientingSubsystem = new OrientingSubsystem(inputLayer, outputLayer);
			AttentionalSubsystem attentionalSubsystem = new AttentionalSubsystem(orientingSubsystem, inputLayer, outputLayer);

			ART1 network = new ART1(attentionalSubsystem);

			return network;
		}
	}
}
