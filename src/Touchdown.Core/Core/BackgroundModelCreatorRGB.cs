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
	public class BackgroundModelCreatorRGB : BackgroundModelCreator<RGBFrame> {

		#region Members
		private long[] colorSum;
		#endregion

		#region Public Methods
		/// <inheritdoc />
		public override RGBFrame GetBackgroundModel() {
			return this.CalcColorAverage();
		}

		/// <inheritdoc />
		public override void Add(RGBFrame frame) {
			base.Add(frame);

			if (colorSum == null) {
				colorSum = new long[frame.ColorBytes.Length];
			}

			for (int i = 0; i < frame.ColorBytes.Length; ++i) { 
				colorSum[i] += frame.ColorBytes[i];
			}
		}

		/// <inheritdoc />
		public override void Clear() {
			base.Clear();
			colorSum = null;
		}
		#endregion

		#region Protected Methods
		protected override void DoDispose() {
			colorSum = null;
		}
		#endregion

		#region Private Methods
		private RGBFrame CalcColorAverage(){
			if (this.FrameCount > 0){
				byte[] avgDistance = new byte[colorSum.Length];	
				
				// average
				for(int i = 0; i < colorSum.Length; ++i){
					avgDistance[i] = (byte)(colorSum[i] / this.FrameCount);
				}
				
				RGBFrame result = new RGBFrame(DateTime.Now, avgDistance, this.framewidth, this.frameheight);
				return result;
			} else {
				return null;
			}
		}
		#endregion

	}
}
