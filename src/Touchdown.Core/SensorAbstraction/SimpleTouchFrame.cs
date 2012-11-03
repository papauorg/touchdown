using System;
using System.Collections.Generic;
using System.Text;

namespace Touchdown.SensorAbstraction {
	/// <summary>
	/// Represents a simple touch frame. Contains only a list of recognized touch points without
	/// any additional info about it.
	/// </summary>
	public class SimpleTouchFrame : Frame {
	
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
		public SimpleTouchFrame(DateTime frameTime, SensorData data) : base(frameTime, data){
		
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets the touch points.
		/// </summary>
		/// <value>
		/// The touch points.
		/// </value>
		public IEnumerable<TouchPoint> TouchPoints {
			get {
				throw new NotImplementedException ();
			}
		}
		#endregion
	}
}
