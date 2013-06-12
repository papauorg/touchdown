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
		private int currentStep;
		private List<UserControls.InitWizzard.InitKinectWizzardControl> wizzardPages;
		
		public frmWizard() {
			InitializeComponent();
			currentStep = 0;
			WizzardInfo = new Dictionary<string,object>();

			this.Load += frmWizard_Load;
			this.btnNext.Click += NextStep;
		}

		void frmWizard_Load(object sender, EventArgs e) {
			InitPages();
			ApplyCurrentStep();
		}

		private void InitPages(){
			wizzardPages = new List<UserControls.InitWizzard.InitKinectWizzardControl>();
			wizzardPages.Add(new WelcomeWizzardControl(this.btnNext));
			wizzardPages.Add(new KinectSensorSelectionControl(this.btnNext));
			wizzardPages.Add(new BackgroundModelGenerationControl(this.btnNext));
			wizzardPages.Add(new TouchAreaSelectionControl(this.btnNext));
			wizzardPages.Add(new LoadDefaultGesturesControl(this.btnNext));
			wizzardPages.Add(new FinishInitWizzardControl(this.btnNext));
		}
		
		private void ApplyCurrentStep(){
			if (currentStep < wizzardPages.Count) {
				pnlWizzardControl.Controls.Clear();
				wizzardPages[currentStep].SetWizzardInfo(this.WizzardInfo);
				pnlWizzardControl.Controls.Add(wizzardPages[currentStep]);
			} else { 
				this.DialogResult = System.Windows.Forms.DialogResult.OK;
				this.Close();
			}
		}

		private void NextStep(object sender, System.EventArgs e) {
			wizzardPages[currentStep].AddOrUpdateWizzardInfo(WizzardInfo);

			this.currentStep++;
			ApplyCurrentStep();
		}

		public Dictionary<String, Object> WizzardInfo{get; private set;}
	}
}
