using System;
using NUnit.Framework;
using Touchdown.Core;
using Touchdown.SensorAbstraction;

namespace TouchTests {
		[TestFixture()]
		public class ContourTest {
				[Test()]
				public void ContourpointEqualityOperator() {
					// arrange
					ContourPoint first 	= new ContourPoint(1,1);
					ContourPoint second	= new ContourPoint(1,2);
					ContourPoint third  = new ContourPoint(2,1);
					ContourPoint fourth = new ContourPoint(first);
					
					// act / assert
					Assert.AreEqual(false, first == second, "should not be equal");
					Assert.AreEqual(true,  first != second, "should not be equal");
					
					Assert.AreEqual(false, first == third, "should not be equal");
					Assert.AreEqual(true, first != third, "should not be equal");
					
					Assert.AreEqual(false, second == third, "should not be equal");
					Assert.AreEqual(true, second != third, "should not be equal");
					
					Assert.AreEqual(true, first == fourth, "should be equal");
					Assert.AreEqual(false, first != fourth, "should be equal");
				}
				
				[Test()]
				public void FindContoursTest(){
					// arrange
					TouchSettings settings = new TouchSettings();
					settings.MaxContourLength = 25;
					settings.MinContourLength = 4;
			
					int[,] touchedAreas = { {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
											{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0},
											{0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0},
											{0,0,1,1,1,1,1,0,0,1,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0},
											{0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,1,1,1,1,0,0,0,0},
											{0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0},
											{0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0},
											{0,1,1,1,1,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0},
											{0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,0,0,1,1,1,0,0,0,0},
											{0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0},
											{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0},
											{0,0,1,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,1,1,1,0,0,0,0},
											{0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
											{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},};
											
					bool[,] touchAreas2 = new bool[touchedAreas.GetLength(1), touchedAreas.GetLength(0)];
					for (int x = 0; x < touchedAreas.GetLength(1); ++x){
						for (int y = 0; y < touchedAreas.GetLength(0); ++y){
							touchAreas2[x, y] = Convert.ToBoolean(touchedAreas[y,x]);
						}
					}
					
					// act
					var result = Contour.FindContours(touchAreas2, settings);
					
					// assert
					Assert.AreEqual(2, result.Count, "Invalid amount of found contours");
					TouchPoint touchpoint = result[0].GetMiddle();
					Assert.AreEqual(20, touchpoint.X, "wrong middle of touchpoint");
					Assert.AreEqual(2, touchpoint.Y, "wrong middle of touchpoint");
					touchpoint = result[1].GetMiddle();
					Assert.AreEqual(20, touchpoint.X, "wrong middle of touchpoint 2");
					Assert.AreEqual(9, touchpoint.Y, "wrong middle of touchpoint 2");
					result.Clear();
				}
		}
}

