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
		private DepthFrame _avgBackground;
		
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
			this._avgBackground = null;
			
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
			} else if (this._avgBackground == null) {
				this._avgBackground = this._backgroundDistances.CalculateAverage();
			} else {
				// recognition of touch points
				if (TouchFrameReady != null){
					/* remove the background model from the current frame to have only 
					   objects left that are not part of the background.
					   Those objects should be used for recognition. (could be a hand for example) */
					short[] foreGroundDepth = e.FrameData - this._avgBackground;
					
					/*  apply the threshold of the settings to recognize all points that 
					 *  are close enough to the background */
					 short[] rawPoints = 
					 this.ApplyThreshold(foreGroundDepth, 
					 					 this._settings.MinDistanceFromBackround, 
					 					 this._settings.MaxDistanceFromBackground);
					 					 
					 /* the extracted background contains now only the parts of the image where something is different
			 * 		  *	than the background. In this case usually fingers. 
			 		  *	There are very "blury" areas where the finger are located. Extract the touchpoints of it. */
			 		  List<TouchPoint> touchPoints = this.ExtractTouchPoints(rawPoints);
			 		  
			 		  new SimpleTouchFrame(e.FrameData.FrameTime, e.FrameData.Data);
			 		  
				}
			}
		}
		
		private void RGBFrameReadyHandler(object sender, RGBFrameReadyEventArgs e){
			if (TouchFrameReady != null){
				// Nothing to do here for simple touch area observer.
			}
		}

		/// <summary>
		/// Extracts the touch points from the raw, blurry points extracted from the backgroundmodel and the frames.
		/// </summary>
		/// <returns>
		/// The touch points.
		/// </returns>
		/// <param name='rawPoints'>
		/// Raw points.
		/// </param>
		List<TouchPoint> ExtractTouchPoints(short[] rawPoints) {
			throw new NotImplementedException ();
		}
		
		/// <summary>
		/// sets all items of the array to -1 that are smaller than <param cref="minDistance" /> 
		/// and greater than <param name="maxDistance" />
		/// </summary>
		/// <returns>
		/// The threshold.
		/// </returns>
		/// <param name='backgroundExtracted'>
		/// Background extracted.
		/// </param>
		/// <param name='minDistance'>
		/// Minimum distance.
		/// </param>
		/// <param name='maxDistance'>
		/// Max distance.
		/// </param>
		private short[] ApplyThreshold(short[] backgroundExtracted, 
									   uint minDistance, uint maxDistance){
			short[] result = new short[backgroundExtracted.Length];
			
			for (int i = 0; i < backgroundExtracted.Length; ++i){
				short bgVal = backgroundExtracted[i];
				if (bgVal >= minDistance && bgVal <= maxDistance){
					result[i] = bgVal;
				} else {
					result[i] = -1;
				}
			}
			
			return result;
		}
		#endregion
	}
}
