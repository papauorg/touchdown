using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

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

		/// <summary>
		/// Adds the area the depth frame should contain.
		/// </summary>
		/// <param name="area">observed area</param>
		void SetArea(Rectangle area);

		/// <summary>
		/// Gets a value indicating whether this instance is running.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is running; otherwise, <c>false</c>.
		/// </value>
		bool IsRunning{get;}

		/// <summary>
		/// returns the current frame rate for <see cref="RGBFrames"/>.
		/// </summary>
		int ColorFPS{get;}

		/// <summary>
		/// returns the current frame rate for <see cref="DepthFrames"/>
		/// </summary>
		int DepthFPS{get;}
	}
}
