using System;
using System.Collections.Generic;
using System.Text;
using Touchdown.SensorAbstraction;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Touchdown.Core {
	/// <summary>
	/// Simple touch area observer. Observes the given toucharea and creates touchframes of it.
	/// </summary>
	public class SimpleTouchAreaObserver : ITouchObserver<Touchdown.SensorAbstraction.SimpleTouchFrame> {

		#region Members
		private IKinectSensorProvider _sensor;
		private TouchSettings _settings;
		private DepthFrame _avgBackground;

		private int touchFrameCount;
		private DateTime lastTouchFrameCount;
		private bool[,] structuringElement = {{true,true,true},
											  {true,true,true},
											  {true,true,true}};

		private BackgroundWorker worker;
		#endregion

		#region Object Events
		/// <summary>
		///  Occurs when touch frame is ready. 
		/// </summary>
		public event EventHandler<FrameReadyEventArgs<SimpleTouchFrame>> TouchFrameReady;
		#endregion

		#region Constructors / Destructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Touchdown.Core.SimpleTouchAreaObserver"/> class.
		/// </summary>
		/// <param name='sensor'>
		/// Sensor used by the areaobserver.
		/// </param>
		/// <param name='settings'>
		/// Settings used for the areaobserver.
		/// </param>
		/// <param name="backgroundModel">
		///	defines the background model needed for recognition
		/// </param>
		/// <param name="observedArea">constraint for touchpoints. only points within this area are recognized.
		/// if not given, the whole area is used.</param>
		/// <exception cref="ArgumentNullException">if <param name="sensor" />  or <param name="settings"/> is null</exception>
		public SimpleTouchAreaObserver(	IKinectSensorProvider sensor, 
										TouchSettings settings,
										DepthFrame backgroundModel) {

			if (sensor == null){
				throw new ArgumentNullException("sensor");
			}
			
			if (settings == null){
				throw new ArgumentNullException("settings");
			}

			this._sensor = sensor;
			this._settings = settings;
			
			this._avgBackground = backgroundModel;
			
			// register events needed for recognition of touch frames.
			this._sensor.DepthFrameReady 	+= this.DepthFrameReadyHandler;
			this._sensor.RGBFrameReady		+= this.RGBFrameReadyHandler;

			this.worker = new BackgroundWorker();
			worker.WorkerReportsProgress = false;
			worker.WorkerSupportsCancellation = false;
			worker.RunWorkerCompleted += BackgroundWorkerFinished;
			worker.DoWork += BackgroundWorkerDoWork;

			touchFrameCount = 0;
			lastTouchFrameCount = DateTime.Now;

			structuringElement = Morphology.GetDiskStructuringElement(2);
		}
		#endregion
		
		#region Private Methods
		private void DepthFrameReadyHandler(object sender, DepthFrameReadyEventArgs e){

			// recognition of touch points
			if (TouchFrameReady != null){
				// check if the worker is busy, if so drop the frame;
				if (!worker.IsBusy) {
					/* remove the background model from the current frame to have only 
					objects left that are not part of the background.
					Those objects should be used for recognition. (could be a hand for example) */
					DepthFrame foreGround =  this._avgBackground - e.FrameData;

					worker.RunWorkerAsync(foreGround);
				}
			}
		}
		
		private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e){
			var foreGround = e.Argument as DepthFrame;
			
			// multiply values of foreground to get clearer shapes:
			foreGround.MultiplyBy(5.5f);

			/*  apply the threshold of the settings to recognize all points that 
			 *  are close enough to the background */
			 // create matrix that contains information if the pixel is
			// considered a touched pixel. Use a matrix instead of an array 
			// for easier access.

			//BilinearFilter filter = new BilinearFilter(foreGround.Width, foreGround.Height, 3);
			//var result = filter.Apply(foreGround.DistanceInMM);
			//result = filter.Apply(result);
			//result = filter.Apply(result);

			bool[,] isTouched = 
			this.ApplyThreshold(foreGround.DistanceInMM, 
								foreGround.Width, foreGround.Height,
					 			(uint)(this._settings.MinDistanceFromBackround * 5.5), 
					 			(uint)(this._settings.MaxDistanceFromBackground * 5.5));

			// apply morphological opening
			var touched = Morphology.Open(isTouched, this.structuringElement);
			
			/* the extracted background contains now only the parts of the image where something is different*
	 		 *	than the background. In this case usually fingers. 
			 *	There are very "blury" areas where the finger are located. Extract the touchpoints of it. */
			List<TouchPoint> touchPoints = this.ExtractTouchPoints(touched);

			var currentFrame = new SimpleTouchFrame(DateTime.Now, touchPoints, foreGround.Width, foreGround.Height);
			e.Result = currentFrame;
			//e.Result = touchAverageSmoother.Smoothe(currentFrame);


			touched = null;
			isTouched = null;
			foreGround.Dispose();
		}

		private static String GetVisualization(bool[,] p){
			StringBuilder builder = new StringBuilder();
			for (int y = 0; y < p.GetLength(1); ++y) {
				for (int x = 0; x < p.GetLength(0); ++x) { 
					String character = p[x,y] ? "#" : "O";
					builder.Append(character);
					builder.Append("\t");
				}
				builder.AppendLine();
			}

			return builder.ToString();
		}

		private void BackgroundWorkerFinished(object sender, RunWorkerCompletedEventArgs e) {
			var originalFrame = e.Result as SimpleTouchFrame;

			using (SimpleTouchFrame touchFrame
							= new SimpleTouchFrame(originalFrame.FrameTime,
													originalFrame.TouchPoints.ToList(),
													originalFrame.Width,
													originalFrame.Height)) { 
			 		 
			 	TouchFrameReadyEventArgs eventArgs 
			 		  			= new TouchFrameReadyEventArgs(touchFrame);
			 		  					
			 	TouchFrameReady(this, eventArgs);

				eventArgs = null;
			}
			originalFrame.Dispose();

			this.touchFrameCount++;
			if (DateTime.Now.Subtract(this.lastTouchFrameCount).TotalSeconds >= 1) { 
				this.TouchFPS = this.touchFrameCount;
				this.lastTouchFrameCount = DateTime.Now;
				this.touchFrameCount = 0;
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
		/// <param name='isTouched'>
		/// depthmatrix 
		/// </param>
		private List<TouchPoint> ExtractTouchPoints(bool[,] isTouched) {
			List<TouchPoint> resultingPoints = new List<TouchPoint>();
			
			List<Contour> contours = Contour.FindContours(isTouched, this._settings);
			
			if (contours != null && contours.Count > 0){
				contours.ForEach((x)=> resultingPoints.Add(x.GetMiddle()));
			}
			return resultingPoints;
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
		private bool[,] ApplyThreshold(int[] backgroundExtracted, int width, int height,
									   uint minDistance, uint maxDistance){
			bool[,] result = new bool[width, height];
			
			Parallel.For(0, height, y => {
				for (int x = 0; x < width; ++x){
					int bgVal = backgroundExtracted[y*width+x];
				
					if (bgVal >= minDistance && bgVal <= maxDistance){
						result[x,y] = true;
					} else {
						result[x,y] = false;
					}
				}
			});
			
			return result;
		}
		#endregion

		#region Properties
		/// <summary>
		/// returns the framereate of the observer
		/// </summary>
		public int TouchFPS {get; private set;} 
		#endregion
	}
}
