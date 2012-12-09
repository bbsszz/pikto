using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptiveResonanceTheory1
{
	class AttentionalSubsystem
	{
		//private GainController gainController;
		private OrientingSubsystem orientingSubsystem;

		private OutputLayer outputLayer;
		private InputLayer inputLayer;

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
						inputLayer.Activate(data);
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
			//gainController.Data = data;
			orientingSubsystem.InputData = data;
			orientingSubsystem.InputFromInputLayer = inputLayer;
			outputLayer.Initialize();
		}
	}
}
