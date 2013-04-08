using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Touchdown.SensorAbstraction {
		/// <summary>
		/// Represents a simple touch frame. Contains only a list of recognized touch points without
		/// any additional info about it.
		/// </summary>
		public class SimpleTouchFrame : Frame {
	
		private IList<TouchPoint> touchPoints;
		
		#region Constructors / Destructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Touchdown.SensorAbstraction.SimpleTouchFrame"/> class.
		/// </summary>
		/// <param name='frameTime'>
		/// Frame time.
		/// </param>
		/// <param name='data'>
		/// Data.
		/// </param>
		/// <param name="touchpoints">
		/// the touchpoints that are relevant for this frame.
		/// </param>
		public SimpleTouchFrame(DateTime frameTime, 
								SensorData data, 
								IList<TouchPoint> touchpoints) : base(frameTime, data) {
			this.touchPoints = touchpoints;
		}
		#endregion
		
		#region Public Methods
		/// <summary>
		///  Creates a visual representation of the frame. 
		/// </summary>
		/// <returns>
		///  The bitmap. 
		/// </returns>
		public override System.Drawing.Bitmap CreateBitmap() {
			return null;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets the touch points.
		/// </summary>
		/// <value>
		/// The touch points.
		/// </value>
		public ReadOnlyCollection<TouchPoint> TouchPoints {
			get{
				return new ReadOnlyCollection<TouchPoint>(this.touchPoints);
			}
		}
		#endregion
		}
}
