using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace AdaptiveResonanceTheory1
{
	class AttentionalSubsystem
	{
		private OrientingSubsystem orientingSubsystem;

		private InputLayer inputLayer;
		private OutputLayer outputLayer;

		public int InputSize { get { return inputLayer.Size; } }

		public int ClustersCount { get { return outputLayer.Size; } }

		public float Vigilance
		{
			get { return orientingSubsystem.Vigilance; }
			set { orientingSubsystem.Vigilance = value; }
		}

		public AttentionalSubsystem(OrientingSubsystem orientingSubsystem, InputLayer inputLayer, OutputLayer outputLayer)
		{
			this.orientingSubsystem = orientingSubsystem;
			this.inputLayer = inputLayer;
			this.outputLayer = outputLayer;
		}

		public int ProcessData(IEnumerable<float> data, bool forceLearning)
		{
			int winner;
			if (forceLearning || outputLayer.Size == 0)
			{
				// additional conditions could be checked to avoid weird cluster addition
				winner = outputLayer.AddNeuron(data);
			}
			else
			{
				PrepareProcess(data);
				try
				{
					do
					{
						Process(data);
					} while (!orientingSubsystem.CheckResemblance());
					// TODO adjust weights...
					winner = outputLayer.Winner;
				}
				catch (OutOfNeuronsException)
				{
					winner = outputLayer.AddNeuron(data);
				}
			}

			return winner;
		}

		private void PrepareProcess(IEnumerable<float> data)
		{
			orientingSubsystem.InputData = data;
			orientingSubsystem.Initialize();
			outputLayer.Initialize();
		}

		private void Process(IEnumerable<float> data)
		{
			inputLayer.Activate(data);
			outputLayer.Compute();
			inputLayer.Compute(outputLayer.Winner);
		}
	}
}
