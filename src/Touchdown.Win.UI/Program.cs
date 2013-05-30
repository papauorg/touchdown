using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Touchdown.Win.UI {
	static class Program {
		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			bool startApp;
			Dictionary<string, object> wizzardInfo;
			
			using (var wizzard = new frmWizard()) {
				startApp = (wizzard.ShowDialog() == DialogResult.OK);
				wizzardInfo = wizzard.WizzardInfo;
			}

			if (startApp) {
				Application.Run(new frmDemo(wizzardInfo));
			} else { 
				MessageBox.Show("Initialization failed. Exit!", "Initialization failed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Environment.Exit(0);
			}
		}
	}
}
