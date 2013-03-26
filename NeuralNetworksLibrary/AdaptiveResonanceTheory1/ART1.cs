using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace AdaptiveResonanceTheory1
{
	public class ART1
	{
		private AttentionalSubsystem attentionalSubsystem;

		public float Vigilance
		{
			get { return attentionalSubsystem.Vigilance; }
			set { attentionalSubsystem.Vigilance = value; }
		}

		internal ART1(AttentionalSubsystem attentionalSubsystem)
		{
			this.attentionalSubsystem = attentionalSubsystem;
		}

		public int Present(IEnumerable<float> input, PresentAction presentAction = PresentAction.Present)
		{
			//Contract.Requires<ArgumentException>(input.Length == attentionalSubsystem.InputSize, "Length of the input vector is invalid.");
			//Contract.Requires<ArgumentException>(Contract.ForAll<float>(input, new Predicate<float>(x => x == 1f || x == 0f)), "Input vector contains invalid elements. Only '0' and '1' are allowed.");

			return attentionalSubsystem.ProcessData(input, presentAction);
		}

		public IList<Cluster> Clusters { get { return attentionalSubsystem.Clusters; } }

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder("ART1 [");
			builder.Append("Input size: ");
			builder.Append(attentionalSubsystem.InputSize);
			builder.Append(", Clusters: ");
			builder.Append(attentionalSubsystem.ClustersCount);
			builder.Append(", Vigilance: ");
			builder.Append(attentionalSubsystem.Vigilance);
			builder.Append("]");
			return builder.ToString();
		}

	}
}
