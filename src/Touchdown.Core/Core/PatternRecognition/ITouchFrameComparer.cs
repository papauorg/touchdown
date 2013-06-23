using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Touchdown.SensorAbstraction;

namespace Touchdown.Core.PatternRecognition {
	/// <summary>
	/// Provides logic to take two frames and compares their touchpoints.
	/// </summary>
	public interface ITouchFrameComparer {
		
		/// <summary>
		/// Compares two SimpleTouchFrames. 
		/// </summary>
		/// <param name="first">first frame</param>
		/// <param name="other">other frame</param>
		/// <returns>result of comparison</returns>
		double Compare(SimpleTouchFrame first, SimpleTouchFrame other);
	}
}
