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

		#region Operator
		/// <param name='orig'>
		/// Frame from the sensor.
		/// </param>
		/// <param name='toRemove'>
		/// background model that should be removed..
		/// </param>
		public static short[] operator-(DepthFrame orig, short[] toRemove){
			short[] result = new short[orig.DepthMap.Length];
			orig.DepthMap.CopyTo(result, 0);
			
			// original - background = only elements to recognize.
			// neg. values not allowed so: if neg then use 0;
			for (int i = 0; i < result.Length; ++i){
				result[i] = (short)Math.Max(result[i] - toRemove[i], 0);
			}
			
			return result;
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
