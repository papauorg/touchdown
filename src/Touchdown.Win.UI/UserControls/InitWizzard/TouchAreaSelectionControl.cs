using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Touchdown.Core;
using Touchdown.SensorAbstraction;
using System.Threading.Tasks;

namespace Touchdown.Win.UI.UserControls.InitWizzard {
	public partial class TouchAreaSelectionControl : Touchdown.Win.UI.UserControls.InitWizzard.InitKinectWizzardControl {
		
		private Bitmap originalImage;
		private Rectangle selection;
	
		public TouchAreaSelectionControl(Button next) : base(next) {
			InitializeComponent();
			this.lblHeadline.Text = "Touch Area Selection";
			this.lblDescription.Text = "Select the area that should be observed by the library";

			numX.Enabled = false;
			numY.Enabled = false;
			numWidth.Enabled = false;
			numHeight.Enabled = false;

			numY.ValueChanged += AreaChanged;
			numX.ValueChanged += AreaChanged;
			numWidth.ValueChanged += AreaChanged;
			numHeight.ValueChanged += AreaChanged;
		}

		public override void SetWizzardInfo(Dictionary<string, object> info) {
			base.SetWizzardInfo(info);
			var depthFrame	= info[INFOKEY_BACKGROUND_MODEL] as DepthFrame;
			var sensor		= info[INFOKEY_SENSOR] as IKinectSensorProvider;

			originalImage = depthFrame.CreateBitmap();
			pbChooseArea.Image = originalImage;

			selection = new Rectangle(0, 0, originalImage.Width, originalImage.Height);
			SetSpinEditValues();

			numX.Value = selection.X;
			numY.Value = selection.Y;
			numWidth.Value = selection.Width;
			numHeight.Value = selection.Height;

		}

		public override void AddOrUpdateWizzardInfo(Dictionary<string, object> info) {
			base.AddOrUpdateWizzardInfo(info);

			var wholeFrame = info[INFOKEY_BACKGROUND_MODEL] as DepthFrame;

			if (rbSpecificArea.Checked) {
				info.AddOrUpdate(INFOKEY_TOUCHAREA, selection);
				int[] newModel = new int[selection.Width*selection.Height];

				Parallel.For(0, wholeFrame.Height, y=>{
					for(int x = 0; x < wholeFrame.Width; ++x){
						if (y > selection.Top && y < selection.Bottom){
							if (x > selection.Left && x < selection.Right){
								int index = y*wholeFrame.Width+x;
								int newX = x - selection.X;
								int newY = y - selection.Y;
								int newIndex = newY*selection.Width+newX;
								newModel[newIndex] = wholeFrame.DistanceInMM[index];
							}
						}
					}
				});

				var newFrame = new DepthFrame(DateTime.Now, newModel, selection.Width, selection.Height);
				info.AddOrUpdate(INFOKEY_BACKGROUND_MODEL, newFrame);
			} else { 
				var area = new Rectangle(0, 0, wholeFrame.Width, wholeFrame.Height);
				info.AddOrUpdate(INFOKEY_TOUCHAREA, area);
			}
		}

		private void SetSpinEditValues() {
			numWidth.Minimum = 1;
			numWidth.Maximum = originalImage.Width - selection.X;
			
			numHeight.Minimum = 1;
			numHeight.Maximum = originalImage.Height - selection.Y;

			numX.Minimum = 0;
			numX.Maximum = originalImage.Width;

			numY.Minimum = 0;
			numY.Maximum = originalImage.Height;
		}

		private void AreaChanged(object sender, System.EventArgs e){
			selection = new Rectangle((int)numX.Value, (int)numY.Value, (int)numWidth.Value, (int)numHeight.Value);
			SetSpinEditValues();

			Bitmap newBitmap = new Bitmap(originalImage);
			using (Graphics g = Graphics.FromImage(newBitmap)) { 
				using(Brush b = new SolidBrush(Color.Red)){
					using (Pen p = new Pen(b, 2)){
						g.DrawRectangle(p, selection);
					}
				}
			}

			pbChooseArea.Image = newBitmap;
		}

		private void rbSpecificArea_CheckedChanged(object sender, EventArgs e) {
			numX.Enabled = rbSpecificArea.Checked;
			numY.Enabled = rbSpecificArea.Checked;
			numWidth.Enabled = rbSpecificArea.Checked;
			numHeight.Enabled = rbSpecificArea.Checked;

			numX.Value = 100;
			numY.Value = 50;
			numWidth.Value = 480;
			numHeight.Value = 380;
		}

		private void btnReset_Click(object sender, EventArgs e) {
			numX.Value = 100;
			numY.Value = 50;
			numWidth.Value = 480;
			numHeight.Value = 380;
		}


	}
}
