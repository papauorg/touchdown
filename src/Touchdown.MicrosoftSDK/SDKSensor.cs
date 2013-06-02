﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Touchdown.SensorAbstraction;
using Touchdown.Core;
using log4net;
using Microsoft.Kinect;

namespace Touchdown.MicrosoftSDK {
	/// <summary>
	/// Converts frames from the Microsoft Kinect SDK to frames that the TouchRecognizer is able to use.
	/// </summary>
	public class SDKSensor : Touchdown.SensorAbstraction.IKinectSensorProvider {

		#region Members
		private Microsoft.Kinect.KinectSensor _sensor;
		private short[] temporaryDepthData;
		private int[] convertedDepthData;
		private byte[] temporaryRGBData;
		private static ILog _log = LogManager.GetLogger(typeof(SDKSensor));

		// framecount
		private int rgbFrameCount;
		private DateTime lastRgbFrameCount;
		private int depthFrameCount;
		private DateTime lastDepthFrameCount;
		#endregion

		#region Objectevents
		/// <summary>
		/// Fires when a depthframe is ready in the stream
		/// </summary>
		public event EventHandler<DepthFrameReadyEventArgs> DepthFrameReady;

		/// <summary>
		/// Fires when an color image frame is ready in the stream.
		/// </summary>
		public event EventHandler<RGBFrameReadyEventArgs> RGBFrameReady;
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="SDKSensor"/> class.
		/// </summary>
		/// <param name='sensor'>
		/// Sensor.
		/// </param>
		/// <exception cref="ArgumentNullException">if the sensor is null</exception>
		public SDKSensor(Microsoft.Kinect.KinectSensor sensor){
			if(sensor == null){
				throw new ArgumentNullException("sensor");
			}

			this._sensor = sensor;
			this._sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
			this._sensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
			this._sensor.ColorFrameReady += HandleRGBDataReceived;
			this._sensor.DepthFrameReady += HandleDepthDataReceived;

			this.ColorFPS = 0;
			this.DepthFPS = 0;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// starts the sensor loop
		/// </summary>
		void SensorAbstraction.IKinectSensorProvider.Start() {
			_sensor.Start();
			this.lastRgbFrameCount = DateTime.Now;
			this.lastDepthFrameCount = DateTime.Now;
			this.rgbFrameCount = 0;
			this.depthFrameCount = 0;
			this.DepthFPS = 0;
			this.ColorFPS = 0;
		}

		/// <summary>
		/// stops the sensor loop
		/// </summary>
		void SensorAbstraction.IKinectSensorProvider.Stop() {
			_sensor.Stop();
			this.rgbFrameCount = 0;
			this.depthFrameCount = 0;
			this.DepthFPS = 0;
			this.ColorFPS = 0;
		}

		#endregion

		#region Private Methods
		/// <summary>
		/// Handles the event of the kinect sensor where RGB data is received.
		/// </summary>
		/// <param name='sender'>
		/// sender.
		/// </param>
		/// <param name='e'>
		/// event arguments.
		/// </param>
		private void HandleRGBDataReceived(object sender, ColorImageFrameReadyEventArgs e){
			if (this.RGBFrameReady != null) { 
				using (var frame = e.OpenColorImageFrame()) { 
					if (frame != null){
						using (RGBFrame result = this.TransformToRGBFrame(frame)) { 

							if (result != null) { 
								var args = new RGBFrameReadyEventArgs(result);
								this.RGBFrameReady(this, args);
							}	
						}
					}
				}
			}
			
			this.rgbFrameCount++;
			if (DateTime.Now.Subtract(this.lastRgbFrameCount).TotalSeconds >= 1) { 
				this.ColorFPS = this.rgbFrameCount;
				this.lastRgbFrameCount = DateTime.Now;
				this.rgbFrameCount = 0;
			}

		}

		/// <summary>
		/// Handles the event of the kinect sensor where Depth data is received.
		/// </summary>
		/// <param name='sender'>
		/// Sender.
		/// </param>
		/// <param name='e'>
		/// event arguements.
		/// </param>
		private void HandleDepthDataReceived(object sender, DepthImageFrameReadyEventArgs e){
			if (this.DepthFrameReady != null) {
				using (var frame = e.OpenDepthImageFrame()) {
					if (frame != null) {
						using (DepthFrame result = this.TransformToDepthFrame(frame)) {
							if (result != null) { 
								var args = new DepthFrameReadyEventArgs(result);
								this.DepthFrameReady(this, args);
							}
						}
					}
				}
			}
			
			this.depthFrameCount++;
			if (DateTime.Now.Subtract(this.lastDepthFrameCount).TotalSeconds >= 1) { 
				this.DepthFPS = this.depthFrameCount;
				this.lastDepthFrameCount = DateTime.Now;
				this.depthFrameCount = 0;
			}
		}

		/// <summary>
		/// Transforms an DepthMap to a touchdown depth frame.
		/// </summary>
		/// <returns>
		/// The to depth frame.
		/// </returns>
		/// <param name='map'>
		/// Map.
		/// </param>
		private DepthFrame TransformToDepthFrame(DepthImageFrame img) {
			if (this.temporaryDepthData == null) { 
				this.temporaryDepthData = new short[img.PixelDataLength];
				this.convertedDepthData = new int[img.PixelDataLength];
			}
			img.CopyPixelDataTo(this.temporaryDepthData);

			// convert to distance in mm
			for (int i = 0; i < this.temporaryDepthData.Length; ++i) { 
				this.convertedDepthData[i] = this.temporaryDepthData[i] >> DepthImageFrame.PlayerIndexBitmaskWidth;
			}

			// calculate the depth
			DepthFrame result = new DepthFrame(new DateTime(img.Timestamp), 
											   convertedDepthData, 
											   img.Width, 
											   img.Height);
			
			return result;
		}

		/// <summary>
		/// Transforms the ImageMap to a Touchdown RGB frame.
		/// </summary>
		/// <returns>
		/// The to RGB frame.
		/// </returns>
		/// <param name='map'>
		/// Map.
		/// </param>
		private RGBFrame TransformToRGBFrame(ColorImageFrame img) {
			if (this.temporaryRGBData == null) { 
				this.temporaryRGBData = new byte[img.PixelDataLength];
			}
			img.CopyPixelDataTo(this.temporaryRGBData);

			RGBFrame result = new RGBFrame(new DateTime(img.Timestamp), 
											temporaryRGBData, 
											img.Width, 
											img.Height);
			
			return result;
		}
		#endregion

		#region Properties
		/// <inheritdoc />
		public bool IsRunning{get{return _sensor.IsRunning;}}

		/// <inheritdoc />
		public int ColorFPS{get; private set;}
		
		/// <inheritdoc />
		public int DepthFPS{get; private set;}

		#endregion
	}
}
