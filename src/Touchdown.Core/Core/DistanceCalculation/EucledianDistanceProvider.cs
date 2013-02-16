using System;
using Touchdown.SensorAbstraction;

namespace Touchdown.Core {
	/// <summary>
	/// Provides logic to calculate the eucledian distance between two touch points. Is equal to the Pythagorean theorem.
	/// http://en.wikipedia.org/wiki/Euclidean_distance
	/// </summary>
	public class EucledianDistanceProvider: IPointDistanceProvider{

		/// <inheritdoc />
		double IPointDistanceProvider.GetDistance(TouchPoint first, TouchPoint second) {
			 double result = double.MaxValue;
			 
			 // get deltas between x and y
			 int a, b;
			 a = first.X - second.X;
			 b = first.Y - second.Y;
			 
			 // apply pytagorean theorem
			 result = Math.Pow(a, 2) + Math.Pow(b, 2);
			 
			 // extract distance
			 result = Math.Sqrt(result);
			 
			 return result;
		}
		
	}
}

