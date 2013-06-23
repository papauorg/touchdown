using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Touchdown.Core.PatternRecognition {
	/// <summary>
	/// Provides logic to compare <see cref="TouchPattern"/>s with each other.
	/// </summary>
	public interface ITouchPatternComparer {
	
		/// <summary>
		/// Compares the two <see cref="Touchpatterns"/>
		/// </summary>
		/// <param name="original">First pattern</param>
		/// <param name="toCompare">Other pattern</param>
		/// <returns>Overall pattern quality</returns>
		double Compare(TouchPattern original, TouchPattern toCompare);
	}
}
