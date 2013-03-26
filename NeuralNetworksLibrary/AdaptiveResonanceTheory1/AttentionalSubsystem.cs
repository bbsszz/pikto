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

		public IList<Cluster> Clusters { get { return PrepareClusters(); } }

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

		public int ProcessData(IEnumerable<float> data, PresentAction presentAction)
		{
			int winner;
			if (presentAction == PresentAction.ForceLearning || outputLayer.Size == 0)
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
					if (presentAction == PresentAction.Present)
					{
						winner = outputLayer.AddNeuron(data);
					}
					else
					{
						winner = -1;
					}
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

		private IList<Cluster> PrepareClusters()
		{
			var clusters = new List<Cluster>(outputLayer.Size);

			var top = PrepareTopDownConnections();

			int index = 0;
			foreach (var neuron in outputLayer.Neurons)
			{
				var cluster = new Cluster(index, neuron.Connections.Select<Connection, float>(c => c.Weight), top[index]);
				clusters.Add(cluster);
				++index;
			}

			return clusters;
		}

		private IList<IList<float>> PrepareTopDownConnections()
		{
			var clusters = new List<IList<float>>(outputLayer.Size);
			for (int i = 0; i < outputLayer.Size; ++i)
			{
				clusters.Add(new List<float>(inputLayer.Size));
			}

			for (int ni = 0; ni < inputLayer.Size; ++ni)
			{
				var neuron = inputLayer[ni];
				int connI = 0;
				foreach (var conn in neuron.Connections)
				{
					clusters[connI].Add(conn.Weight);
					++connI;
				}
			}

			return clusters;
		}
	}
}
