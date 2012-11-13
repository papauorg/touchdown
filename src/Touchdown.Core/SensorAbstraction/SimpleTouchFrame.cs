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
		public SimpleTouchFrame(DateTime frameTime, SensorData data) : base(frameTime, data) {

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

		#endregion
		}
}
