using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Touchdown.Core;
using Touchdown.SensorAbstraction;
using InitWizzard = Touchdown.Win.UI.UserControls.InitWizzard.InitKinectWizzardControl;

namespace Touchdown.Win.UI {
	public partial class frmDemo : Form {
		private Dictionary<string, object> info;
		
		private AreaFilter touchProvider;
		private IKinectSensorProvider sensor;
		private int frameCount;
		//private PatternRecognizer recognizer;

		private Timer updateLabelTimer = new Timer();

		public frmDemo(Dictionary<string, object> info) {
			InitializeComponent();
			this.info = info;
			this.sensor = info[InitWizzard.INFOKEY_SENSOR] as IKinectSensorProvider;
			
			var backgroundModel = info[InitWizzard.INFOKEY_BACKGROUND_MODEL] as DepthFrame;
			var area =  (Rectangle)info[InitWizzard.INFOKEY_TOUCHAREA];

			var touchSettings = new TouchSettings();
			touchSettings.MinContourLength = 15;
			touchSettings.MaxContourLength = 150;
			touchSettings.MinDistanceFromBackround = 7;
			touchSettings.MaxDistanceFromBackground = 35;
			touchSettings.ContourThreshold = 5;

			var observer = new SimpleTouchAreaObserver(sensor, touchSettings, backgroundModel);
			this.touchProvider = new AreaFilter(observer, area, true);
			this.touchProvider.TouchFrameReady += UpdateTouchFrameVisualization;


			updateLabelTimer = new Timer();
			updateLabelTimer.Interval = 1000;
			updateLabelTimer.Tick += (s,e) => UpdateLabels();
			updateLabelTimer.Start();
		}

		private void UpdateTouchFrameVisualization(object sender, TouchFrameReadyEventArgs e) {
			if (this.Visible) {
				this.frameCount = 0;
				pbTouchPoints.Image = e.FrameData.CreateBitmap();
			}
			frameCount++;

			if (e.FrameData.TouchPoints.Count > 0) { 
				//pbTouchPoints.Image.Save("C:\\tmp\\test.bmp");
			}

		}

		private void UpdateLabels(){
			SetLabelIsRunning(this.sensor.IsRunning);
			SetLabelColorFPS(this.sensor.ColorFPS);
			SetLabelDepthFPS(this.sensor.DepthFPS);
			//SetLabelRegisteredPatterns(this.PatterRecognicer.RegisteredPatterns.Count);
		}



		private void SetLabelIsRunning(bool isrunning){
			lblSensorStatus.Text = isrunning ? "running" : "stopped";
		}
		private void SetLabelColorFPS(int fps){
			lblColorFPS.Text = String.Format("Color FPS: {0}", fps);
		}
		private void SetLabelDepthFPS(int fps){
			lblDepthFPS.Text = String.Format("Depth FPS: {0}", fps);
		}
		private void SetLabelRegisteredPatterns(int count){
			lblPatternsRegistered.Text = "Registered Patterns: {0}";
		}

		private void btnStart_Click(object sender, EventArgs e) {
			if (this.sensor.IsRunning) {
				this.sensor.Stop();
				btnStart.Text = "Start";
			} else { 
				this.sensor.Start();
				btnStart.Text = "Stop";
			}

		}
	}
}
