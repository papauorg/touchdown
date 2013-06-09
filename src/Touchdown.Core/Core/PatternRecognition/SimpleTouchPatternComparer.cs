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

			return 0;
		}
		#endregion
	}
}
