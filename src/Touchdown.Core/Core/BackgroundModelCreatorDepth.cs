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
	public class BackgroundModelCreatorDepth : BackgroundModelCreator<DepthFrame> {
		
		#region Members
		private long[] depthSum;
		#endregion

		#region Public Methods
		/// <inheritdoc />
		public override DepthFrame GetBackgroundModel() {
			return this.CalcDepthAverage();
		}
		
		/// <inheritdoc />
		public override void Add(DepthFrame frame) {
			base.Add(frame);

			if (depthSum == null) {
				depthSum = new long[frame.DistanceInMM.Length];
			}

			for (int i = 0; i < frame.DistanceInMM.Length; ++i) { 
				depthSum[i] += frame.DistanceInMM[i];
			}
		}

		/// <inheritdoc />
		public override void Clear() {
			base.Clear();
			depthSum = null;
		}
		#endregion

		#region Protected Methods
		/// <inheritdoc/>
		protected override void DoDispose() {
			depthSum = null;
		}
		#endregion

		#region Private Methods
		private DepthFrame CalcDepthAverage(){
			if (this.FrameCount> 0){
				int[] avgDistance = new int[depthSum.Length];	
				
				// average
				for(int i = 0; i < depthSum.Length; ++i){
					avgDistance[i] = (int)(depthSum[i] / this.FrameCount);
				}
				
				DepthFrame result = new DepthFrame(DateTime.Now, avgDistance, this.framewidth, this.frameheight);
				return result;
			} else {
				return null;
			}
		}
		#endregion
	}
}
