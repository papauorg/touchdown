using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace Touchdown.SensorAbstraction {
	/// <summary>
	/// Represents a RGB frame. Used for recognition by colour.
	/// </summary>
	public class RGBFrame : Frame {
	
		#region Constructors / Destructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Touchdown.SensorAbstraction.RGBFrame"/> class.
		/// </summary>
		/// <param name='frameTime'>
		/// Frame time.
		/// </param>
		public RGBFrame(DateTime frameTime, byte[] data) : base(frameTime){
			this.ColorBytes = data;
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
			return null;
		}
		#endregion

		/// <summary>
		/// returns the raw bytes of the color image.
		/// </summary>
		public byte[] ColorBytes{get; private set;}
	}
}
