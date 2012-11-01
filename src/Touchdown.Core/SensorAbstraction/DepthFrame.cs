using System;
using System.Collections.Generic;
using System.Text;

namespace Touchdown.SensorAbstraction {
	/// <summary>
	/// Represents a Depth frame. Contains depth data for recognizing by depth.
	/// </summary>
	public class DepthFrame : Frame {
		
		private int _depthMap;

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
