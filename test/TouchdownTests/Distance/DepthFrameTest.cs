using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Touchdown.Core;
using Touchdown.SensorAbstraction;
using NUnit.Framework;


namespace TouchTests.Distance {
	/// <summary>
	/// Contains tests of the depthframe
	/// </summary>
	[TestFixture]
	public class DepthFrameTest {

		[Test]
		public void DepthFrameSubstractionTest(){
			
			int[] modelData = {1, 1, 1, 1};
			DepthFrame backgroundModel = new DepthFrame(DateTime.Now, modelData);
			int[] frameData = {1, 2, 3, 4};
			DepthFrame touchFrame = new DepthFrame(DateTime.Now, frameData);

			var result = touchFrame - backgroundModel;

			for (int i = 0; i < result.DistanceInMM.Length; ++i) { 
				Assert.AreEqual(frameData[i] -1, result.DistanceInMM[i], "incorrect substraction of framedata");
			}

		}
	}
}
