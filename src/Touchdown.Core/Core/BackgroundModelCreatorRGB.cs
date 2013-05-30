using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Touchdown.Core;
using Touchdown.SensorAbstraction;

namespace Touchdown.Core {
	/// <summary>
	/// creates a background model for colorframes
	/// </summary>
	public class BackgroundModelCreatorRGB : BackgroundModelCreator<RGBFrame>{

		/// <inheritdoc />
		public override RGBFrame GetBackgroundModel() {
			return this.CalcColorAverage();
		}

		private RGBFrame CalcColorAverage(){
			if (_Frames.Count > 0){
				long[] sumDistance = new long[_Frames[0].ColorBytes.Length];
				byte[] avgDistance = new byte[sumDistance.Length];	
				
				var distances = _Frames.Select(i=> i.ColorBytes);
				// sum of all depth values
				foreach(var distance in distances){
					for(int i = 0; i < distance.Length; ++i){
						sumDistance[i] += distance[i];
					}
				}
				
				// average
				for(int i = 0; i < sumDistance.Length; ++i){
					avgDistance[i] = (byte)(sumDistance[i] / _Frames.Count);
				}
				
				RGBFrame result = new RGBFrame(DateTime.Now, avgDistance, _Frames[0].Width, _Frames[0].Height);
				return result;
			} else {
				return null;
			}
		}
	}
}
