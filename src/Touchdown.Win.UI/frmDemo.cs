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
using Touchdown.Core.PatternRecognition;

using InitWizzard = Touchdown.Win.UI.UserControls.InitWizzard.InitKinectWizzardControl;

namespace Touchdown.Win.UI {
	public partial class frmDemo : Form {
		private Dictionary<string, object> info;
		
		private SimpleTouchAreaObserver observer;
		private IKinectSensorProvider sensor;
		private TouchPatternRecognizer recognizer;
		private int frameCount;
		private TouchPattern lastDrawnPattern = null;

		private Timer updateLabelTimer = new Timer();

		public frmDemo(Dictionary<string, object> info) {
			InitializeComponent();
			this.info = info;
			this.sensor = info[InitWizzard.INFOKEY_SENSOR] as IKinectSensorProvider;
			var backgroundModel = info[InitWizzard.INFOKEY_BACKGROUND_MODEL] as DepthFrame;
			var area =  (Rectangle)info[InitWizzard.INFOKEY_TOUCHAREA];

			this.sensor.SetArea(area);

			var touchSettings = new TouchSettings();
			touchSettings.MinContourLength = 30;
			touchSettings.MaxContourLength = 50;
			touchSettings.MinDistanceFromBackround = 7;
			touchSettings.MaxDistanceFromBackground = 25;

			this.observer = new SimpleTouchAreaObserver(sensor, touchSettings, backgroundModel);
			this.observer.TouchFrameReady += UpdateTouchFrameVisualization;

			var comparer = new SimpleTouchPatternComparer(new SimpleTouchFrameComparer(new EucledianDistanceProvider()));
			this.recognizer = new TouchPatternRecognizer(this.observer, comparer, 7.5, 5);
			this.recognizer.TouchPatternRecording += recognizer_TouchPatternRecording;
			this.recognizer.TouchPatternRecognized += recognizer_TouchPatternRecognized;
			this.recognizer.TouchPatternPartiallyRecognized += recognizer_TouchPatternRecognized;

			updateLabelTimer = new Timer();
			updateLabelTimer.Interval = 1000;
			updateLabelTimer.Tick += (s,e) => UpdateLabels();
			updateLabelTimer.Start();
		}

		void recognizer_TouchPatternRecognized(object sender, TouchPatternRecognizedEventArgs e) {
			if (this.Visible) {
				pbRecognized.Image = e.OriginalPattern.CreateBitmap();
			}
		}

		void recognizer_TouchPatternRecording(object sender, TouchPatternRecordingEventArgs e) {
			if (this.Visible && e.Frame.TouchPoints.Count > 0) { 
				pbLastGesture.Image = e.Pattern.CreateBitmap();
				this.lastDrawnPattern = e.Pattern;
				this.tbGestureName.Text = "";
			}
		}

		private void UpdateTouchFrameVisualization(object sender, FrameReadyEventArgs<SimpleTouchFrame> e) {
			if (this.Visible) {
				this.frameCount = 0;
				pbTouchPoints.Image = e.FrameData.CreateBitmap();
			}

			frameCount++;
		}

		private void UpdateLabels(){
			SetLabelIsRunning(this.sensor.IsRunning);
			SetLabelColorFPS(this.sensor.ColorFPS);
			SetLabelDepthFPS(this.sensor.DepthFPS);
			SetLabelTouchFPS(this.observer.TouchFPS);
			SetLabelRegisteredPatterns(this.recognizer.RegisteredPatters.Count);
		}



		private void SetLabelIsRunning(bool isrunning){
			lblSensorStatus.Text = isrunning ? "running" : "stopped";
		}
		private void SetLabelTouchFPS(int fps){
			lblTouchFPS.Text = String.Format("Touch FPS: {0}", fps);
		}
		private void SetLabelColorFPS(int fps){
			lblColorFPS.Text = String.Format("Color FPS: {0}", fps);
		}
		private void SetLabelDepthFPS(int fps){
			lblDepthFPS.Text = String.Format("Depth FPS: {0}", fps);
		}
		private void SetLabelRegisteredPatterns(int count){
			lblPatternsRegistered.Text = String.Format("Registered Patterns: {0}", count);
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
