using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Touchdown.Core;
using Touchdown.SensorAbstraction;

namespace Touchdown.Win.UI.UserControls.InitWizzard {
	public partial class TouchAreaSelectionControl : Touchdown.Win.UI.UserControls.InitWizzard.InitKinectWizzardControl {
		
		private Bitmap originalImage;
		private Bitmap cropImage;
		private Rectangle cropArea;
		private Rectangle selection;

		public TouchAreaSelectionControl(Button next) : base(next) {
			InitializeComponent();
			this.lblHeadline.Text = "Touch Area Selection";
			this.lblDescription.Text = "Select the area that should be observed by the library";

			rbSpecificArea.Enabled = false;

			this.pbChooseArea.MouseDown += pbChooseArea_MouseDown;
			this.pbChooseArea.MouseMove += pbChooseArea_MouseMove;
			this.pbChooseArea.Paint += pbChooseArea_Paint;
		}

		public override void SetWizzardInfo(Dictionary<string, object> info) {
			base.SetWizzardInfo(info);
			var rgbFrame	= info[INFOKEY_COLOR_BACKGROUND_MODEL] as RGBFrame;
			var depthFrame	= info[INFOKEY_BACKGROUND_MODEL] as DepthFrame;
			var sensor		= info[INFOKEY_SENSOR] as IKinectSensorProvider;

			// crop rgb image so only the parts covered by the depth image will be visible.
			originalImage = rgbFrame.CreateBitmap();
			//var upperLeft	= sensor.MapDepthPointToColorPoint(0, 0);
			//var upperRight	= sensor.MapDepthPointToColorPoint(depthFrame.Width, 0);
			//var lowerLeft	= sensor.MapDepthPointToColorPoint(0, depthFrame.Height);
			//var lowerRight	= sensor.MapDepthPointToColorPoint(depthFrame.Width, depthFrame.Height);
			
			//int startX = Math.Max(upperLeft.X, lowerLeft.X);
			//int startY = Math.Max(upperLeft.Y, upperRight.Y);
			//int endX   = Math.Min(upperRight.X, lowerRight.X);
			//int endY   = Math.Min(lowerRight.Y, lowerLeft.Y);

			//cropArea = new Rectangle(startX, startY, (endX-startX), (endY-startY));
			cropArea = new Rectangle(0, 0, rgbFrame.Width, rgbFrame.Height);
			cropImage= CropImage(originalImage, cropArea);
			pbChooseArea.Image = cropImage;
		}

		public override void AddOrUpdateWizzardInfo(Dictionary<string, object> info) {
			base.AddOrUpdateWizzardInfo(info);

			var wholeFrame = info[INFOKEY_BACKGROUND_MODEL] as DepthFrame;
			var area = new Rectangle(0, 0, wholeFrame.Width, wholeFrame.Height);

			if (rbSpecificArea.Checked) {
				// calculate area 
			} else { 
				info.AddOrUpdate(INFOKEY_TOUCHAREA, area);
			}
			
		}

		private Bitmap CropImage(Bitmap source, Rectangle section){
			// An empty bitmap which will hold the cropped image
			Bitmap bmp = new Bitmap(section.Width, section.Height);
 
			Graphics g = Graphics.FromImage(bmp);
 
			// Draw the given area (section) of the source image
			// at location 0,0 on the empty bitmap (bmp)
			g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);
 
			return bmp;
		}

		private void pbChooseArea_MouseDown(object sender, MouseEventArgs e) {
		   selection = new Rectangle(e.X, e.Y, 0, 0);
		   this.Invalidate();
		}

		void pbChooseArea_MouseMove(object sender, MouseEventArgs e) {
			// This makes sure that the left mouse button is pressed.
		   if (e.Button == MouseButtons.Left) {
			   // Draws the rectangle as the mouse moves
			   selection = new Rectangle(selection.Left, selection.Top, e.X - selection.Left, e.Y - selection.Top);
		   }
		   this.Invalidate();
		}

		void pbChooseArea_Paint(object sender, PaintEventArgs e) {
			using (Pen pen = new Pen(Color.Red, 1))	{
				e.Graphics.DrawRectangle(pen, selection);
			}
		}
	}
}
