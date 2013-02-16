using System;

namespace Touchdown.Core {
	/// <summary>
	/// Provides a method to calculate the distance between two touch points.
	/// </summary>
	public interface IPointDistanceProvider {
		/// <summary>
		/// Gets the distance between two touch points.
		/// </summary>
		/// <returns>
		/// The distance.
		/// </returns>
		/// <param name='first'>
		/// First.
		/// </param>
		/// <param name='second'>
		/// Second.
		/// </param>
		double GetDistance(TouchPoint first, TouchPoint second);
	}
}

