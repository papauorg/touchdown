using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Touchdown.SensorAbstraction;

namespace Touchdown.Core {
	/// <summary>
	/// Smoothes touchframes and assignes labels for touchpoints 
	/// so they remain distinctive and can be tracked over time.
	/// </summary>
	public class TouchPointLabeler {

		#region Members
		Queue<SimpleTouchFrame> frameQueue;
		ITouchObserver<SimpleTouchFrame> frameProvider;
		IPointDistanceProvider distanceProvider;
		
		int averageCount = 4;
		const int MAX_DISTANCE = 15;
		#endregion

		#region Constructors
		public TouchPointLabeler(ITouchObserver<SimpleTouchFrame> frameProvider, 
								 IPointDistanceProvider distanceProvider){
			this.frameProvider = frameProvider;
			this.distanceProvider = distanceProvider;

			this.frameQueue = new Queue<SimpleTouchFrame>();
			this.frameProvider.TouchFrameReady += frameProvider_TouchFrameReady;
		}
		#endregion

		#region Private Methods
		void frameProvider_TouchFrameReady(object sender, FrameReadyEventArgs<SimpleTouchFrame> e) {
			// apply smoothing
			if (frameQueue.Count == averageCount) { 
				var toDispose = frameQueue.Dequeue() as SimpleTouchFrame;
				toDispose.Dispose();
				toDispose = null;
			}
			frameQueue.Enqueue(e.FrameData);
		}
		
		private SimpleTouchFrame GetSmoothedFrame() {
			int width  = this.frameQueue.Peek().Width;
			int height = this.frameQueue.Peek().Height;
			float[] touchSum = new float[width*height];

			short denominator = 0;
			short count = 1;

			foreach (var frame in this.frameQueue) {
				foreach (var point in frame.TouchPoints) { 
					int index = point.Y*frame.Width+point.X;
					touchSum[index] += count;
				}
				// the newer the frame, the better the count
				count++;
				denominator += count;
			}

			List<TouchPoint> smooth = new List<TouchPoint>();
			for (int y = 0; y < height; ++y) {
				for (int x = 0; x < width; ++x) { 
					int index = y*width+x;
					if (touchSum[index]/denominator > 0.7) { 
						smooth.Add(new TouchPoint(x, y));
					}
				}
			}

			return new SimpleTouchFrame(DateTime.Now, smooth, width, height);
		}
		#endregion
	}
}
