using System;
using System.Collections.Generic;
using System.Text;

namespace Touchdown.SensorAbstraction {
	
	/// <summary>
	/// 	<para>
	/// 		Basic operations that all Kinect providers must implement in order to use the
	/// 		touchdown framework.
	/// 	</para>
	/// 	<para>
	/// 		Provides an abstraction for the frames of the depth sensor and the rgb sensor 
	/// 		of the Kinect. This way you will be able to use the Microsoft Kinect SDK as well 
	/// 		as the OpenKinect SDK
	/// 	</para>
	/// </summary>
	public interface IKinectSensorProvider {
		
		/// <summary>
		/// Occurs when the depth frame is ready and can be used for further recognition.
		/// </summary>
		event EventHandler<DepthFrameReadyEventArgs> DepthFrameReady;

		/// <summary>
		/// Occurs when the RGB frame is ready and can be used for further recognition.
		/// </summary>
		event EventHandler<RGBFrameReadyEventArgs> RGBFrameReady;

		/// <summary>
		/// Start this instance. From this point on the <see cref="DepthFrameReady"/> and
		/// <see cref="RGBFrameReady"/> events will be fired.
		/// </summary>
		void Start();

		/// <summary>
		/// Stop this instance. the <see cref="DepthFrameReady"/> and
		/// <see cref="RGBFrameReady"/> events will stop being fired.
		/// </summary>
		void Stop();
	}
}
