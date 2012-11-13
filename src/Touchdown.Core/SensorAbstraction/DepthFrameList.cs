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
		public short[] CalculateAverageDistance(){
			if (this.Count > 0){
				long[] sumDistance = new long[this.Items[0].DepthMap.Length];
				short[] avgDistance = new short[sumDistance.Length];	
				
				var distances = this.Select(i=> i.DepthMap);
				// sum of all distances
				foreach(var distance in distances){
					for(int i = 0; i < distance.Length; ++i){
						sumDistance[i] += distance[i];
					}
				}
				
				// average
				for(int i = 0; i < sumDistance.Length; ++i){
					avgDistance[i] = (short)(sumDistance[i] / this.Count);
				}
				
				return avgDistance;
			} else {
				return null;
			}
		}
	}
}

