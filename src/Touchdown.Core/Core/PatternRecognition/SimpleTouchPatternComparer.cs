using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Touchdown.Core;
using Touchdown.SensorAbstraction;
using System.Threading.Tasks;

namespace Touchdown.Core.PatternRecognition {
	/// <summary>
	/// Compares all <see cref="TouchPoint"/>s of all <see cref="SimpleTouchFrame"/>s of two 
	/// <see cref="TouchPattern"/>s.
	/// </summary>
	public class SimpleTouchPatternComparer{
		#region Members
		private SimpleTouchFrameComparer frameComparer;
		#endregion

		#region Constructors
		/// <summary>
		/// Creates a new instance of the simpletouchpattern comparer.
		/// </summary>
		/// <param name="frameComparer"></param>
		public SimpleTouchPatternComparer(SimpleTouchFrameComparer frameComparer){
			this.frameComparer = frameComparer;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Compares the two <see cref="Touchpatterns"/>
		/// </summary>
		/// <param name="original">First pattern</param>
		/// <param name="toCompare">Other pattern</param>
		/// <returns></returns>
		public double Compare(TouchPattern original, TouchPattern toCompare) {
			// normalize patterns and scale the compare frame to the size of the 
			// first frame (not the count of items but the area they cover.
			var first	= original.Normalize();
			var second	= toCompare.Normalize();
			second = second.Scale(first);

			// create distance matrix
			double[,] matrix = new double[first.Frames.Count, second.Frames.Count];

			// calculate distance matrix using DTW
			for (int i = 0; i < first.Frames.Count; ++i) {
				for (int k = 0; k < second.Frames.Count; ++i) { 

					double lowestNeighbour = 0;
					// first run starts with 0
					if (i > 0 || k > 0) { 
						double left			= double.MaxValue;
						double lowerLeft	= double.MaxValue;
						double lower		= double.MaxValue;

						// determine lowest neighbour
						if (i - 1 >= 0) { 
							lower = matrix[i-1,k];
						}
						if (i - 1 >= 0 && k - 1 >= 0) { 
							lowerLeft = matrix[i-1,k-1];
						}
						if (k - 1 >= 0) { 
							left = matrix[i, k-1];
						}

						lowestNeighbour = Math.Min(Math.Min(lower, left), lowerLeft);
					}

					// current calculation includes always the lowest neighbour --> we need to know
					// the total costs and therefore the cheapest path.
					matrix[i,k] = this.frameComparer.Compare(first.Frames[i], second.Frames[k]) + lowestNeighbour;
				}
			}

			// after the matrix is calculated, use the total costs and devide it by the needed steps.
			double neededSteps = Math.Sqrt(Math.Pow(first.Frames.Count, 2)+Math.Pow(second.Frames.Count, 2));
			double result = matrix[first.Frames.Count -1, second.Frames.Count -1] / neededSteps;

			return result;
		}
		#endregion
	}
}
