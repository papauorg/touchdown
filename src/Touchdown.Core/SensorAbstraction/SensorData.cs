using System;
using System.Collections.Generic;
using System.Text;

namespace Touchdown.SensorAbstraction {
	
	/// <summary>
	/// Provides Raw sensor data of the Kinect. Uses 1-dimensional bytearray due to easy compatibility with the 
	/// openkinect framework
	/// </summary>
	public class SensorData {
		private int _width;
		public int _height;
		private byte[] _data;

		#region Constructors / Destructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Touchdown.SensorAbstraction.SensorData"/> class.
		/// </summary>
		/// <param name='width'>
		/// Width.
		/// </param>
		/// <param name='height'>
		/// Height.
		/// </param>
		/// <param name='data'>
		/// Data.
		/// </param>
		public SensorData (int width, int height, byte[] data) {
			if (data == null){
				throw new ArgumentNullException("data");
			}
			if (data.Length != width*height){
				throw new ArgumentOutOfRangeException("The width * height does not match the byte data length");
			}
			_width = width;
			_height = height;
			_data = data;
		}
		#endregion
		
		/// <summary>
		/// Gets the width.
		/// </summary>
		/// <value>
		/// The width.
		/// </value>
		public int Width {
			get {
				return _width;
			}
		}

		/// <summary>
		/// Gets the height.
		/// </summary>
		/// <value>
		/// The height.
		/// </value>
		public int Height {
			get {
				return _height;
			}
		}

		/// <summary>
		/// Gets the raw data.
		/// </summary>
		/// <value>
		/// The raw data.
		/// </value>
		public byte[] RawData {
			get {
				byte[] returnArray = null;
				_data.CopyTo(returnArray, 0);
				return returnArray;
			}
		}
	}
}
