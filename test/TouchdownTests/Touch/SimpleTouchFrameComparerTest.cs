using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Touchdown.Core;
using Touchdown.Core.PatternRecognition;
using Touchdown.SensorAbstraction;
using NUnit.Framework;

namespace TouchTests.Touch {
	/// <summary>
	/// Contains tests for the simpletouchframe comparer
	/// </summary>
	public class SimpleTouchFrameComparerTest {

		[TestCase(5, 5, 6, 6, 1.41)]
		[TestCase(5, 5, 5, 6, 1)]
		[TestCase(5, 5, 5, 5, 0)]
		public void FrameCompareTest(int firstX, int firstY, int secondX, int secondY, double expect){
			var touchPoints = new List<TouchPoint>();
			touchPoints.Add(new TouchPoint(firstX,firstY));
			var frameOrig = new SimpleTouchFrame(DateTime.Now, touchPoints, 10, 10);

			var otherPoints = new List<TouchPoint>();
			otherPoints.Add(new TouchPoint(secondX, secondY));
			var secondFrame = new SimpleTouchFrame(DateTime.Now, otherPoints, 10,10);

			var comparer = new SimpleTouchFrameComparer(new EucledianDistanceProvider());
			var result = comparer.Compare(frameOrig, secondFrame);

			Assert.AreEqual(expect, result);
		}
	}
}
