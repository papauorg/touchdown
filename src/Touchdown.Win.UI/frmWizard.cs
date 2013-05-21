using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Touchdown.Win.UI.UserControls.InitWizzard;

namespace Touchdown.Win.UI {
	public partial class frmWizard : Form {
		int currentStep;
		List<UserControls.InitWizzard.InitKinectWizzardControl> wizzardPages;

		public frmWizard() {
			InitializeComponent();
			currentStep = 0;
			this.Load += frmWizard_Load;
		}

		void frmWizard_Load(object sender, EventArgs e) {
			InitPages();
			ApplyCurrentStep();
		}

		private void InitPages(){
			wizzardPages = new List<UserControls.InitWizzard.InitKinectWizzardControl>();
			wizzardPages.Add(new KinectSensorSelectionControl());
			wizzardPages.Add(new BackgroundModelGenerationControl());
			wizzardPages.Add(new TouchAreaSelectionControl());
			wizzardPages.Add(new FinishInitWizzardControl());
		}
		
		private void ApplyCurrentStep(){
			if (currentStep < wizzardPages.Count) {
				pnlWizardContainer.Controls.Clear();
				pnlWizardContainer.Controls.Add(wizzardPages[currentStep]);
			} else { 
				this.DialogResult = System.Windows.Forms.DialogResult.OK;
				this.Close();
			}
		}


		public Touchdown.SensorAbstraction.IKinectSensorProvider Sensor{get; private set;}

	}
}
