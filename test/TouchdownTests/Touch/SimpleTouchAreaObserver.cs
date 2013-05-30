using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Touchdown.Core;
using Touchdown.SensorAbstraction;
using NUnit.Framework;
using Rhino.Mocks;

namespace TouchTests.Touch {
	/// <summary>
	/// contains tests for the simple touch area observer.
	/// </summary>
	[TestFixture]
	class SimpleTouchAreaObserverTest {
		
		[Test]
		public void RecognizeSimplePoint(){
			// Arrange
			int[] modelData = {1, 1, 1, 1, 1, 1, 1, 1, 1,
							   1, 1, 1, 1, 1, 1, 1, 1, 1,
							   1, 1, 1, 1, 1, 1, 1, 1, 1,
							   1, 1, 1, 1, 1, 1, 1, 1, 1,
							   1, 1, 1, 1, 1, 1, 1, 1, 1,
							   1, 1, 1, 1, 1, 1, 1, 1, 1};

			DepthFrame backgroundModel = new DepthFrame(DateTime.Now, modelData, 9, 6);

			int[] touchData = {1, 1, 1, 1, 1, 1, 1, 1, 1,
							   1, 1, 3, 3, 1, 1, 1, 1, 1,
							   1, 3, 3, 3, 3, 1, 1, 1, 1,
							   1, 3, 3, 3, 3, 1, 1, 1, 1,
							   1, 1, 3, 3, 1, 1, 1, 1, 1,
							   1, 1, 1, 1, 1, 1, 1, 1, 1};

			DepthFrame touchFrame = new DepthFrame(DateTime.Now, touchData, 9, 6);
			TouchSettings mockSettings = new TouchSettings();
			mockSettings.ContourThreshold = 1;
			mockSettings.MaxContourLength = 12;
			mockSettings.MinContourLength = 7;
			mockSettings.MinDistanceFromBackround = 1;
			mockSettings.MaxDistanceFromBackground = 3;

			var mockSensor = MockRepository.GenerateStub<IKinectSensorProvider>();
			
			SimpleTouchAreaObserver observer = new SimpleTouchAreaObserver(mockSensor, 
																		   mockSettings,
																		   backgroundModel);
			SimpleTouchFrame resultFrame = null;
			observer.TouchFrameReady += (s,e) => resultFrame = e.FrameData;

			// Act
			mockSensor.Raise(x => x.DepthFrameReady += null, mockSensor, new DepthFrameReadyEventArgs(touchFrame));

			// Assert
			Assert.IsNotNull(resultFrame, "Touchframe was not set");
			Assert.AreEqual(1, resultFrame.TouchPoints.Count, "The correct amount of touchpoints was not recognized");
			Assert.AreEqual(2, resultFrame.TouchPoints[0].X, "The middle of the touchpoint was not correctly determined");
			Assert.AreEqual(2, resultFrame.TouchPoints[0].Y, "The middle of the touchpoint was not correctly determined");
		}
	}
}
