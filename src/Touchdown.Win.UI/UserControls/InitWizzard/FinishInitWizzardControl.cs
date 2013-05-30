using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Touchdown.Win.UI.UserControls.InitWizzard {
	public partial class FinishInitWizzardControl : Touchdown.Win.UI.UserControls.InitWizzard.InitKinectWizzardControl {
		public FinishInitWizzardControl(Button next) : base(next){
			InitializeComponent();

			this.lblHeadline.Text = "Configuration Complete";
			this.lblDescription.Text = "Configuration for Kinect is now complete.";
		}
	}
}
