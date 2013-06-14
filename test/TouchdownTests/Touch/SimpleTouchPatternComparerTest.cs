using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Touchdown.Core;
using Touchdown.SensorAbstraction;
using Touchdown.Core.PatternRecognition;

namespace TouchTests.Touch {
	/// <summary>
	/// contains tests for the simple touch pattern comparer.
	/// </summary>
	[TestFixture]
	public class SimpleTouchPatternComparerTest {
	
		[Test]
		public void ComparePattern_SuccessTest(){
			// Arrange
			var patternRecorded = new TouchPattern();
			patternRecorded.Name = "Recorded Pattern";

			var touchPoints = new List<TouchPoint>();
			touchPoints.Add(new TouchPoint(1,1));
			
			var frame = new SimpleTouchFrame(DateTime.Now, touchPoints, 20, 20);
			patternRecorded.AddFrame(frame);

			touchPoints.Clear();
			touchPoints.Add(new TouchPoint(6,6));
			frame = new SimpleTouchFrame(DateTime.Now, touchPoints, 20, 20);
			patternRecorded.AddFrame(frame);

			var originalPattern = new TouchPattern();
			originalPattern.Name = "OriginalPattern";

			touchPoints.Clear();
			touchPoints.Add(new TouchPoint(0,0));
			frame = new SimpleTouchFrame(DateTime.Now, touchPoints, 10, 10);
			originalPattern.AddFrame(frame);
			
			touchPoints.Clear();
			touchPoints.Add(new TouchPoint(10,10));
			frame = new SimpleTouchFrame(DateTime.Now, touchPoints, 10, 10);
			originalPattern.AddFrame(frame);

			// act
			var comparer = new SimpleTouchPatternComparer(new SimpleTouchFrameComparer(new EucledianDistanceProvider()));
			double result = comparer.Compare(originalPattern, patternRecorded);
		
			// assert
			Assert.AreEqual(0, result);
		}
	}
}
