namespace Touchdown.Win.UI.UserControls.InitWizzard {
	partial class KinectSensorSelectionControl {
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent() {
			this.lblAvailable = new System.Windows.Forms.Label();
			this.cbAvailable = new System.Windows.Forms.ComboBox();
			this.lblError = new System.Windows.Forms.Label();
			this.pnlContent.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlContent
			// 
			this.pnlContent.Controls.Add(this.lblError);
			this.pnlContent.Controls.Add(this.cbAvailable);
			this.pnlContent.Controls.Add(this.lblAvailable);
			// 
			// lblAvailable
			// 
			this.lblAvailable.AutoSize = true;
			this.lblAvailable.Location = new System.Drawing.Point(15, 26);
			this.lblAvailable.Name = "lblAvailable";
			this.lblAvailable.Size = new System.Drawing.Size(91, 13);
			this.lblAvailable.TabIndex = 0;
			this.lblAvailable.Text = "Available Sensors";
			// 
			// cbAvailable
			// 
			this.cbAvailable.FormattingEnabled = true;
			this.cbAvailable.Location = new System.Drawing.Point(112, 23);
			this.cbAvailable.Name = "cbAvailable";
			this.cbAvailable.Size = new System.Drawing.Size(278, 21);
			this.cbAvailable.TabIndex = 1;
			// 
			// lblError
			// 
			this.lblError.AutoSize = true;
			this.lblError.Location = new System.Drawing.Point(15, 202);
			this.lblError.Name = "lblError";
			this.lblError.Size = new System.Drawing.Size(29, 13);
			this.lblError.TabIndex = 2;
			this.lblError.Text = "Error";
			// 
			// KinectSensorSelectionControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Name = "KinectSensorSelectionControl";
			this.pnlContent.ResumeLayout(false);
			this.pnlContent.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox cbAvailable;
		private System.Windows.Forms.Label lblAvailable;
		private System.Windows.Forms.Label lblError;

	}
}
