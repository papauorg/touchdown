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
	public partial class BackgroundModelGenerationControl : Touchdown.Win.UI.UserControls.InitWizzard.InitKinectWizzardControl {
		
		private DepthFrame backgroundModel;
		private BackgroundModelCreator creator;
		private IKinectSensorProvider sensor;

		public BackgroundModelGenerationControl(Button next) : base(next) {
			InitializeComponent();
			creator = new BackgroundModelCreator();

			this.NextButtonEnabled = false;
			this.lblDescription.Text = "Generate a basic background model to be able to extract touch points.";
			this.lblHeadline.Text = "Background Model Creation";
		}

		public override void SetWizzardInfo(Dictionary<string, object> info) {
			base.SetWizzardInfo(info);

			progBackground.Minimum = 0;
			progBackground.Maximum = (int)numFrameCount.Value;
			sensor = ((IKinectSensorProvider)info[INFOKEY_SENSOR]);
		}

		public override void AddOrUpdateWizzardInfo(Dictionary<string, object> info) {
			base.AddOrUpdateWizzardInfo(info);
			info.AddOrUpdate(INFOKEY_BACKGROUND_MODEL, this.backgroundModel);
		}

		private void BackgroundAdd(object sender, DepthFrameReadyEventArgs e) {
			if (creator.FrameCount < numFrameCount.Value) {
				creator.Add(e.FrameData);
				progBackground.Increment(1);
			} else { 
				sensor.DepthFrameReady -= BackgroundAdd;
				sensor.Stop();
				backgroundModel = creator.GetBackgroundModel();
				this.NextButtonEnabled = true;
				this.btnGenerate.Enabled = true;
			}
		}

		private void btnGenerate_Click(object sender, EventArgs e) {
			this.Parent.Enabled = false;
			
			progBackground.Value   = 0;
			
			creator.Clear();
			
			this.NextButtonEnabled = false;
			this.btnGenerate.Enabled = false;

			sensor.DepthFrameReady += BackgroundAdd;
			sensor.Start();

		}
	}
}
