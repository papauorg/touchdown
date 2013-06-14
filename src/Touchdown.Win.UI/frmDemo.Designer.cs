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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDemo));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lblSensorStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblDepthFPS = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblColorFPS = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblTouchFPS = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblPatternsRegistered = new System.Windows.Forms.ToolStripStatusLabel();
			this.grpTouchpoints = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.pbTouchPoints = new System.Windows.Forms.PictureBox();
			this.grpLastGesture = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.pbLastGesture = new System.Windows.Forms.PictureBox();
			this.btnNewGesture = new System.Windows.Forms.Button();
			this.tbGestureName = new System.Windows.Forms.TextBox();
			this.lastRecognized = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tbFramesNew = new System.Windows.Forms.TextBox();
			this.tbFramesOrig = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.lblQuality = new System.Windows.Forms.Label();
			this.tbStartY = new System.Windows.Forms.TextBox();
			this.tbStartX = new System.Windows.Forms.TextBox();
			this.lblStart = new System.Windows.Forms.Label();
			this.tbRecognizedGestureName = new System.Windows.Forms.TextBox();
			this.lblGestureName = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.pbRecognized = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tbGestureQuality = new System.Windows.Forms.TrackBar();
			this.tbGestureSeparator = new System.Windows.Forms.TrackBar();
			this.gbTouchSettings = new System.Windows.Forms.GroupBox();
			this.tbMaxDistance = new System.Windows.Forms.TrackBar();
			this.tbMinDistance = new System.Windows.Forms.TrackBar();
			this.lblMaxDistance = new System.Windows.Forms.Label();
			this.lblMinDist = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.sensorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.btnPersist = new System.Windows.Forms.Button();
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
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbGestureQuality)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbGestureSeparator)).BeginInit();
			this.gbTouchSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbMaxDistance)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbMinDistance)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSensorStatus,
            this.lblDepthFPS,
            this.lblColorFPS,
            this.lblTouchFPS,
            this.lblPatternsRegistered});
			this.statusStrip1.Location = new System.Drawing.Point(0, 478);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(666, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lblSensorStatus
			// 
			this.lblSensorStatus.Name = "lblSensorStatus";
			this.lblSensorStatus.Size = new System.Drawing.Size(80, 17);
			this.lblSensorStatus.Text = "Sensor Status:";
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
			// lblTouchFPS
			// 
			this.lblTouchFPS.Name = "lblTouchFPS";
			this.lblTouchFPS.Size = new System.Drawing.Size(69, 17);
			this.lblTouchFPS.Text = "Touch FPS: ";
			// 
			// lblPatternsRegistered
			// 
			this.lblPatternsRegistered.Name = "lblPatternsRegistered";
			this.lblPatternsRegistered.Size = new System.Drawing.Size(111, 17);
			this.lblPatternsRegistered.Text = "Patterns Registered:";
			// 
			// grpTouchpoints
			// 
			this.grpTouchpoints.Controls.Add(this.groupBox2);
			this.grpTouchpoints.Location = new System.Drawing.Point(12, 31);
			this.grpTouchpoints.Name = "grpTouchpoints";
			this.grpTouchpoints.Size = new System.Drawing.Size(208, 200);
			this.grpTouchpoints.TabIndex = 1;
			this.grpTouchpoints.TabStop = false;
			this.grpTouchpoints.Text = "TouchPoints";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.pbTouchPoints);
			this.groupBox2.Location = new System.Drawing.Point(3, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(200, 150);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Visualization";
			// 
			// pbTouchPoints
			// 
			this.pbTouchPoints.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbTouchPoints.Location = new System.Drawing.Point(3, 16);
			this.pbTouchPoints.Name = "pbTouchPoints";
			this.pbTouchPoints.Size = new System.Drawing.Size(194, 131);
			this.pbTouchPoints.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbTouchPoints.TabIndex = 5;
			this.pbTouchPoints.TabStop = false;
			// 
			// grpLastGesture
			// 
			this.grpLastGesture.Controls.Add(this.groupBox3);
			this.grpLastGesture.Controls.Add(this.btnNewGesture);
			this.grpLastGesture.Controls.Add(this.tbGestureName);
			this.grpLastGesture.Location = new System.Drawing.Point(226, 31);
			this.grpLastGesture.Name = "grpLastGesture";
			this.grpLastGesture.Size = new System.Drawing.Size(212, 200);
			this.grpLastGesture.TabIndex = 2;
			this.grpLastGesture.TabStop = false;
			this.grpLastGesture.Text = "Last Gesture";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.pbLastGesture);
			this.groupBox3.Location = new System.Drawing.Point(6, 16);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(200, 150);
			this.groupBox3.TabIndex = 5;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Visualization";
			// 
			// pbLastGesture
			// 
			this.pbLastGesture.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbLastGesture.Location = new System.Drawing.Point(3, 16);
			this.pbLastGesture.Name = "pbLastGesture";
			this.pbLastGesture.Size = new System.Drawing.Size(194, 131);
			this.pbLastGesture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbLastGesture.TabIndex = 6;
			this.pbLastGesture.TabStop = false;
			// 
			// btnNewGesture
			// 
			this.btnNewGesture.Location = new System.Drawing.Point(140, 169);
			this.btnNewGesture.Name = "btnNewGesture";
			this.btnNewGesture.Size = new System.Drawing.Size(63, 23);
			this.btnNewGesture.TabIndex = 0;
			this.btnNewGesture.Text = "Save";
			this.btnNewGesture.UseVisualStyleBackColor = true;
			this.btnNewGesture.Click += new System.EventHandler(this.btnNewGesture_Click);
			// 
			// tbGestureName
			// 
			this.tbGestureName.Location = new System.Drawing.Point(9, 171);
			this.tbGestureName.MaxLength = 20;
			this.tbGestureName.Name = "tbGestureName";
			this.tbGestureName.Size = new System.Drawing.Size(125, 20);
			this.tbGestureName.TabIndex = 1;
			// 
			// lastRecognized
			// 
			this.lastRecognized.Controls.Add(this.btnPersist);
			this.lastRecognized.Controls.Add(this.label5);
			this.lastRecognized.Controls.Add(this.label4);
			this.lastRecognized.Controls.Add(this.tbFramesNew);
			this.lastRecognized.Controls.Add(this.tbFramesOrig);
			this.lastRecognized.Controls.Add(this.label3);
			this.lastRecognized.Controls.Add(this.textBox1);
			this.lastRecognized.Controls.Add(this.lblQuality);
			this.lastRecognized.Controls.Add(this.tbStartY);
			this.lastRecognized.Controls.Add(this.tbStartX);
			this.lastRecognized.Controls.Add(this.lblStart);
			this.lastRecognized.Controls.Add(this.tbRecognizedGestureName);
			this.lastRecognized.Controls.Add(this.lblGestureName);
			this.lastRecognized.Controls.Add(this.groupBox4);
			this.lastRecognized.Location = new System.Drawing.Point(444, 35);
			this.lastRecognized.Name = "lastRecognized";
			this.lastRecognized.Size = new System.Drawing.Size(214, 307);
			this.lastRecognized.TabIndex = 3;
			this.lastRecognized.TabStop = false;
			this.lastRecognized.Text = "Last Recognized Gesture";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(150, 257);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(12, 13);
			this.label5.TabIndex = 19;
			this.label5.Text = "/";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(150, 205);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(12, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "/";
			// 
			// tbFramesNew
			// 
			this.tbFramesNew.Location = new System.Drawing.Point(163, 254);
			this.tbFramesNew.Name = "tbFramesNew";
			this.tbFramesNew.ReadOnly = true;
			this.tbFramesNew.Size = new System.Drawing.Size(40, 20);
			this.tbFramesNew.TabIndex = 15;
			// 
			// tbFramesOrig
			// 
			this.tbFramesOrig.Location = new System.Drawing.Point(107, 254);
			this.tbFramesOrig.Name = "tbFramesOrig";
			this.tbFramesOrig.ReadOnly = true;
			this.tbFramesOrig.Size = new System.Drawing.Size(40, 20);
			this.tbFramesOrig.TabIndex = 14;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(4, 257);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(92, 13);
			this.label3.TabIndex = 13;
			this.label3.Text = "Frames (orig/new)";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(107, 228);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(96, 20);
			this.textBox1.TabIndex = 12;
			// 
			// lblQuality
			// 
			this.lblQuality.AutoSize = true;
			this.lblQuality.Location = new System.Drawing.Point(4, 231);
			this.lblQuality.Name = "lblQuality";
			this.lblQuality.Size = new System.Drawing.Size(39, 13);
			this.lblQuality.TabIndex = 11;
			this.lblQuality.Text = "Quality";
			// 
			// tbStartY
			// 
			this.tbStartY.Location = new System.Drawing.Point(163, 202);
			this.tbStartY.Name = "tbStartY";
			this.tbStartY.ReadOnly = true;
			this.tbStartY.Size = new System.Drawing.Size(40, 20);
			this.tbStartY.TabIndex = 10;
			// 
			// tbStartX
			// 
			this.tbStartX.Location = new System.Drawing.Point(107, 202);
			this.tbStartX.Name = "tbStartX";
			this.tbStartX.ReadOnly = true;
			this.tbStartX.Size = new System.Drawing.Size(40, 20);
			this.tbStartX.TabIndex = 9;
			// 
			// lblStart
			// 
			this.lblStart.AutoSize = true;
			this.lblStart.Location = new System.Drawing.Point(4, 205);
			this.lblStart.Name = "lblStart";
			this.lblStart.Size = new System.Drawing.Size(51, 13);
			this.lblStart.TabIndex = 8;
			this.lblStart.Text = "Start X/Y";
			// 
			// tbRecognizedGestureName
			// 
			this.tbRecognizedGestureName.Location = new System.Drawing.Point(107, 176);
			this.tbRecognizedGestureName.MaxLength = 20;
			this.tbRecognizedGestureName.Name = "tbRecognizedGestureName";
			this.tbRecognizedGestureName.ReadOnly = true;
			this.tbRecognizedGestureName.Size = new System.Drawing.Size(96, 20);
			this.tbRecognizedGestureName.TabIndex = 7;
			// 
			// lblGestureName
			// 
			this.lblGestureName.AutoSize = true;
			this.lblGestureName.Location = new System.Drawing.Point(4, 179);
			this.lblGestureName.Name = "lblGestureName";
			this.lblGestureName.Size = new System.Drawing.Size(35, 13);
			this.lblGestureName.TabIndex = 6;
			this.lblGestureName.Text = "Name";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.pbRecognized);
			this.groupBox4.Location = new System.Drawing.Point(6, 16);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(200, 150);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Visualization";
			// 
			// pbRecognized
			// 
			this.pbRecognized.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbRecognized.Location = new System.Drawing.Point(3, 16);
			this.pbRecognized.Name = "pbRecognized";
			this.pbRecognized.Size = new System.Drawing.Size(194, 131);
			this.pbRecognized.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbRecognized.TabIndex = 7;
			this.pbRecognized.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.tbGestureQuality);
			this.groupBox1.Controls.Add(this.tbGestureSeparator);
			this.groupBox1.Location = new System.Drawing.Point(12, 348);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(426, 120);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Gesture Settings";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 67);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(118, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Max. Distance per Pixel";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 26);
			this.label1.TabIndex = 7;
			this.label1.Text = "Null-Frames Count \r\n(Gesture Separation)\r\n";
			// 
			// tbGestureQuality
			// 
			this.tbGestureQuality.LargeChange = 2;
			this.tbGestureQuality.Location = new System.Drawing.Point(131, 67);
			this.tbGestureQuality.Maximum = 200;
			this.tbGestureQuality.Name = "tbGestureQuality";
			this.tbGestureQuality.Size = new System.Drawing.Size(286, 45);
			this.tbGestureQuality.TabIndex = 6;
			this.tbGestureQuality.TickFrequency = 10;
			this.tbGestureQuality.Value = 75;
			this.tbGestureQuality.Scroll += new System.EventHandler(this.tbGestureQuality_Scroll);
			// 
			// tbGestureSeparator
			// 
			this.tbGestureSeparator.LargeChange = 1;
			this.tbGestureSeparator.Location = new System.Drawing.Point(131, 16);
			this.tbGestureSeparator.Minimum = 1;
			this.tbGestureSeparator.Name = "tbGestureSeparator";
			this.tbGestureSeparator.Size = new System.Drawing.Size(289, 45);
			this.tbGestureSeparator.TabIndex = 5;
			this.tbGestureSeparator.Value = 5;
			this.tbGestureSeparator.Scroll += new System.EventHandler(this.tbGestureSeparator_Scroll);
			// 
			// gbTouchSettings
			// 
			this.gbTouchSettings.Controls.Add(this.tbMaxDistance);
			this.gbTouchSettings.Controls.Add(this.tbMinDistance);
			this.gbTouchSettings.Controls.Add(this.lblMaxDistance);
			this.gbTouchSettings.Controls.Add(this.lblMinDist);
			this.gbTouchSettings.Location = new System.Drawing.Point(12, 237);
			this.gbTouchSettings.Name = "gbTouchSettings";
			this.gbTouchSettings.Size = new System.Drawing.Size(426, 105);
			this.gbTouchSettings.TabIndex = 6;
			this.gbTouchSettings.TabStop = false;
			this.gbTouchSettings.Text = "Touch Settings";
			// 
			// tbMaxDistance
			// 
			this.tbMaxDistance.LargeChange = 1;
			this.tbMaxDistance.Location = new System.Drawing.Point(131, 50);
			this.tbMaxDistance.Maximum = 30;
			this.tbMaxDistance.Minimum = 15;
			this.tbMaxDistance.Name = "tbMaxDistance";
			this.tbMaxDistance.Size = new System.Drawing.Size(286, 45);
			this.tbMaxDistance.TabIndex = 7;
			this.tbMaxDistance.Value = 25;
			this.tbMaxDistance.Scroll += new System.EventHandler(this.tbMaxDistance_Scroll);
			// 
			// tbMinDistance
			// 
			this.tbMinDistance.LargeChange = 1;
			this.tbMinDistance.Location = new System.Drawing.Point(131, 12);
			this.tbMinDistance.Maximum = 15;
			this.tbMinDistance.Minimum = 1;
			this.tbMinDistance.Name = "tbMinDistance";
			this.tbMinDistance.Size = new System.Drawing.Size(286, 45);
			this.tbMinDistance.TabIndex = 6;
			this.tbMinDistance.Value = 7;
			this.tbMinDistance.Scroll += new System.EventHandler(this.tbMinDistance_Scroll);
			// 
			// lblMaxDistance
			// 
			this.lblMaxDistance.AutoSize = true;
			this.lblMaxDistance.Location = new System.Drawing.Point(3, 61);
			this.lblMaxDistance.Name = "lblMaxDistance";
			this.lblMaxDistance.Size = new System.Drawing.Size(75, 13);
			this.lblMaxDistance.TabIndex = 1;
			this.lblMaxDistance.Text = "Max. Distance";
			// 
			// lblMinDist
			// 
			this.lblMinDist.AutoSize = true;
			this.lblMinDist.Location = new System.Drawing.Point(6, 16);
			this.lblMinDist.Name = "lblMinDist";
			this.lblMinDist.Size = new System.Drawing.Size(72, 13);
			this.lblMinDist.TabIndex = 0;
			this.lblMinDist.Text = "Min. Distance";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sensorToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(666, 24);
			this.menuStrip1.TabIndex = 7;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// sensorToolStripMenuItem
			// 
			this.sensorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
			this.sensorToolStripMenuItem.Name = "sensorToolStripMenuItem";
			this.sensorToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
			this.sensorToolStripMenuItem.Text = "Sensor";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
			this.toolStripMenuItem1.Text = "Start";
			this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
			// 
			// btnPersist
			// 
			this.btnPersist.Location = new System.Drawing.Point(6, 278);
			this.btnPersist.Name = "btnPersist";
			this.btnPersist.Size = new System.Drawing.Size(197, 23);
			this.btnPersist.TabIndex = 20;
			this.btnPersist.Text = "Save To File";
			this.btnPersist.UseVisualStyleBackColor = true;
			this.btnPersist.Click += new System.EventHandler(this.btnPersist_Click);
			// 
			// frmDemo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(666, 500);
			this.Controls.Add(this.gbTouchSettings);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.lastRecognized);
			this.Controls.Add(this.grpLastGesture);
			this.Controls.Add(this.grpTouchpoints);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
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
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbGestureQuality)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbGestureSeparator)).EndInit();
			this.gbTouchSettings.ResumeLayout(false);
			this.gbTouchSettings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbMaxDistance)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbMinDistance)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
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
		private System.Windows.Forms.TextBox tbRecognizedGestureName;
		private System.Windows.Forms.Label lblGestureName;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ToolStripStatusLabel lblSensorStatus;
		private System.Windows.Forms.ToolStripStatusLabel lblPatternsRegistered;
		private System.Windows.Forms.ToolStripStatusLabel lblTouchFPS;
		private System.Windows.Forms.TrackBar tbGestureSeparator;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TrackBar tbGestureQuality;
		private System.Windows.Forms.GroupBox gbTouchSettings;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem sensorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TrackBar tbMinDistance;
		private System.Windows.Forms.Label lblMaxDistance;
		private System.Windows.Forms.Label lblMinDist;
		private System.Windows.Forms.TrackBar tbMaxDistance;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label lblQuality;
		private System.Windows.Forms.TextBox tbStartY;
		private System.Windows.Forms.TextBox tbStartX;
		private System.Windows.Forms.Label lblStart;
		private System.Windows.Forms.TextBox tbFramesNew;
		private System.Windows.Forms.TextBox tbFramesOrig;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnPersist;

	}
}

