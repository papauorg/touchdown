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
	
		[Test]
		public void PatternSaveLoadTest() {
			// arrange
			var pattern = new TouchPattern();
			pattern.Name = "PapauPattern";

			var touchpoints = new List<TouchPoint>();
			touchpoints.Add(new TouchPoint(10,10));
			touchpoints.Add(new TouchPoint(0,0));
			
			var frame = new SimpleTouchFrame(new DateTime(2013,12,31,10,05,02,200), touchpoints, 10, 10);
			pattern.AddFrame(frame);

			touchpoints.Clear();
			touchpoints.Add(new TouchPoint(5,5));
			frame = new SimpleTouchFrame(new DateTime(2013,12,31,10,05,02,230), touchpoints, 10, 10);
			pattern.AddFrame(frame);

			// act
			String serialized = pattern.Save();
			TouchPattern resultPattern = TouchPattern.Load(serialized);

			// assert
			Assert.AreEqual(2, resultPattern.Frames.Count);
			Assert.AreEqual("PapauPattern", resultPattern.Name);

			Assert.AreEqual(2, resultPattern.Frames[0].TouchPoints.Count);
			Assert.AreEqual(10, resultPattern.Frames[0].Width);
			Assert.AreEqual(10, resultPattern.Frames[0].Height);
			Assert.AreEqual(10, resultPattern.Frames[0].TouchPoints[0].X);
			Assert.AreEqual(10, resultPattern.Frames[0].TouchPoints[0].Y);
			Assert.AreEqual(0, resultPattern.Frames[0].TouchPoints[1].X);
			Assert.AreEqual(0, resultPattern.Frames[0].TouchPoints[1].Y);

			Assert.AreEqual(1, resultPattern.Frames[1].TouchPoints.Count);
			Assert.AreEqual(10, resultPattern.Frames[1].Width);
			Assert.AreEqual(10, resultPattern.Frames[1].Height);
			Assert.AreEqual(5, resultPattern.Frames[1].TouchPoints[0].X);
			Assert.AreEqual(5, resultPattern.Frames[1].TouchPoints[0].Y);
		}	
	}
}
