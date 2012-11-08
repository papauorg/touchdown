using System;
using System.Collections.Generic;
using System.Text;

namespace Touchdown.SensorAbstraction {

	/// <summary>
	/// Frame ready event arguments. Contains information for when a frame is ready.
	/// Inherited from System.EventArgs to be able to use EventHandlers
	/// </summary>
	public abstract class FrameReadyEventArgs<T> : EventArgs where T : Frame{
		protected T _frame;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Touchdown.SensorAbstraction.FrameReadyEventArgs"/> class.
		/// </summary>
		/// <param name='frame'>
		/// Frame.
		/// </param>
		public FrameReadyEventArgs(T frame) {
			if (frame == null){
				throw new ArgumentNullException("frame");
			}
			_frame = frame;
		}
	
		#region Properties
		/// <summary>
		/// Gets the frame data.
		/// </summary>
		/// <value>
		/// The frame data.
		/// </value>
		public T FrameData{
			get{
				return _frame;
			}
		}
		#endregion
	}
}
