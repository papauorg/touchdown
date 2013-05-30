using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

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
		/// <param name="data">raw data of the image</param>
		/// <param name="height">height of the frame</param>
		/// <param name="width">width of the frame</param>
		public RGBFrame(DateTime frameTime, byte[] data, int width, int height) 
			: base(frameTime, width, height){
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
			var bitmap = new Bitmap(this.Width, this.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

			var data = bitmap.LockBits(
				new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
				ImageLockMode.ReadWrite,
				bitmap.PixelFormat);

			Marshal.Copy(this.ColorBytes, 0, data.Scan0, this.ColorBytes.Length);

			bitmap.UnlockBits(data);

			return bitmap;
		}
		#endregion

		/// <summary>
		/// returns the raw bytes of the color image.
		/// </summary>
		public byte[] ColorBytes{get; private set;}
	}
}
