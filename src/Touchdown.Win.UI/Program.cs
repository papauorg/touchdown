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
			bool startApp;

			using (var wizzard = new frmWizard()) {
				startApp = (wizzard.ShowDialog() == DialogResult.OK);
			}

			if (startApp) {
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new frmDemo());
			} else { 
				MessageBox.Show("Initialization failed. Exit!", "Initialization failed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
