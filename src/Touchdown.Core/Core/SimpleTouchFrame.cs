using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Drawing;

namespace Touchdown.SensorAbstraction {
		/// <summary>
		/// Represents a simple touch frame. Contains only a list of recognized touch points without
		/// any additional info about it.
		/// </summary>
		public class SimpleTouchFrame : Frame {
	
		private IList<TouchPoint> touchPoints;
		
		#region Constructors / Destructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Touchdown.SensorAbstraction.SimpleTouchFrame"/> class.
		/// </summary>
		/// <param name='frameTime'>
		/// Frame time.
		/// </param>
		/// <param name='data'>
		/// Data.
		/// </param>
		/// <param name="touchpoints">
		/// the touchpoints that are relevant for this frame.
		/// </param>
		/// <param name="height">height of the frame</param>
		/// <param name="width">width of the frame</param>
		public SimpleTouchFrame(DateTime frameTime, 
								IList<TouchPoint> touchpoints,
								int height,
								int width
								) : base(frameTime, height, width) {
			this.touchPoints = touchpoints;
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
			ColorConverter col = new ColorConverter();
			var blue = (Color)col.ConvertFromString("#66CCFF");
			var red = (Color)col.ConvertFromString("#FF3333");

			return this.CreateBitmap(blue, red);
		}

		public Bitmap CreateBitmap(Color background, Color touchPoints){
			Bitmap buffer = new Bitmap(this.Width, this.Height);
			using (Graphics bufferGraphics = Graphics.FromImage(buffer)) {
				using (SolidBrush brush = new SolidBrush(background)){
					bufferGraphics.FillRectangle(brush, 0, 0, buffer.Width, buffer.Height);
				}
				using (SolidBrush brush = new SolidBrush(touchPoints)) { 
					foreach(var point in this.TouchPoints){
						int size = 3; //px

						bufferGraphics.FillEllipse(brush, point.X - size, point.Y - size, size, size);
					}
				}
			}
			return buffer;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets the touch points.
		/// </summary>
		/// <value>
		/// The touch points.
		/// </value>
		public ReadOnlyCollection<TouchPoint> TouchPoints {
			get{
				return new ReadOnlyCollection<TouchPoint>(this.touchPoints);
			}
		}
		#endregion
		}
}
