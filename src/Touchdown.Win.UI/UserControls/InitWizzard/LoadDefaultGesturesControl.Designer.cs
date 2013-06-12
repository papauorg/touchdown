namespace Touchdown.Win.UI.UserControls.InitWizzard {
	partial class LoadDefaultGesturesControl {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadDefaultGesturesControl));
			this.cblGestures = new System.Windows.Forms.CheckedListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.pnlContent.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlContent
			// 
			this.pnlContent.Controls.Add(this.label1);
			this.pnlContent.Controls.Add(this.cblGestures);
			// 
			// cblGestures
			// 
			this.cblGestures.FormattingEnabled = true;
			this.cblGestures.Location = new System.Drawing.Point(18, 6);
			this.cblGestures.Name = "cblGestures";
			this.cblGestures.Size = new System.Drawing.Size(179, 199);
			this.cblGestures.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(203, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(216, 65);
			this.label1.TabIndex = 1;
			this.label1.Text = resources.GetString("label1.Text");
			// 
			// LoadDefaultGesturesControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Name = "LoadDefaultGesturesControl";
			this.pnlContent.ResumeLayout(false);
			this.pnlContent.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckedListBox cblGestures;
		private System.Windows.Forms.Label label1;
	}
}
