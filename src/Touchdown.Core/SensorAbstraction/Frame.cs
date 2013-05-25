using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Touchdown.SensorAbstraction {
	
	/// <summary>
	/// Represents a frame. Contains basic information about it.
	/// </summary>
	public abstract class Frame {
		private DateTime _frameTime;
		
		#region Constructors / Destructors
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Touchdown.SensorAbstraction.Frame"/> class.
		/// </summary>
		/// <param name='frameTime'>
		/// Frame time.
		/// </param>
		/// <param name='data'>
		/// Data.
		/// </param>
		public Frame(DateTime frameTime){
			this._frameTime = frameTime;
		}
		#endregion
		
		#region Public Methods
		
		/// <summary>
		/// Creates a visual representation of the frame.
		/// </summary>
		/// <returns>
		/// The bitmap.
		/// </returns>
		public abstract Bitmap CreateBitmap();
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets the frame time.
		/// </summary>
		/// <value>
		/// The frame time.
		/// </value>
		public DateTime FrameTime
		{
			get
			{
				return _frameTime;
			}
		}
		#endregion
	}
}
