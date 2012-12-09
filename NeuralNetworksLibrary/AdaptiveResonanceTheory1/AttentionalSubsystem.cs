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

		private float vigilance;

		public float Vigilance
		{
			get { return vigilance; }
			set
			{
				Contract.Requires<ArgumentOutOfRangeException>(0f < value && value < 1f, "Vigilance parameter must be in (0,1) range.");
				vigilance = value;
			}
		}

		public int InputSize { get { return inputLayer.Size; } }

		public AttentionalSubsystem(OrientingSubsystem orientingSubsystem, InputLayer inputLayer, OutputLayer outputLayer)
		{
			this.orientingSubsystem = orientingSubsystem;
			this.inputLayer = inputLayer;
			this.outputLayer = outputLayer;
		}

		public int ProcessData(IEnumerable<float> data, bool forceLearning)
		{
			int winner;
			if (forceLearning)
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
				catch (Exception e)
				{
					winner = outputLayer.AddNeuron(data);
				}
			}

			return winner;
		}

		private void PrepareProcess(IEnumerable<float> data)
		{
			orientingSubsystem.InputData = data;
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
