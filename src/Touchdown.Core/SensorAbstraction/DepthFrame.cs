using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;

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
			byte[] colorFrame = new byte[this.Height * this.Width * 4];

			int maxValue = this._distance.Where(x=> x<2047).Max();
			int minValue = this._distance.Min();

			// Process each row in parallel
			Parallel.For(0, this.Height, depthArrayRowIndex => {
				// Process each pixel in the row
				for (int depthArrayColumnIndex = 0; depthArrayColumnIndex < this.Width; depthArrayColumnIndex++) {
					var distanceIndex = depthArrayColumnIndex + (depthArrayRowIndex * this.Width);
					var index = distanceIndex * 4;

					// Map the distance to an intesity that can be represented in RGB
					int newMax = _distance[distanceIndex] - minValue;
					var intensity = (byte)(255 - (255 * newMax / (3150)));

					// Apply the intensity to the color channels
					colorFrame[index + 0] = intensity;
					colorFrame[index + 1] = intensity;
					colorFrame[index + 2] = intensity;
				}
			});

			var bitmap = new Bitmap(this.Width, this.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

			var data = bitmap.LockBits(
				new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), 
				System.Drawing.Imaging.ImageLockMode.ReadWrite,
				bitmap.PixelFormat);

			Marshal.Copy(colorFrame, 0, data.Scan0, colorFrame.Length);

			bitmap.UnlockBits(data);

			return bitmap;
		}

		/// <summary>
		/// multiplies depthvalues by the multiplicator to lighten or darken the image.
		/// </summary>
		/// <param name="multiplicator">multiplicator</param>
		public void MultiplyBy(float multiplicator){
			Parallel.For(0, this.DistanceInMM.Length, i=>{
				this._distance[i] = (int)(this._distance[i] * multiplicator);
			});
		}

		public static string GetVisualization(int[] arr, int width) {
			StringBuilder builder = new StringBuilder();

			for (int i = 0; i < arr.Length; ++i) {
				builder.Append(arr[i]);
				builder.Append("\t");
				if (i % width == 0 && i > 0) { 
					builder.AppendLine();
				}
			}

			return builder.ToString();
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
				// add 20 to the original so negative values are avoided and not flattened to 0
				result[i] = (int)Math.Max((orig.DistanceInMM[i]) - toRemove.DistanceInMM[i], 0);
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

		public override void Dispose() {
			base.Dispose();
			this._distance = null;
		}
	}
}
