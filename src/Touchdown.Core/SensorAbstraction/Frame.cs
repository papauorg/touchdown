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
		protected SensorData _data;
		
		#region Constructors / Destructors
		public Frame(DateTime frameTime, SensorData data){
			if (data == null){
				throw new ArgumentNullException("data");
			}
			
			this._frameTime = frameTime;
			this._data		= data;
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
