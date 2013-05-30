using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Touchdown.SensorAbstraction {
	/// <summary>
	/// Represents a Depth frame. Contains depth data for recognizing by depth.
	/// </summary>
	public class DepthFrame : Frame {
		private int[] _distance;

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
		/// <param name='depthData'>
		/// Depth data.
		/// </param>
		/// <param name='distanceinMM'>
		/// Distancein M.
		/// </param>
		/// <param name="height">height of the depth frame</param>
		/// <param name="width">width of the depth frame</param>
		public DepthFrame(DateTime frameTime, int[] distanceinMM, int width, int height) : base(frameTime, width, height){
			this._distance = distanceinMM;
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
		public static DepthFrame operator-(DepthFrame orig, DepthFrame toRemove){
			int[] result = new int[orig.DistanceInMM.Length];
			
			// original - background = only elements to recognize.
			// neg. values not allowed so: if neg then use 0;
			for (int i = 0; i < orig.DistanceInMM.Length; ++i){
				result[i] = (int)Math.Max(orig.DistanceInMM[i] - toRemove.DistanceInMM[i], 0);
			}
			
			return new DepthFrame(DateTime.Now, result, orig.Width, orig.Height);
		}
		#endregion 
		
		#region Private Methods
		
		/// <summary>
		/// contains the formula to calculate the distance in mm by the given depth value between 0 and 2048
		/// see: http://openkinect.org/wiki/Imaging_Information
		/// </summary>
		/// <returns>
		/// The in MM from depth.
		/// </returns>
		/// <param name='depthValue'>
		/// Depth value.
		/// </param>
		private int DistanceInMMFromDepth(short depthValue){
			double result;
			
			result = 0.1236 * Math.Tan(depthValue / 2842.5 + 1.1863);
			result *= 1000; // convert to mm
			
			return (int)result;
		}
		#endregion
		
		/// <summary>
		/// Gets the distance in millimeters.
		/// </summary>
		/// <value>
		/// The distance in millimeters.
		/// </value>
		public int[] DistanceInMM{
			get{
				return _distance;
			}
		}

	}
}
