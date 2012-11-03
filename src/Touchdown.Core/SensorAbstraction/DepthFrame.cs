using System;
using System.Collections.Generic;
using System.Text;

namespace Touchdown.SensorAbstraction {
	/// <summary>
	/// Represents a Depth frame. Contains depth data for recognizing by depth.
	/// </summary>
	public class DepthFrame : Frame {
		
		private int _depthMap;

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
		public DepthFrame(DateTime frameTime, SensorData data) : base(frameTime, data){
			throw new NotImplementedException("Calculate depth map is missing");
		}
		#endregion

		/// <summary>
		/// Gets the depth map.
		/// </summary>
		/// <value>
		/// The depth map.
		/// </value>
		public int[] DepthMap
		{
			get
			{
				return _depthMap;
			}
		}
	}
}
