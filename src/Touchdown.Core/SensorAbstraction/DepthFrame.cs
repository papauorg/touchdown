using System;
using System.Collections.Generic;
using System.Text;

namespace Touchdown.SensorAbstraction {
	/// <summary>
	/// Represents a Depth frame. Contains depth data for recognizing by depth.
	/// </summary>
	public class DepthFrame : Frame {
		
		private short[] _depthData;
		private int[] _distance;
		
		#region Constructors / Destructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Touchdown.SensorAbstraction.DepthFrame"/> class.
		/// calculates the distance automatically!
		/// </summary>
		/// <param name='frameTime'>
		/// Frame time.
		/// </param>
		/// <param name='data'>
		/// Data.
		/// </param>
		/// <param name="depthData">Relative depth data (value from 0 to 2048 that represents the depth)</param>
		public DepthFrame(DateTime frameTime, SensorData data, short[] depthData) : base(frameTime, data){
			if (depthData == null){
				throw new ArgumentNullException("depthData");
			}
			
			this._depthData = depthData;
			this.CalculateDistance();
		}
		
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
		public DepthFrame(DateTime frameTime, SensorData data, short[] depthData, int[] distanceinMM) 
					: this(frameTime, data, depthData){
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
		public static short[] operator-(DepthFrame orig, DepthFrame toRemove){
			short[] result = new short[orig.DepthMap.Length];
			short[] toRemoveArr = new short[toRemove.DepthMap.Length];
			
			orig.DepthMap.CopyTo(result, 0);
			toRemove.DepthMap.CopyTo(toRemoveArr, 0);
			
			// original - background = only elements to recognize.
			// neg. values not allowed so: if neg then use 0;
			for (int i = 0; i < result.Length; ++i){
				result[i] = (short)Math.Max(result[i] - toRemoveArr[i], 0);
			}
			
			return result;
		}
		#endregion 
		
		#region Private Methods
		/// <summary>
		/// Calculates the distance in MM depending on the depth information.
		/// </summary>
		private void CalculateDistance(){
			this._distance = new int[this._depthData.Length];
			
			for (int i = 0; i < this._depthData.Length; ++i){
				this._distance[i] = DistanceInMMFromDepth(this._depthData[i]);
			}
		}
		
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
		/// Gets the depth map.
		/// </summary>
		/// <value>
		/// The depth map.
		/// </value>
		public short[] DepthMap{
			get{
				return _depthData;
			}
		}
		
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
