using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Touchdown.Core;
using Touchdown.SensorAbstraction;
using System.Drawing;

namespace Touchdown.Core {
	/// <summary>
	/// Is used to filter touch points for specific areas.
	/// </summary>
	public class AreaFilter {

		#region Members
		private SimpleTouchAreaObserver observer;
		private Rectangle area;
		private bool include;
		#endregion

		#region Objectevents
		/// <summary>
		/// Handles the event when the filtered touchframe is ready.
		/// </summary>
		public event EventHandler<TouchFrameReadyEventArgs> TouchFrameReady;

		/// <summary>
		/// New instance of the area filter
		/// </summary>
		/// <param name="observer">Observer that gives the touchframes</param>
		/// <param name="observedArea">area that should be filtered for.</param>
		/// <param name="include">defines wheter the area should be included or excluded.</param>
		/// <exception cref="ArgumentNullException">if observer is null</exception>
		public AreaFilter(SimpleTouchAreaObserver observer, Rectangle observedArea, bool include){
			if (observer == null) { 
				throw new ArgumentNullException("observer");
			}
			
			this.observer = observer;
			this.area = observedArea;
			this.include = include;

			this.observer.TouchFrameReady += FilterFrames;
		}
		#endregion

		#region Private Methods
		private void FilterFrames(object sender, FrameReadyEventArgs<SimpleTouchFrame> e) {
			if (TouchFrameReady != null) { 
				SimpleTouchFrame filteredFrame = FilterTouchPoints(e.FrameData);
				TouchFrameReadyEventArgs args = new TouchFrameReadyEventArgs(filteredFrame);
				TouchFrameReady(this, args);
			}
		}

		private SimpleTouchFrame FilterTouchPoints(SimpleTouchFrame frame){
			var points = new List<TouchPoint>();

			foreach(var point in frame.TouchPoints){
				if (point.X >= area.Left && point.X <= area.Right) {
					if (point.Y >= area.Top && point.Y <= area.Bottom){
						points.Add(new TouchPoint(point.X, point.Y));
					}
				}
			}

			return new SimpleTouchFrame(DateTime.Now, points, area.Height, area.Width);
		}
		#endregion
	}
}
