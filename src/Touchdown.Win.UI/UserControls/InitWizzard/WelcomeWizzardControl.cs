using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Touchdown.Win.UI.UserControls.InitWizzard {
	public partial class WelcomeWizzardControl : Touchdown.Win.UI.UserControls.InitWizzard.InitKinectWizzardControl {
		public WelcomeWizzardControl(Button next) : base(next) {
			InitializeComponent();

			this.lblHeadline.Text = "Welcome";
			this.lblDescription.Text = "Welcome to the Touchdown Project DEMO Application.";

		}

		private void label1_Click(object sender, EventArgs e) {

		}
	}
}
