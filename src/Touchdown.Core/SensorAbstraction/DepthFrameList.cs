using System;
using System.Collections.ObjectModel;
using Touchdown.SensorAbstraction;
using System.Linq;

namespace Touchdown.Core {
	
	/// <summary>
	/// Collection of depthframes
	/// </summary>
	public class DepthFrameList : Collection<DepthFrame> {
		/// <Docs>
		/// To be added.
		/// </Docs>
		/// <summary>
		/// To be added.
		/// </summary>
		/// <since version='.NET 2.0'>
		/// 
		/// </since>
		/// <param name='index'>
		/// Index.
		/// </param>
		/// <param name='item'>
		/// Item.
		/// </param>
		protected override void InsertItem(int index, DepthFrame item) {
			base.InsertItem (index, item);
		}
		
		/// <summary>
		/// Calculates the average distance of all items (DepthMap).
		/// </summary>
		/// <returns>
		/// The average distance.
		/// </returns>
		public DepthFrame CalculateAverage(){
			if (this.Count > 0){
				long[] sumDistance = new long[this.Items[0].DepthMap.Length];
				short[] avgDepth = new short[sumDistance.Length];	
				
				var distances = this.Select(i=> i.DepthMap);
				// sum of all depth values
				foreach(var distance in distances){
					for(int i = 0; i < distance.Length; ++i){
						sumDistance[i] += distance[i];
					}
				}
				
				// average
				for(int i = 0; i < sumDistance.Length; ++i){
					avgDepth[i] = (short)(sumDistance[i] / this.Count);
				}
				
				DepthFrame result = new DepthFrame(DateTime.Now, null, avgDepth);
				return result;
			} else {
				return null;
			}
		}
	}
}

