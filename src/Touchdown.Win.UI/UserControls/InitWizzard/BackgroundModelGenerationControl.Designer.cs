namespace Touchdown.Win.UI.UserControls.InitWizzard {
	partial class BackgroundModelGenerationControl {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackgroundModelGenerationControl));
			this.label1 = new System.Windows.Forms.Label();
			this.progBackground = new System.Windows.Forms.ProgressBar();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.numFrameCount = new System.Windows.Forms.NumericUpDown();
			this.lblFrameCount = new System.Windows.Forms.Label();
			this.pnlContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numFrameCount)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlContent
			// 
			this.pnlContent.Controls.Add(this.lblFrameCount);
			this.pnlContent.Controls.Add(this.numFrameCount);
			this.pnlContent.Controls.Add(this.btnGenerate);
			this.pnlContent.Controls.Add(this.progBackground);
			this.pnlContent.Controls.Add(this.label1);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(335, 78);
			this.label1.TabIndex = 0;
			this.label1.Text = resources.GetString("label1.Text");
			// 
			// progBackground
			// 
			this.progBackground.Location = new System.Drawing.Point(18, 187);
			this.progBackground.Name = "progBackground";
			this.progBackground.Size = new System.Drawing.Size(434, 23);
			this.progBackground.TabIndex = 1;
			// 
			// btnGenerate
			// 
			this.btnGenerate.Location = new System.Drawing.Point(140, 158);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(75, 23);
			this.btnGenerate.TabIndex = 2;
			this.btnGenerate.Text = "Generate";
			this.btnGenerate.UseVisualStyleBackColor = true;
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			// 
			// numFrameCount
			// 
			this.numFrameCount.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.numFrameCount.Location = new System.Drawing.Point(67, 161);
			this.numFrameCount.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.numFrameCount.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.numFrameCount.Name = "numFrameCount";
			this.numFrameCount.Size = new System.Drawing.Size(67, 20);
			this.numFrameCount.TabIndex = 3;
			this.numFrameCount.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
			// 
			// lblFrameCount
			// 
			this.lblFrameCount.AutoSize = true;
			this.lblFrameCount.Location = new System.Drawing.Point(20, 163);
			this.lblFrameCount.Name = "lblFrameCount";
			this.lblFrameCount.Size = new System.Drawing.Size(41, 13);
			this.lblFrameCount.TabIndex = 4;
			this.lblFrameCount.Text = "Frames";
			// 
			// BackgroundModelGenerationControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Name = "BackgroundModelGenerationControl";
			this.pnlContent.ResumeLayout(false);
			this.pnlContent.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numFrameCount)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.ProgressBar progBackground;
		private System.Windows.Forms.Label lblFrameCount;
		private System.Windows.Forms.NumericUpDown numFrameCount;
	}
}
