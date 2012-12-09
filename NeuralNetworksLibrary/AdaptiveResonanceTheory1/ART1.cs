using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace AdaptiveResonanceTheory1
{
	public class ART1
	{
		#region Network components
		private GainController gainController;
		private AttentionalSubsystem attentionalSubsystem;
		private OrientingSubsystem orientingSubsystem;
		#endregion

		#region Network parameters
		private float inputSize;
		private float vigilance;
		#endregion

		public float Vigilance
		{
			get { return vigilance; }
			set
			{
				Contract.Requires<ArgumentOutOfRangeException>(0f < value && value < 1f, "Vigilance parameter must be in (0,1) range.");
				vigilance = value;
			}
		}

		public ART1(int inputSize, float vigilance = 0.5f, int initialClusterCount = 0)
		{
			Contract.Requires<ArgumentOutOfRangeException>(0 < inputSize, "Size of the input vector must be positive.");
			Contract.Requires<ArgumentOutOfRangeException>(0 <= initialClusterCount, "Initial cluster count must be nonnegative.");

			Vigilance = vigilance;
			this.inputSize = inputSize;

			createNetwork(initialClusterCount);
		}

		private void createNetwork(int initialClusterCount)
		{
			throw new NotImplementedException();
		}

		public int Present(float[] input, bool forceLearning = false)
		{
			Contract.Requires<ArgumentException>(input.Length == inputSize, "Length of the input vector is invalid.");
			Contract.Requires<ArgumentException>(Contract.ForAll<float>(input, new Predicate<float>(x => x == 1f || x == 0f)), "Input vector contains invalid elements. Only '0' and '1' are allowed.");

			return processData(input, forceLearning);
		}

		private int processData(float[] input, bool forceLearning)
		{
			return attentionalSubsystem.ProcessData(input, forceLearning);
		}
	}
}
