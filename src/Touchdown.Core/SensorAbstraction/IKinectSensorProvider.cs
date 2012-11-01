using System;
using System.Collections.Generic;
using System.Text;

namespace Touch2Much.Kinect SDK Abstraction
{
	public interface IKinectSensorProvider
	{
		virtual event EventHandler<DepthFrameReadyEventArgs> DepthFrameReady;

		event EventHandler<RGBFrameReadyEventArgs> RGBFrameReady;

		void Start();

		void Stop();
	}
}
