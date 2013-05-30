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
		//private PatternRecognizer recognizer;

		public frmDemo(Dictionary<string, object> info) {
			InitializeComponent();
			this.info = info;
			this.sensor = info[InitWizzard.INFOKEY_SENSOR] as IKinectSensorProvider;
			
			var backgroundModel = info[InitWizzard.INFOKEY_BACKGROUND_MODEL] as DepthFrame;
			var area =  (Rectangle)info[InitWizzard.INFOKEY_TOUCHAREA];
			var observer = new SimpleTouchAreaObserver(sensor, new TouchSettings(), backgroundModel);
			this.touchProvider = new AreaFilter(observer, area, true);
			this.touchProvider.TouchFrameReady += UpdateTouchFrameVisualization;
			
			UpdateLabels();
		}

		private void UpdateTouchFrameVisualization(object sender, TouchFrameReadyEventArgs e) {
			if (this.Visible){
				pbTouchPoints.Image = e.FrameData.CreateBitmap();
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
	}
}
