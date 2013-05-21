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
				long[] sumDistance = new long[this.Items[0].DistanceInMM.Length];
				int[] avgDistance = new int[sumDistance.Length];	
				
				var distances = this.Select(i=> i.DistanceInMM);
				// sum of all depth values
				foreach(var distance in distances){
					for(int i = 0; i < distance.Length; ++i){
						sumDistance[i] += distance[i];
					}
				}
				
				// average
				for(int i = 0; i < sumDistance.Length; ++i){
					avgDistance[i] = (int)(sumDistance[i] / this.Count);
				}
				
				DepthFrame result = new DepthFrame(DateTime.Now, avgDistance);
				return result;
			} else {
				return null;
			}
		}
	}
}

