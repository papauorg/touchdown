﻿namespace Touchdown.Win.UI.UserControls.InitWizzard {
	partial class FinishInitWizzardControl {
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
			this.label1 = new System.Windows.Forms.Label();
			this.pnlContent.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlContent
			// 
			this.pnlContent.Controls.Add(this.label1);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(215, 39);
			this.label1.TabIndex = 0;
			this.label1.Text = "Configuration is complete. \r\n\r\nClick \"Next\" to start the DEMO Programm ...";
			// 
			// FinishInitWizzardControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Name = "FinishInitWizzardControl";
			this.pnlContent.ResumeLayout(false);
			this.pnlContent.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
	}
}
