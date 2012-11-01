using System;
using System.Collections.Generic;
using System.Text;

namespace Touchdown.SensorAbstraction {
	public class SensorData {
		private int _width;
		public int _height;
		private byte[] _data;

		public SensorData (int width, int height, byte[] data) {
			throw new NotImplementedException ();
		}

		public int Width {
			get {
				throw new NotImplementedException ();
			}
		}

		public int Height {
			get {
				throw new NotImplementedException ();
			}
		}

		public byte[] RawData {
			get {
				throw new NotImplementedException ();
			}
		}
	}
}
