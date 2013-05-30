using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Touchdown.Core;
using Touchdown.SensorAbstraction;

namespace Touchdown.Core {
	/// <summary>
	/// creates a depth background model depending on the frames that were given.
	/// </summary>
	public class BackgroundModelCreatorDepth : BackgroundModelCreator<DepthFrame>{

		/// <inheritdoc />
		public override DepthFrame GetBackgroundModel() {
			return this.CalcDepthAverage();
		}

		private DepthFrame CalcDepthAverage(){
			if (_Frames.Count > 0){
				long[] sumDistance = new long[_Frames[0].DistanceInMM.Length];
				int[] avgDistance = new int[sumDistance.Length];	
				
				var distances = _Frames.Select(i=> i.DistanceInMM);
				// sum of all depth values
				foreach(var distance in distances){
					for(int i = 0; i < distance.Length; ++i){
						sumDistance[i] += distance[i];
					}
				}
				
				// average
				for(int i = 0; i < sumDistance.Length; ++i){
					avgDistance[i] = (int)(sumDistance[i] / _Frames.Count);
				}
				
				DepthFrame result = new DepthFrame(DateTime.Now, avgDistance, _Frames[0].Width, _Frames[0].Height);
				return result;
			} else {
				return null;
			}
		}
	}
}
