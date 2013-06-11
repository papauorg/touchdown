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
	/// Contains tests for the <see cref="TouchPattern"/> class.
	/// </summary>
	[TestFixture]
	public class TouchPatternTest {
		[Test]
		public void PatternNormalizationTest(){
			// arrange
			var pattern = new TouchPattern();
			var touchpoints = new List<TouchPoint>();
			touchpoints.Add(new TouchPoint(10,10));
			var frame = new SimpleTouchFrame(DateTime.Now, touchpoints, 100, 100);
			pattern.AddFrame(frame);
			touchpoints = new List<TouchPoint>();
			touchpoints.Add(new TouchPoint(25,25));
			frame = new SimpleTouchFrame(DateTime.Now, touchpoints, 100, 100);
			pattern.AddFrame(frame);

			// act 
			var newPattern = pattern.Normalize();

			//assert
			Assert.AreEqual(15, newPattern.Frames[0].Width);
			Assert.AreEqual(15, newPattern.Frames[0].Height);
			Assert.AreEqual(15, newPattern.Frames[1].Width);
			Assert.AreEqual(15, newPattern.Frames[1].Height);

			Assert.AreEqual(0, newPattern.Frames[0].TouchPoints[0].X);
			Assert.AreEqual(0, newPattern.Frames[0].TouchPoints[0].Y);
			Assert.AreEqual(15, newPattern.Frames[1].TouchPoints[0].X);
			Assert.AreEqual(15, newPattern.Frames[1].TouchPoints[0].Y);
		}

		[Test]
		public void PatternScaleTest(){
			var firstPattern = new TouchPattern();
			var touchpoints = new List<TouchPoint>();
			touchpoints.Add(new TouchPoint(10,10));
			touchpoints.Add(new TouchPoint(20,20));
			var frame = new SimpleTouchFrame(DateTime.Now, touchpoints, 100, 100);
			firstPattern.AddFrame(frame);

			var secondPattern = new TouchPattern();
			touchpoints = new List<TouchPoint>();
			touchpoints.Add(new TouchPoint(5,5));
			touchpoints.Add(new TouchPoint(10,10));
			frame = new SimpleTouchFrame(DateTime.Now, touchpoints, 100, 100);
			secondPattern.AddFrame(frame);

			// act
			var shrinkResult = firstPattern.Scale(secondPattern);
			var growResult = secondPattern.Scale(firstPattern);

			// assert
			Assert.AreEqual(5, shrinkResult.Frames[0].TouchPoints[0].X);
			Assert.AreEqual(5, shrinkResult.Frames[0].TouchPoints[0].Y);

			Assert.AreEqual(10, growResult.Frames[0].TouchPoints[0].X);
			Assert.AreEqual(10, growResult.Frames[0].TouchPoints[0].Y);

		}
	}
}
