using System;
using NUnit.Framework;
using Touchdown.Core;

namespace TouchTests {
		[TestFixture()]
		public class DistanceTest {
			/// <summary>
			/// Test that Calculates the eucledian distance.
			/// </param>
			[TestCase(1, 5, 4, 3, 3.6056d)]
			[TestCase(0, 0, 5, 5, 7.0711d)]
			[TestCase(0, -2, -2, -2, 2)]
			public void CalculateEucledianDistance(int firstX, int firstY, int secondX, int secondY, double expected) {
				// Arrange
				IPointDistanceProvider calculator = new EucledianDistanceProvider();
				TouchPoint first = new TouchPoint(firstX, firstY);
				TouchPoint second = new TouchPoint(secondX, secondY);
				
				// Act
				double result = calculator.GetDistance(first, second);
				
				// Assert
				double roundedResult = Math.Round(result, 4);
				Assert.AreEqual(expected, roundedResult, "Eucledian distance failed!");
			}
		}
}

