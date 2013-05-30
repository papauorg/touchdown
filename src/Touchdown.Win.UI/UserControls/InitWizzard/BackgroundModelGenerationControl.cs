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
		private RGBFrame colorBackgroundModel;
		private BackgroundModelCreator<DepthFrame> depthCreator;
		private BackgroundModelCreator<RGBFrame> rgbCreator;
		private IKinectSensorProvider sensor;

		public BackgroundModelGenerationControl(Button next) : base(next) {
			InitializeComponent();
			depthCreator = new BackgroundModelCreatorDepth();
			rgbCreator = new BackgroundModelCreatorRGB();

			this.lblDescription.Text = "Generate a basic background model to be able to extract touch points.";
			this.lblHeadline.Text = "Background Model Creation";
		}

		public override void SetWizzardInfo(Dictionary<string, object> info) {
			base.SetWizzardInfo(info);

			this.NextButtonEnabled = false;

			progBackground.Minimum = 0;
			progBackground.Maximum = (int)numFrameCount.Value;
			sensor = ((IKinectSensorProvider)info[INFOKEY_SENSOR]);
		}

		public override void AddOrUpdateWizzardInfo(Dictionary<string, object> info) {
			base.AddOrUpdateWizzardInfo(info);
			info.AddOrUpdate(INFOKEY_BACKGROUND_MODEL, this.backgroundModel);
			info.AddOrUpdate(INFOKEY_COLOR_BACKGROUND_MODEL, this.colorBackgroundModel);
		}

		private void BackgroundAdd(object sender, DepthFrameReadyEventArgs e) {
			if (depthCreator.FrameCount < numFrameCount.Value) {
				depthCreator.Add(e.FrameData);
				progBackground.Increment(1);
			}
			
			checkAllBackgroundsFinished();	
		}

		private void ColorBackgroundAdd(object sender, RGBFrameReadyEventArgs e){
			if (rgbCreator.FrameCount < numFrameCount.Value) {
				rgbCreator.Add(e.FrameData);
			}
			checkAllBackgroundsFinished();
		}

		private void checkAllBackgroundsFinished(){
			if (depthCreator.FrameCount >= numFrameCount.Value && rgbCreator.FrameCount >= numFrameCount.Value) {
				sensor.Stop();
				sensor.RGBFrameReady -= ColorBackgroundAdd;
				sensor.DepthFrameReady -= BackgroundAdd;
				
				colorBackgroundModel = rgbCreator.GetBackgroundModel();
				backgroundModel = depthCreator.GetBackgroundModel();
				
				this.NextButtonEnabled = true;
				this.btnGenerate.Enabled = true;
			}
		}

		private void btnGenerate_Click(object sender, EventArgs e) {
			progBackground.Value   = 0;
			
			depthCreator.Clear();
			
			this.NextButtonEnabled = false;
			this.btnGenerate.Enabled = false;

			sensor.DepthFrameReady += BackgroundAdd;
			sensor.RGBFrameReady += ColorBackgroundAdd;

			sensor.Start();

		}
	}
}
