using System;
using System.Collections.Generic;
using System.Text;

namespace Touchdown.SensorAbstraction {

	/// <summary>
	/// Raised when an DepthFrame from the Kinect sensor is ready.
	/// </summary>
	public class DepthFrameReadyEventArgs : FrameReadyEventArgs<DepthFrame>
	{
		#region Constructors / Destructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Touchdown.SensorAbstraction.RGBFrameReadyEventArgs"/> class.
		/// </summary>
		/// <param name='frame'>
		/// Frame.
		/// </param>
		/// <exception cref="ArgumentNullException">if frame is null</exception>
		public DepthFrameReadyEventArgs(DepthFrame frame) : base(frame){
			
		}
		#endregion
	}
}
