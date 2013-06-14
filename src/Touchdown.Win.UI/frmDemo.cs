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
using System.Runtime.Serialization;

using InitWizzard = Touchdown.Win.UI.UserControls.InitWizzard.InitKinectWizzardControl;

namespace Touchdown.Win.UI {
	public partial class frmDemo : Form {
		private Dictionary<string, object> info;
		
		private SimpleTouchAreaObserver observer;
		private IKinectSensorProvider sensor;
		private TouchPatternRecognizer recognizer;
		private int frameCount;
		private TouchPattern lastDrawnPattern = null;
		private TouchPattern lastRecognizedPattern = null;

		private Timer updateLabelTimer = new Timer();

		public frmDemo(Dictionary<string, object> info) {
			InitializeComponent();

			tbMaxDistance.Scroll += slideInt;
			tbMinDistance.Scroll += slideInt;
			tbGestureSeparator.Scroll += slideInt;
			tbGestureQuality.Scroll += slideDecimal;

			this.info = info;
			this.sensor = info[InitWizzard.INFOKEY_SENSOR] as IKinectSensorProvider;
			var backgroundModel = info[InitWizzard.INFOKEY_BACKGROUND_MODEL] as DepthFrame;
			var area =  (Rectangle)info[InitWizzard.INFOKEY_TOUCHAREA];
			var defaultPatterns = info[InitWizzard.INFOKEY_DEFAULT_GESTURES] as List<TouchPattern>;

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
			defaultPatterns.ForEach(pat => this.recognizer.RegisterPattern(pat));
			
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
			this.lastRecognizedPattern = e.OriginalPattern;

			tbRecognizedGestureName.Text = e.OriginalPattern.Name;

			tbStartX.Text = e.StartPoint.X.ToString();
			tbStartY.Text = e.StartPoint.Y.ToString();

			tbGestureQuality.Text = Math.Round(e.RecognitionQuality, 2).ToString("n2");
			
			tbFramesOrig.Text = e.OriginalPattern.Frames.Count.ToString();
			tbFramesNew.Text  = e.RecognizedPattern.Frames.Count.ToString();

		}

		void recognizer_TouchPatternRecording(object sender, TouchPatternRecordingEventArgs e) {
			if (this.Visible && e.Frame.TouchPoints.Count > 0) { 
				pbLastGesture.Image = e.Pattern.CreateBitmap();
				this.lastDrawnPattern = e.Pattern.Normalize();
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
			SetLabelRegisteredPatterns(this.recognizer.RegisteredPatterns.Count);
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

		private void btnNewGesture_Click(object sender, EventArgs e) {
			if (this.lastDrawnPattern != null) { 
				lastDrawnPattern.Name = this.tbGestureName.Text;
				this.recognizer.RegisterPattern(this.lastDrawnPattern);
				this.tbGestureName.Text = String.Empty;
			}
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e) {
			if (this.sensor.IsRunning) {
				this.sensor.Stop();
				toolStripMenuItem1.Text = "Start";
			} else { 
				this.sensor.Start();
				toolStripMenuItem1.Text = "Stop";
			}
		}

		private void slideDecimal(object sender, EventArgs e){
			var bar = sender as TrackBar;

			toolTip1.SetToolTip(bar, Math.Round((double)bar.Value / 10, 1).ToString("n1"));
		}

		private void slideInt(object sender, EventArgs e){
			var bar = sender as TrackBar;

			toolTip1.SetToolTip(bar, bar.Value.ToString());
		}

		private void tbMinDistance_Scroll(object sender, EventArgs e) {
			this.observer.Settings.MinDistanceFromBackround = (uint)tbMinDistance.Value;
		}

		private void tbMaxDistance_Scroll(object sender, EventArgs e) {
			this.observer.Settings.MaxDistanceFromBackground = (uint)tbMaxDistance.Value;
		}

		private void tbGestureSeparator_Scroll(object sender, EventArgs e) {
			this.recognizer.MaxConsecutiveNullFrames = tbGestureSeparator.Value;
		}

		private void tbGestureQuality_Scroll(object sender, EventArgs e) {
			this.recognizer.MaxDistancePerPixel = (double)tbGestureQuality.Value / 10;
		}

		private void btnPersist_Click(object sender, EventArgs e) {
			if (lastRecognizedPattern == null) { 
				return;
			}

			using (SaveFileDialog dia = new SaveFileDialog()) { 
				dia.OverwritePrompt = true;
				dia.RestoreDirectory =  true;
				dia.ValidateNames = true;
				dia.Title = "Save Gesture";
				dia.Filter = "*.pat|Touchdown Gesture";
				dia.SupportMultiDottedExtensions = true;
				
				if (dia.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
					using (var stream = new System.IO.FileStream(dia.FileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)) {
						using (var writer = new System.IO.StreamWriter(stream)) { 
							writer.Write(lastRecognizedPattern.Save());
							writer.Flush();
						}
					}
				}
			}
		}
	}
}
