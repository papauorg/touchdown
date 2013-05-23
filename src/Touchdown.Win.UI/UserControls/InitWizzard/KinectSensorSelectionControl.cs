using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Kinect;
using System.Linq;
using Touchdown.Core;

namespace Touchdown.Win.UI.UserControls.InitWizzard {
	public partial class KinectSensorSelectionControl : Touchdown.Win.UI.UserControls.InitWizzard.InitKinectWizzardControl {
	
		public KinectSensorSelectionControl() : base(null){
		
		}
		
		public KinectSensorSelectionControl(Button next) : base(next) {
			InitializeComponent();
			this.lblHeadline.Text = "Sensor selection";
			this.lblDescription.Text = "Please select a connected Kinect sensor that the DEMO Program will use.";
			this.lblError.Visible = false;

			if (KinectSensor.KinectSensors.Count > 0) {
				this.cbAvailable.DataSource = KinectSensor.KinectSensors;
				this.cbAvailable.DisplayMember = "UniqueKinectId" ;
			} else { 
				this.lblError.Visible = true;
				this.lblError.Text = "Error: No Kinect Sensor could be detected.";
				this.NextButtonEnabled = false;
			}
		}

		public override void AddOrUpdateWizzardInfo(Dictionary<string, object> info) {
			base.AddOrUpdateWizzardInfo(info);

			var sensor = (KinectSensor)this.cbAvailable.SelectedValue;
			var SDKSensor = new Touchdown.MicrosoftSDK.SDKSensor(sensor);
			info.AddOrUpdate(INFOKEY_SENSOR, SDKSensor);
		}
	}
}
