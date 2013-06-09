using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Touchdown.SensorAbstraction;
using System.Drawing;
using System.Collections.ObjectModel;

namespace Touchdown.Core {
	/// <summary>
	/// Represents a sequence of touchframes.
	/// </summary>
	public class TouchPattern : IDisposable {

		#region Members
		List<SimpleTouchFrame> frameList;
		#endregion

		#region Constructors
		/// <summary>
		/// Creates a new empty touchpattern.
		/// </summary>
		public TouchPattern(){
			this.frameList = new List<SimpleTouchFrame>();
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// adds a deep copy of the frame to the pattern
		/// </summary>
		/// <param name="frame">frame that should be part of the pattern</param>
		public void AddFrame(SimpleTouchFrame frame){
			var copy = CopyFrame(frame);
			frameList.Add(copy);
		}

		/// <summary>
		/// Should be called when a patter recording is completed. Returns a representation of
		/// the current pattern but cropped to its smallest/largest values. 
		/// Coordinates will be relative afterwards and not absolute to the original touch frames.
		/// Also strips empty frames.
		/// </summary>
		/// <returns>Cropped Touch Pattern.</returns>
		public TouchPattern Normalize(){
			var bounds = GetBounds();

			if (bounds.X == 0 && bounds.Y == 0) {
				// already normalized
				return this;
			} else { 
				TouchPattern normalized = new TouchPattern();
				foreach (var frame in this.frameList) {
					if (frame.TouchPoints.Count > 0) { 
						var normalizedPoints = new List<TouchPoint>();
						foreach (var point in frame.TouchPoints) { 
							normalizedPoints.Add(new TouchPoint(point.X - bounds.X, point.Y - bounds.Y));
						}

						var normalizedFrame = new SimpleTouchFrame(frame.FrameTime, normalizedPoints, bounds.Width, bounds.Height);
						normalized.AddFrame(normalizedFrame);
					}
				}
				return normalized;
			}
		}

		/// <summary>
		/// returns a scaled copy of the current pattern. Scaling is done according
		/// to the given patterns bounds.
		/// </summary>
		/// <param name="scaleAs">bounds of the patterns that are used for scaling</param>
		/// <returns>scaled copy of the current pattern.</returns>
		public TouchPattern Scale(TouchPattern scaleAs){
			var thisBounds	= GetBounds();
			var scaleBounds	= scaleAs.GetBounds();

			double scaleFactorX = scaleBounds.Width / thisBounds.Width;
			double scaleFactorY = scaleBounds.Height / thisBounds.Height;

			TouchPattern result = new TouchPattern();
			foreach (var frame in this.Frames) { 
				List<TouchPoint> copy = new List<TouchPoint>();
				foreach(var point in frame.TouchPoints){
					var newX = (int) Math.Round(point.X * scaleFactorX);
					var newY = (int) Math.Round(point.Y * scaleFactorY);
					copy.Add(new TouchPoint(newX, newY));
				}
				result.AddFrame(new SimpleTouchFrame(DateTime.Now, copy, scaleBounds.Width, scaleBounds.Height));
			}

			return result;
		}

		/// <summary>
		///  Creates a visual representation of the pattern. 
		/// </summary>
		/// <returns>
		///  The bitmap. 
		/// </returns>
		public System.Drawing.Bitmap CreateBitmap() {
			ColorConverter col = new ColorConverter();
			var blue = (Color)col.ConvertFromString("#66CCFF");
			var red = (Color)col.ConvertFromString("#FF3333");

			return this.CreateBitmap(blue, red);
		}

		/// <summary>
		///  Creates a visual representation of the pattern. 
		/// </summary>
		/// <returns>
		///  The bitmap. 
		/// </returns>
		public Bitmap CreateBitmap(Color background, Color touchPoints){
			if (frameList.Count <= 0) { 
				return null;
			}

			var firstFrame = this.frameList[0];
			Bitmap buffer = new Bitmap(firstFrame.Width, firstFrame.Height);
			using (Graphics bufferGraphics = Graphics.FromImage(buffer)) {
				using (SolidBrush brush = new SolidBrush(background)){
					bufferGraphics.FillRectangle(brush, 0, 0, buffer.Width, buffer.Height);
				}
				
				for (int i = 0; i < this.frameList.Count; ++i) { 
					using (SolidBrush brush = new SolidBrush(GetColorGradient(i, this.frameList.Count))) {
						var frame = this.frameList[i];

						foreach(var point in frame.TouchPoints){
							int size = 15; //px

							// upside down:
							int x = point.X - size;
							int y = frame.Height - point.Y - size;

							bufferGraphics.FillEllipse(brush, x, y, size, size);
						}
					}
				}
			}
			return buffer;
		}

		/// <summary>
		/// disposes this object
		/// </summary>
		public void Dispose() {
			if (this.frameList != null) {
				foreach (var frame in frameList) { 
					frame.Dispose();
				}
				frameList = null;
			}
		}
		#endregion

		#region Private Methods
		private static Color GetColorGradient(int val, int overall){
			int maxColVal = 255;
			double colorValueForOne = Math.Max((maxColVal / overall), 0.1);
			double actualColorValue = Math.Min(colorValueForOne * val, 255);

			int greenValue	= Math.Min((int)((double)maxColVal - actualColorValue), 255);
			int redValue	= Math.Min((int)(actualColorValue), 255);

			return Color.FromArgb(redValue, greenValue, 0);
		}
		
		private Rectangle GetBounds(){
			var allPoints = frameList.SelectMany(f => f.TouchPoints);
			var minX = allPoints.AsParallel().Min(p => p.X);
			var minY = allPoints.AsParallel().Min(p => p.Y);
			var maxX = allPoints.AsParallel().Max(p => p.X);
			var maxY = allPoints.AsParallel().Max(p => p.Y);

			return new Rectangle(minX, minY, maxX - minX, maxY - minY);
		}
		
		private SimpleTouchFrame CopyFrame(SimpleTouchFrame frame){
			List<TouchPoint> copy = new List<TouchPoint>();
			foreach(var point in frame.TouchPoints){
				copy.Add(new TouchPoint(point.X, point.Y));
			}
		
			return new SimpleTouchFrame(frame.FrameTime, copy, frame.Width, frame.Height);
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the name of the TouchPattern
		/// </summary>
		public String Name{get; set;}

		/// <summary>
		/// returns the list of frames that are contained in this pattern
		/// </summary>
		public ReadOnlyCollection<SimpleTouchFrame> Frames{
			get{
				return frameList.AsReadOnly();
			}
		}
		#endregion
	}


}


