using System;
using System.Collections.Generic;
using System.Text;

namespace Touchdown.SensorAbstraction {
	
	/// <summary>
	/// Raw sensor data.
	/// </summary>
	public class SensorData {
		private int _width;
		public int _height;
		private byte[] _data;

		#region Constructors / Destructors
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
				return _data.Clone();
			}
		}
	}
}
