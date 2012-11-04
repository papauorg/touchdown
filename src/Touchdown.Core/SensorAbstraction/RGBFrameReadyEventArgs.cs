using System;
using System.Collections.Generic;
using System.Text;

namespace Touchdown.SensorAbstraction{

	/// <summary>
	/// RGB frame ready event arguments.
	/// </summary>
	public class RGBFrameReadyEventArgs : FrameReadyEventArgs<RGBFrame>{
		
		#region Constructors / Destructors
			/// <summary>
			/// Initializes a new instance of the <see cref="Touchdown.SensorAbstraction.RGBFrameReadyEventArgs"/> class.
			/// </summary>
			/// <param name='frame'>
			/// Frame.
			/// </param>
			/// <exception cref="ArgumentNullException">if frame is null</exception>
		public RGBFrameReadyEventArgs(RGBFrame frame){
			if (frame == null){
				throw new ArgumentNullException("frame");
			}
			base._frame = frame;
		}
		#endregion
	}
}
