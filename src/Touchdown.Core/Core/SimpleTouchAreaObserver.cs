using System;
using System.Collections.Generic;
using System.Text;
using Touchdown.SensorAbstraction;
using System.Linq;

namespace Touchdown.Core {
	/// <summary>
	/// Simple touch area observer. Observes the given toucharea and creates touchframes of it.
	/// </summary>
	public class SimpleTouchAreaObserver : ITouchObserver<Touchdown.SensorAbstraction.SimpleTouchFrame> {
		private IKinectSensorProvider _sensor;
		private TouchSettings _settings;

		private DepthFrameList _backgroundDistances;
		private short[] _avgBackgroundDistance;
		
		/// <summary>
		///  Occurs when touch frame is ready. 
		/// </summary>
		public event EventHandler<FrameReadyEventArgs<SimpleTouchFrame>> TouchFrameReady;

		#region Constructors / Destructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Touchdown.Core.SimpleTouchAreaObserver"/> class.
		/// </summary>
		/// <param name='sensor'>
		/// Sensor.
		/// </param>
		/// <param name='settings'>
		/// Settings.
		/// </param>
		/// <exception cref="ArgumentNullException">if <param name="sensor" />  or <param name="settings"/> is null</exception>
		public SimpleTouchAreaObserver(IKinectSensorProvider sensor, TouchSettings settings) {
			if (sensor == null){
				throw new ArgumentNullException("sensor");
			}
			
			if (settings == null){
				throw new ArgumentNullException("settings");
			}
			
			this._sensor = sensor;
			this._settings = settings;
			
			this._backgroundDistances = new DepthFrameList();
			this._avgBackgroundDistance = null;
			
			// register events needed for recognition of touch frames.
			this._sensor.DepthFrameReady 	+= this.DepthFrameReadyHandler;
			this._sensor.RGBFrameReady		+= this.RGBFrameReadyHandler;
		}
		#endregion
		
		#region Private Methods
		private void DepthFrameReadyHandler(object sender, DepthFrameReadyEventArgs e){
			// gathering depth frames for calculating a background model that is used to recognize changes
			// on it.
			if (this._backgroundDistances.Count < this._settings.FrameCountForAverageBackgroundModel){
				this._backgroundDistances.Add(e.FrameData);
			} else if (this._avgBackgroundDistance != null) {
				this._avgBackgroundDistance = this._backgroundDistances.CalculateAverageDistance();
			} else {
				// recognition of touch points
				if (TouchFrameReady != null){
					// remove the background model from the current frame to have only 
					// objects left that are not part of the background.
					// Those objects should be used for recognition. (could be a hand for example)
					short[] foreGroundDepth = e.FrameData - this._avgBackgroundDistance;
					
				}
			}
		}
		
		private void RGBFrameReadyHandler(object sender, RGBFrameReadyEventArgs e){
			if (TouchFrameReady != null){
				// Nothing to do here for simple touch area observer.
			}
		}
		#endregion
	}
}
