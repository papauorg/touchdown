using System;
using System.Collections.Generic;
using System.Text;

namespace Touchdown.SensorAbstraction {
	/// <summary>
	/// Represents a Depth frame. Contains depth data for recognizing by depth.
	/// </summary>
	public class DepthFrame : Frame {
		
		private short[] _depthData;

		#region Constructors / Destructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Touchdown.SensorAbstraction.DepthFrame"/> class.
		/// </summary>
		/// <param name='frameTime'>
		/// Frame time.
		/// </param>
		/// <param name='data'>
		/// Data.
		/// </param>
		/// <param name="depthData">Relative depth data (value from 0 to 2048 that represents the depth)</param>
		public DepthFrame(DateTime frameTime, SensorData data, short[] depthData) : base(frameTime, data){
			_depthData = depthData;
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
			// ToDo: create depth bitmap.
			return null;
		}
		#endregion

		/// <summary>
		/// Gets the depth map.
		/// </summary>
		/// <value>
		/// The depth map.
		/// </value>
		public short[] DepthMap
		{
			get
			{
				return _depthData;
			}
		}
	}
}
