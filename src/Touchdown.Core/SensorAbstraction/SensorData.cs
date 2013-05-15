using System;
using System.Collections.Generic;
using System.Text;

namespace Touchdown.SensorAbstraction {
	
	/// <summary>
	/// Provides Raw sensor data of the Kinect.
	/// </summary>
	public class SensorData {
		private int _width;
		private int _height;
		private short[] _data;

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
		/// distance data 0-2047.
		/// </param>
		public SensorData (int width, int height, short[] data, object origSensorData) {
			if (data == null){
				throw new ArgumentNullException("data");
			}
			this.OriginalData = origSensorData;
			this._width = width;
			this._height = height;
			this._data = data;
		}


		#endregion
		
		/// <summary>
		/// holds the original sensor data by the native sensor.
		/// </summary>
		public object OriginalData{get; private set;}

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
		public short[] RawData {
			get {
				return _data;
			}
		}
	}
}
