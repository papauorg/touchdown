using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Touchdown.SensorAbstraction;

namespace Touchdown.Core.PatternRecognition {
	
	/// <summary>
	/// takes two frames and compares their touchpoints. If one frame has more than one touchpoint
	/// </summary>
	public class SimpleTouchFrameComparer {

		#region Members
		private IPointDistanceProvider pointProvider;
		#endregion

		#region Constructors
		/// <summary>
		/// Creates a new instance of the TouchFrameProvider. Using the given point distance
		/// provider.
		/// </summary>
		/// <param name="provider">Point distance provider. Used to calculate the distance between
		/// two <see cref="TouchPoint"/>s</param>
		/// <exception cref="ArgumentNullException">if provider is null</exception>
		public SimpleTouchFrameComparer(IPointDistanceProvider provider){
			if (provider == null) { 
				throw new ArgumentNullException("provider");
			}
			
			this.pointProvider = provider;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Compares two SimpleTouchFrames. 
		/// </summary>
		/// <param name="first">first frame</param>
		/// <param name="other">other frame</param>
		/// <returns>distance between the touch points of the frames or 999 if there are a 
		/// different count of touchpoints per frame.</returns>
		public virtual double Compare(SimpleTouchFrame first, SimpleTouchFrame other){
			double result = 999;

			if (first.TouchPoints.Count == 1 && other.TouchPoints.Count == 1){
				return pointProvider.GetDistance(first.TouchPoints[0], other.TouchPoints[0]);
			}

			return result;
		}
		#endregion
	}
}
