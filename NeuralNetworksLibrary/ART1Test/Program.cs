using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdaptiveResonanceTheory1;

namespace ART1Test
{
	class Program
	{
		static void Main(string[] args)
		{
			ART1 art1 = ART1Builder.Instance.BuildNetwork(5, 0.7f);

			Console.WriteLine(art1.Present(new float[] { 1f, 1f, 1f, 0f, 0f }));
			Console.WriteLine(art1.Present(new float[] { 0f, 0f, 0f, 1f, 1f }));
			Console.WriteLine();
			Console.WriteLine(art1.Present(new float[] { 1f, 1f, 0f, 0f, 0f }));
			Console.WriteLine(art1.Present(new float[] { 0f, 0f, 1f, 1f, 1f }));
			Console.WriteLine();
			Console.WriteLine(art1.Present(new float[] { 0f, 1f, 0f, 0f, 1f }));
			Console.WriteLine(art1.Present(new float[] { 0f, 0f, 0f, 0f, 1f }));
			Console.WriteLine();
			Console.WriteLine(art1.Present(new float[] { 0f, 0f, 0f, 0f, 0f }));
			Console.WriteLine(art1.Present(new float[] { 1f, 1f, 1f, 0f, 1f }));
			Console.WriteLine();
			Console.WriteLine(art1);
			Console.WriteLine();

			//Console.WriteLine("Press any key to start performance test.");
			//Console.ReadKey();
			//DateTime time = DateTime.Now;
			//ART1 art12 = ART1Builder.Instance.BuildNetwork(10000);
			//float[] data2 = new float[10000];
			//data2[100] = 1f;
			//int iter = 1000;
			//for (int i = 0; i < iter; ++i)
			//{
			//    art12.Present(data2);
			//}
			//Console.WriteLine("Finished. Number of iterations: {0}. Test took: {1}.", iter, DateTime.Now.Subtract(time));

			var cls = art1.Clusters;

			ART1 art2 = ART1Builder.Instance.BuildNetwork(cls, 0.7f);

			Console.WriteLine(art2.Present(new float[] { 1f, 1f, 1f, 0f, 0f }));
			Console.WriteLine(art2.Present(new float[] { 0f, 0f, 0f, 1f, 1f }));
			Console.WriteLine();
			Console.WriteLine(art2.Present(new float[] { 1f, 1f, 0f, 0f, 0f }));
			Console.WriteLine(art2.Present(new float[] { 0f, 0f, 1f, 1f, 1f }));
			Console.WriteLine();
			Console.WriteLine(art2.Present(new float[] { 0f, 1f, 0f, 0f, 1f }));
			Console.WriteLine(art2.Present(new float[] { 0f, 0f, 0f, 0f, 1f }));
			Console.WriteLine();
			Console.WriteLine(art2.Present(new float[] { 0f, 0f, 0f, 0f, 0f }));
			Console.WriteLine(art2.Present(new float[] { 1f, 1f, 1f, 0f, 1f }));
			Console.WriteLine();
			Console.WriteLine(art2);
			Console.WriteLine();


			Console.ReadKey();
		}
	}
}
