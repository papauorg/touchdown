using System;
using Touchdown.SensorAbstraction;

namespace Touchdown.Core {
	/// <summary>
	/// Touch frame ready event arguments.
	/// </summary>
	public class TouchFrameReadyEventArgs : FrameReadyEventArgs<SimpleTouchFrame> {
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Touchdown.Core.TouchFrameReadyEventArgs"/> class.
		/// </summary>
		/// <param name='frame'>
		/// Frame.
		/// </param>
		public TouchFrameReadyEventArgs(SimpleTouchFrame frame) : base(frame){
			
		}
	}
}

