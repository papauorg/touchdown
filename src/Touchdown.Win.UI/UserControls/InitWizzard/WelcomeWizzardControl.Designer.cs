namespace Touchdown.Win.UI.UserControls.InitWizzard {
	partial class WelcomeWizzardControl {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeWizzardControl));
			this.label1 = new System.Windows.Forms.Label();
			this.pictureLogo = new System.Windows.Forms.PictureBox();
			this.pnlContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlContent
			// 
			this.pnlContent.Controls.Add(this.pictureLogo);
			this.pnlContent.Controls.Add(this.label1);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(134, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(295, 156);
			this.label1.TabIndex = 0;
			this.label1.Text = resources.GetString("label1.Text");
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// pictureLogo
			// 
			this.pictureLogo.Image = global::Touchdown.Win.UI.Properties.Resources.Touchdown;
			this.pictureLogo.InitialImage = global::Touchdown.Win.UI.Properties.Resources.Touchdown;
			this.pictureLogo.Location = new System.Drawing.Point(18, 20);
			this.pictureLogo.Name = "pictureLogo";
			this.pictureLogo.Size = new System.Drawing.Size(92, 86);
			this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureLogo.TabIndex = 1;
			this.pictureLogo.TabStop = false;
			// 
			// WelcomeWizzardControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Name = "WelcomeWizzardControl";
			this.pnlContent.ResumeLayout(false);
			this.pnlContent.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureLogo;
	}
}
