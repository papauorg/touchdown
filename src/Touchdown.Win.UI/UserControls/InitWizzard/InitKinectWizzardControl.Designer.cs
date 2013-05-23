namespace Touchdown.Win.UI.UserControls.InitWizzard {
	partial class InitKinectWizzardControl {
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

		#region Vom Komponenten-Designer generierter Code

		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent() {
			this.pnlInfo = new System.Windows.Forms.Panel();
			this.lblDescription = new System.Windows.Forms.Label();
			this.lblHeadline = new System.Windows.Forms.Label();
			this.pnlContent = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.pnlInfo.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlInfo
			// 
			this.pnlInfo.Controls.Add(this.groupBox1);
			this.pnlInfo.Controls.Add(this.lblDescription);
			this.pnlInfo.Controls.Add(this.lblHeadline);
			this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlInfo.Location = new System.Drawing.Point(0, 0);
			this.pnlInfo.Name = "pnlInfo";
			this.pnlInfo.Size = new System.Drawing.Size(465, 71);
			this.pnlInfo.TabIndex = 0;
			// 
			// lblDescription
			// 
			this.lblDescription.AutoSize = true;
			this.lblDescription.Location = new System.Drawing.Point(15, 40);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(172, 13);
			this.lblDescription.TabIndex = 1;
			this.lblDescription.Text = "Description of current Wizzard step";
			// 
			// lblHeadline
			// 
			this.lblHeadline.AutoSize = true;
			this.lblHeadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHeadline.Location = new System.Drawing.Point(14, 11);
			this.lblHeadline.Name = "lblHeadline";
			this.lblHeadline.Size = new System.Drawing.Size(86, 20);
			this.lblHeadline.TabIndex = 0;
			this.lblHeadline.Text = "HeadLine";
			// 
			// pnlContent
			// 
			this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlContent.Location = new System.Drawing.Point(0, 71);
			this.pnlContent.Name = "pnlContent";
			this.pnlContent.Size = new System.Drawing.Size(465, 226);
			this.pnlContent.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Location = new System.Drawing.Point(3, 56);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(459, 10);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			// 
			// InitKinectWizzardControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.pnlContent);
			this.Controls.Add(this.pnlInfo);
			this.Name = "InitKinectWizzardControl";
			this.Size = new System.Drawing.Size(465, 297);
			this.pnlInfo.ResumeLayout(false);
			this.pnlInfo.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlInfo;
		protected System.Windows.Forms.Label lblDescription;
		protected System.Windows.Forms.Label lblHeadline;
		protected System.Windows.Forms.Panel pnlContent;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
