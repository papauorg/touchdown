using System;
using System.Collections.Generic;
using System.Text;

namespace Touchdown.SensorAbstraction {

	/// <summary>
	/// Raised when an DepthFrame from the Kinect sensor is ready.
	/// </summary>
	public class DepthFrameReadyEventArgs : FrameReadyEventArgs<DepthFrame>
	{
		
	}
}
