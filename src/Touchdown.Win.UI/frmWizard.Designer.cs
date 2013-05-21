namespace Touchdown.Win.UI {
	partial class frmWizard {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.pnlWizardContainer = new System.Windows.Forms.Panel();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// pnlWizardContainer
			// 
			this.pnlWizardContainer.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlWizardContainer.Location = new System.Drawing.Point(0, 0);
			this.pnlWizardContainer.Name = "pnlWizardContainer";
			this.pnlWizardContainer.Size = new System.Drawing.Size(496, 358);
			this.pnlWizardContainer.TabIndex = 0;
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(328, 364);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(75, 23);
			this.btnNext.TabIndex = 1;
			this.btnNext.Text = "Next";
			this.btnNext.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(409, 364);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// frmWizard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(496, 390);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.pnlWizardContainer);
			this.MaximizeBox = false;
			this.Name = "frmWizard";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Init DEMO";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlWizardContainer;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnCancel;
	}
}