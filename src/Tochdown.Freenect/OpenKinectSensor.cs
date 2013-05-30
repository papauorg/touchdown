using System;
using System.Collections.Generic;
using System.Text;
using freenect;
using Touchdown.SensorAbstraction;
using System.Threading;
using log4net;
using System.Runtime.InteropServices;
using System.Linq;

namespace Touchdown.Freenect {
	/// <summary>
	/// Converts the frames from the libfreenect/OpenKinect SDK to frames that the touchdown framework is able to use it.
	/// </summary>
	public class OpenKinectSensor : IKinectSensorProvider {
		private freenect.Kinect _sensor;
		private bool _isRunning;

		private static ILog _log = LogManager.GetLogger(typeof(OpenKinectSensor));
		
		#region Objectevents
		public event EventHandler<DepthFrameReadyEventArgs> DepthFrameReady;
		public event EventHandler<RGBFrameReadyEventArgs> RGBFrameReady;
		#endregion
		
		#region Constructors / Destructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Touchdown.Freenect.OpenKinectSensor"/> class.
		/// </summary>
		/// <param name='sensor'>
		/// Sensor.
		/// </param>
		/// <exception cref="ArgumentNullException">if the sensor is null</exception>
		public OpenKinectSensor(freenect.Kinect sensor) {
			if(sensor == null){
				throw new ArgumentNullException("sensor");
			}

			// open the sensor if necessary
			_sensor = sensor;
			if (!_sensor.IsOpen){
				_log.Debug("Try to open sensor.");
				_sensor.Open();
			}
			
			// register events so the data can be transformed to touchdown data
			_sensor.VideoCamera.DataReceived += this.HandleRGBDataReceived;
			_sensor.DepthCamera.DataReceived += this.HandleDepthDataReceived;
			
			_sensor.LED.Color = LEDColor.Green;
			
			// initial state of the instance is not running
			_isRunning = false;
		}
		#endregion
		
		#region Public Methods
		/// <summary>
		/// Start this instance.
		/// </summary>
		public void Start() {
			_log.Debug("Try to start sensor loop.");
			
			if (!_isRunning){
				// Start cameras
				_sensor.VideoCamera.Start();
				_sensor.DepthCamera.Start();
				
				// Set LED to Yellow
				_sensor.LED.Color = LEDColor.Green;
				
				_isRunning = true;
				
				// Start thread that updates the sensor and fires the events
				Thread runner = new Thread(new ThreadStart(delegate() {
					while(this._isRunning){
						_sensor.UpdateStatus();
						
						freenect.Kinect.ProcessEvents();
					}
				}));
				
				runner.Start();
				
				_log.DebugFormat("Started sensor loop. Thread: [{0}]", runner.ManagedThreadId);
				
			} else {
				_log.Debug("Already running");
			}
			
		}
		
		/// <summary>
		/// Stop this instance.
		/// </summary>
		public void Stop() {
			if (_isRunning){
				// Start cameras
				_sensor.VideoCamera.Stop();
				_sensor.DepthCamera.Stop();
				
				_isRunning = false;
			}
		}
		#endregion
		
		#region Private Methods
		/// <summary>
		/// Handles the event of the kinect sensor where RGB data is received.
		/// </summary>
		/// <param name='sender'>
		/// Sender.
		/// </param>
		/// <param name='e'>
		/// E.
		/// </param>
		private void HandleRGBDataReceived(object sender, BaseCamera.DataReceivedEventArgs e){
			// if there are any subscribers to the event, convert to touchdown dataformat
			// and fire the touchdown event
			if (this.RGBFrameReady != null){
				RGBFrame result;
				result = this.TransformToRGBFrame((ImageMap)e.Data, e.Timestamp);
			
				RGBFrameReadyEventArgs args = new RGBFrameReadyEventArgs(result);
				this.RGBFrameReady(this, args);
			}
		}
		
		/// <summary>
		/// Handles the event of the kinect sensor where Depth data is received.
		/// </summary>
		/// <param name='sender'>
		/// Sender.
		/// </param>
		/// <param name='e'>
		/// event arguments.
		/// </param>
		private void HandleDepthDataReceived(object sender, BaseCamera.DataReceivedEventArgs e){
			// if there are any subscribers to the event, convert to touchdown dataformat
			// and fire the touchdown event
			if (this.DepthFrameReady != null){
				DepthFrame result;
				result = this.TransformToDepthFrame((DepthMap)e.Data, e.Timestamp);
			
				DepthFrameReadyEventArgs args = new DepthFrameReadyEventArgs(result);
				this.DepthFrameReady(this, args);
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
		private DepthFrame TransformToDepthFrame(freenect.DepthMap map, DateTime timeStamp) {
			short[] relativeDepth	= this.CalculateDepthBySensorData(map);
			
			SensorData data = new SensorData(map.Width, map.Height, relativeDepth, map);
			// calculate the depth
			DepthFrame result = new DepthFrame(timeStamp, data);
			
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
		private RGBFrame TransformToRGBFrame(freenect.ImageMap map, DateTime timeStamp) {
			SensorData data = new SensorData(map.Width, map.Height, map.Data.Cast<short>().ToArray(), map);
			RGBFrame result = new RGBFrame(timeStamp, data);
			
			return result;
		}
		
		/// <summary>
		/// Converts the raw imagedata to a depth map that represents the depth by a value between 0 and 2047
		/// </summary>
		/// <returns>
		/// The depth by sensor data.
		/// </returns>
		/// <param name='data'>
		/// Data.
		/// </param>
		private short[] CalculateDepthBySensorData(DepthMap data){
			int newIndex = 0;
			short [] result = new short[data.Height * data.Width];
			int dataBytes = 2;
			
			for (int i = 0; i < data.Height * data.Width * dataBytes; i+=dataBytes){
				// read two bytes (int16) every time and increment the offset by two
				short pixel = Marshal.ReadInt16(data.DataPointer, i);
				result[newIndex] = pixel;
				newIndex++;
			}
			
			return result;
		}
		
		#endregion
		
		#region Properties
		/// <inheritdoc />
		public bool IsRunning{
			get{
				return _isRunning;
			}
		}

		/// <inheritdoc />
		public int ColorFPS{get; private set;}
		
		/// <inheritdoc />
		public int DepthFPS{get; private set;}
		#endregion
	}
}
