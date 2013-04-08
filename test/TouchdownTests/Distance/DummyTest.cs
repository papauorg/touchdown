using System;
using NUnit.Framework;

namespace TouchTests {
		[TestFixture()]
		public class DummyTest {
			private enum ContourDirection {
				North = 0,
				East  = 1, 
				South = 2,
				West  = 3
			}
		
				[Test()]
				public void TestCase() {
					ContourDirection dir;
					dir = ContourDirection.North;
					
					for (int i = 0; i < 10; ++i){
						dir = (ContourDirection)(((int)dir + 1) % 4);
					}
					
				}
		}
}

