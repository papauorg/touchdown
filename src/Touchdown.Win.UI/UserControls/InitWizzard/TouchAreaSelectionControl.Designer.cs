namespace Touchdown.Win.UI.UserControls.InitWizzard {
	partial class TouchAreaSelectionControl {
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
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.pbChooseArea = new System.Windows.Forms.PictureBox();
			this.rbWholeArea = new System.Windows.Forms.RadioButton();
			this.rbSpecificArea = new System.Windows.Forms.RadioButton();
			this.btnReset = new System.Windows.Forms.Button();
			this.rbAll = new System.Windows.Forms.RadioButton();
			this.pnlContent.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbChooseArea)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlContent
			// 
			this.pnlContent.Controls.Add(this.btnReset);
			this.pnlContent.Controls.Add(this.rbSpecificArea);
			this.pnlContent.Controls.Add(this.rbWholeArea);
			this.pnlContent.Controls.Add(this.groupBox2);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.pbChooseArea);
			this.groupBox2.Location = new System.Drawing.Point(18, 52);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(240, 162);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Choose area";
			// 
			// pbChooseArea
			// 
			this.pbChooseArea.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbChooseArea.Location = new System.Drawing.Point(3, 16);
			this.pbChooseArea.Name = "pbChooseArea";
			this.pbChooseArea.Size = new System.Drawing.Size(234, 143);
			this.pbChooseArea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbChooseArea.TabIndex = 0;
			this.pbChooseArea.TabStop = false;
			// 
			// rbWholeArea
			// 
			this.rbWholeArea.AutoSize = true;
			this.rbWholeArea.Checked = true;
			this.rbWholeArea.Location = new System.Drawing.Point(21, 4);
			this.rbWholeArea.Name = "rbWholeArea";
			this.rbWholeArea.Size = new System.Drawing.Size(117, 17);
			this.rbWholeArea.TabIndex = 1;
			this.rbWholeArea.TabStop = true;
			this.rbWholeArea.Text = "Use the whole area";
			this.rbWholeArea.UseVisualStyleBackColor = true;
			// 
			// rbSpecificArea
			// 
			this.rbSpecificArea.AutoSize = true;
			this.rbSpecificArea.Location = new System.Drawing.Point(21, 29);
			this.rbSpecificArea.Name = "rbSpecificArea";
			this.rbSpecificArea.Size = new System.Drawing.Size(124, 17);
			this.rbSpecificArea.TabIndex = 2;
			this.rbSpecificArea.Text = "Choose specific area";
			this.rbSpecificArea.UseVisualStyleBackColor = true;
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(264, 188);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(75, 23);
			this.btnReset.TabIndex = 3;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			// 
			// rbAll
			// 
			this.rbAll.AutoSize = true;
			this.rbAll.Checked = true;
			this.rbAll.Location = new System.Drawing.Point(21, 4);
			this.rbAll.Name = "rbAll";
			this.rbAll.Size = new System.Drawing.Size(117, 17);
			this.rbAll.TabIndex = 1;
			this.rbAll.TabStop = true;
			this.rbAll.Text = "Use the whole area";
			this.rbAll.UseVisualStyleBackColor = true;
			// 
			// TouchAreaSelectionControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Name = "TouchAreaSelectionControl";
			this.pnlContent.ResumeLayout(false);
			this.pnlContent.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbChooseArea)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.PictureBox pbChooseArea;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.RadioButton rbSpecificArea;
		private System.Windows.Forms.RadioButton rbWholeArea;
		private System.Windows.Forms.RadioButton rbAll;

	}
}
