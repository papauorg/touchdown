using System;
using System.Collections.Generic;
using System.Text;
using Touchdown.SensorAbstraction;

namespace Touchdown.Core {
	/// <summary>
	/// Defines basic methods and events that are needed to get touchframes of a defined area
	/// </summary>
	public interface ITouchObserver<TFrame> where TFrame : SimpleTouchFrame{
		/// <summary>
		/// Occurs when touch frame ready.
		/// </summary>
		event EventHandler<FrameReadyEventArgs<TFrame>> TouchFrameReady;
	}
}
