using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Touchdown.Core;
using Touchdown.SensorAbstraction;

namespace TouchTests.Distance {
	/// <summary>
	/// Tests the backgroundmodel creator
	/// </summary>
	[TestFixture]
	class BackgroundModelCreatorTest {
		
		[Test]
		public void GenerateSimpleModelTest(){
			var creator = new BackgroundModelCreator();
			
			int[] FrameDataTwo = {2,2,2,2};
			creator.Add(new DepthFrame(DateTime.Now, FrameDataTwo));
			creator.Add(new DepthFrame(DateTime.Now, FrameDataTwo));
			int[] FrameDataFour = {4,4,4,4};
			creator.Add(new DepthFrame(DateTime.Now, FrameDataFour));
			creator.Add(new DepthFrame(DateTime.Now, FrameDataFour));

			var result = creator.GetBackgroundModel();

			Assert.AreEqual(4, creator.FrameCount, "Amount of frames is not valid");
			for (int i = 0; i < result.DistanceInMM.Length; ++i) { 
				Assert.AreEqual(3, result.DistanceInMM[i], "Average background calculation failed");
			}

			creator.Clear();
		}
	}
}
