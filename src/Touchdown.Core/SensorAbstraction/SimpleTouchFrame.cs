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
		public SimpleTouchFrame() : base(){
		
		}
		#endregion
		public IEnumerable<TouchPoint> TouchPoints {
			get {
				throw new NotImplementedException ();
			}
		}
	}
}
