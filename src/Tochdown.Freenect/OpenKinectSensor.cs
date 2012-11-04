using System;
using System.Collections.Generic;
using System.Text;
using freenect;
using Touchdown.SensorAbstraction;
using System.Threading;

namespace Touchdown.Freenect {
	/// <summary>
	/// Converts the frames from the libfreenect/OpenKinect SDK to frames that the touchdown framework is able to use it.
	/// </summary>
	public class OpenKinectSensor : IKinectSensorProvider {
		private freenect.Kinect _sensor;
		private bool _isRunning;

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
		public OpenKinectSensor(libfreenect.Kinect sensor) {
			if(sensor == null){
				throw new ArgumentNullException("sensor");
			}
			
			// open the sensor if necessary
			_sensor = sensor;
			if (!_sensor.IsOpen){
				_sensor.Open();
			}
			
			// register events so the data can be transformed to touchdown data
			_sensor.VideoCamera.DataReceived += this.HandleRGBDataReceived;
			_sensor.DepthCamera.DataReceived += this.HandleDepthDataReceived;
			
			// initial state of the instance is not running
			_isRunning = false;
		}
		#endregion
		
		#region Public Methods
		/// <summary>
		/// Start this instance.
		/// </summary>
		public void Start() {
			if (!_isRunning){
				// Start cameras
				_sensor.VideoCamera.Start();
				_sensor.DepthCamera.Start();
				
				// Set LED to Yellow
				_sensor.LED.Color = LEDColor.Yellow;
				
				_isRunning = true;
				
				// Start thread that updates the sensor and fires the events
				Thread runner = new Thread(new ThreadStart(delegate() {
					while(this._isRunning){
						_sensor.UpdateStatus();
						_sensor.ProcessEvents();
					}
				}));
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
		/// E.
		/// </param>
		private void HandleDepthDataReceived(object sender, BaseCamera.DataReceivedEventArgs e){
			// if there are any subscribers to the event, convert to touchdown dataformat
			// and fire the touchdown event
			if (this.DepthFrameReady != null){
				DepthFrame result;
				result = this.TransformToRGBFrame((DepthMap)e.Data, e.Timestamp);
			
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
		private DepthFrame TransformToDepthFrame(freenect.DepthMap map) {
			// ToDo: convert datamap to depthframe
			throw new NotImplementedException();
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
		private RGBFrame TransformToRGBFrame(freenect.ImageMap map) {
			// ToDo: convert datamap to rgbframe
			throw new NotImplementedException();
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets a value indicating whether this instance is running.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is running; otherwise, <c>false</c>.
		/// </value>
		public bool IsRunning{
			get{
				return _isRunning;
			}
		}
		#endregion
	}
}
