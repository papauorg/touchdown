namespace Touchdown.Win.UI {
	partial class frmDemo {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDemo));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lblDepthFPS = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblColorFPS = new System.Windows.Forms.ToolStripStatusLabel();
			this.grpTouchpoints = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.pbTouchPoints = new System.Windows.Forms.PictureBox();
			this.grpLastGesture = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.pbLastGesture = new System.Windows.Forms.PictureBox();
			this.btnNewGesture = new System.Windows.Forms.Button();
			this.tbGestureName = new System.Windows.Forms.TextBox();
			this.lastRecognized = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.lblGestureName = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.pbRecognized = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblSensorStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblPatternsRegistered = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusStrip1.SuspendLayout();
			this.grpTouchpoints.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbTouchPoints)).BeginInit();
			this.grpLastGesture.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbLastGesture)).BeginInit();
			this.lastRecognized.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbRecognized)).BeginInit();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSensorStatus,
            this.lblDepthFPS,
            this.lblColorFPS,
            this.lblPatternsRegistered});
			this.statusStrip1.Location = new System.Drawing.Point(0, 452);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(753, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lblDepthFPS
			// 
			this.lblDepthFPS.Name = "lblDepthFPS";
			this.lblDepthFPS.Size = new System.Drawing.Size(67, 17);
			this.lblDepthFPS.Text = "Depth FPS: ";
			// 
			// lblColorFPS
			// 
			this.lblColorFPS.Name = "lblColorFPS";
			this.lblColorFPS.Size = new System.Drawing.Size(61, 17);
			this.lblColorFPS.Text = "Color FPS:";
			// 
			// grpTouchpoints
			// 
			this.grpTouchpoints.Controls.Add(this.groupBox2);
			this.grpTouchpoints.Location = new System.Drawing.Point(12, 12);
			this.grpTouchpoints.Name = "grpTouchpoints";
			this.grpTouchpoints.Size = new System.Drawing.Size(234, 210);
			this.grpTouchpoints.TabIndex = 1;
			this.grpTouchpoints.TabStop = false;
			this.grpTouchpoints.Text = "TouchPoints";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.pbTouchPoints);
			this.groupBox2.Location = new System.Drawing.Point(3, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(225, 162);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Visualize";
			// 
			// pbTouchPoints
			// 
			this.pbTouchPoints.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbTouchPoints.Location = new System.Drawing.Point(3, 16);
			this.pbTouchPoints.Name = "pbTouchPoints";
			this.pbTouchPoints.Size = new System.Drawing.Size(219, 143);
			this.pbTouchPoints.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbTouchPoints.TabIndex = 5;
			this.pbTouchPoints.TabStop = false;
			// 
			// grpLastGesture
			// 
			this.grpLastGesture.Controls.Add(this.groupBox3);
			this.grpLastGesture.Controls.Add(this.btnNewGesture);
			this.grpLastGesture.Controls.Add(this.tbGestureName);
			this.grpLastGesture.Location = new System.Drawing.Point(252, 12);
			this.grpLastGesture.Name = "grpLastGesture";
			this.grpLastGesture.Size = new System.Drawing.Size(242, 210);
			this.grpLastGesture.TabIndex = 2;
			this.grpLastGesture.TabStop = false;
			this.grpLastGesture.Text = "Last Gesture";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.pbLastGesture);
			this.groupBox3.Location = new System.Drawing.Point(6, 16);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(230, 162);
			this.groupBox3.TabIndex = 5;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Visualize";
			// 
			// pbLastGesture
			// 
			this.pbLastGesture.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbLastGesture.Location = new System.Drawing.Point(3, 16);
			this.pbLastGesture.Name = "pbLastGesture";
			this.pbLastGesture.Size = new System.Drawing.Size(224, 143);
			this.pbLastGesture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbLastGesture.TabIndex = 6;
			this.pbLastGesture.TabStop = false;
			// 
			// btnNewGesture
			// 
			this.btnNewGesture.Location = new System.Drawing.Point(173, 182);
			this.btnNewGesture.Name = "btnNewGesture";
			this.btnNewGesture.Size = new System.Drawing.Size(63, 23);
			this.btnNewGesture.TabIndex = 0;
			this.btnNewGesture.Text = "Save";
			this.btnNewGesture.UseVisualStyleBackColor = true;
			// 
			// tbGestureName
			// 
			this.tbGestureName.Location = new System.Drawing.Point(6, 184);
			this.tbGestureName.MaxLength = 20;
			this.tbGestureName.Name = "tbGestureName";
			this.tbGestureName.Size = new System.Drawing.Size(161, 20);
			this.tbGestureName.TabIndex = 1;
			// 
			// lastRecognized
			// 
			this.lastRecognized.Controls.Add(this.textBox1);
			this.lastRecognized.Controls.Add(this.lblGestureName);
			this.lastRecognized.Controls.Add(this.groupBox4);
			this.lastRecognized.Location = new System.Drawing.Point(500, 12);
			this.lastRecognized.Name = "lastRecognized";
			this.lastRecognized.Size = new System.Drawing.Size(242, 210);
			this.lastRecognized.TabIndex = 3;
			this.lastRecognized.TabStop = false;
			this.lastRecognized.Text = "Last Recognized Gesture";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(47, 184);
			this.textBox1.MaxLength = 20;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(187, 20);
			this.textBox1.TabIndex = 7;
			// 
			// lblGestureName
			// 
			this.lblGestureName.AutoSize = true;
			this.lblGestureName.Location = new System.Drawing.Point(6, 187);
			this.lblGestureName.Name = "lblGestureName";
			this.lblGestureName.Size = new System.Drawing.Size(35, 13);
			this.lblGestureName.TabIndex = 6;
			this.lblGestureName.Text = "Name";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.pbRecognized);
			this.groupBox4.Location = new System.Drawing.Point(6, 19);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(231, 156);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Visualize";
			// 
			// pbRecognized
			// 
			this.pbRecognized.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbRecognized.Location = new System.Drawing.Point(3, 16);
			this.pbRecognized.Name = "pbRecognized";
			this.pbRecognized.Size = new System.Drawing.Size(225, 137);
			this.pbRecognized.TabIndex = 7;
			this.pbRecognized.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(15, 228);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(231, 174);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Settings";
			// 
			// lblSensorStatus
			// 
			this.lblSensorStatus.Name = "lblSensorStatus";
			this.lblSensorStatus.Size = new System.Drawing.Size(80, 17);
			this.lblSensorStatus.Text = "Sensor Status:";
			// 
			// lblPatternsRegistered
			// 
			this.lblPatternsRegistered.Name = "lblPatternsRegistered";
			this.lblPatternsRegistered.Size = new System.Drawing.Size(111, 17);
			this.lblPatternsRegistered.Text = "Patterns Registered:";
			// 
			// frmDemo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(753, 474);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.lastRecognized);
			this.Controls.Add(this.grpLastGesture);
			this.Controls.Add(this.grpTouchpoints);
			this.Controls.Add(this.statusStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmDemo";
			this.Text = "Touchdown DEMO Application - Philipp Grathwohl - FTIT10";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.grpTouchpoints.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbTouchPoints)).EndInit();
			this.grpLastGesture.ResumeLayout(false);
			this.grpLastGesture.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbLastGesture)).EndInit();
			this.lastRecognized.ResumeLayout(false);
			this.lastRecognized.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbRecognized)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel lblDepthFPS;
		private System.Windows.Forms.ToolStripStatusLabel lblColorFPS;
		private System.Windows.Forms.GroupBox grpTouchpoints;
		private System.Windows.Forms.GroupBox grpLastGesture;
		private System.Windows.Forms.GroupBox lastRecognized;
		private System.Windows.Forms.Button btnNewGesture;
		private System.Windows.Forms.PictureBox pbTouchPoints;
		private System.Windows.Forms.PictureBox pbLastGesture;
		private System.Windows.Forms.PictureBox pbRecognized;
		private System.Windows.Forms.TextBox tbGestureName;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label lblGestureName;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ToolStripStatusLabel lblSensorStatus;
		private System.Windows.Forms.ToolStripStatusLabel lblPatternsRegistered;

	}
}

