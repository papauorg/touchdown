using System;
using System.Windows.Forms;
using System.Drawing;
using Gtk;
using Touchdown.Core;
using Touchdown.SensorAbstraction;
using Touchdown.Freenect;

public partial class MainWindow: Gtk.Window
{	
	private SimpleTouchAreaObserver _observer;
	private TouchSettings _settings;
	private OpenKinectSensor _sensor;
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		this.Title = "Touchdown DEMO App - Technikerarbeit Philipp Grathwohl - 2012/2013";
		
		// default settings
		this._settings = new TouchSettings();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a){
		Gtk.Application.Quit ();
		a.RetVal = true;
	}

	protected void EndProgramm(object sender, EventArgs e) {
		Gtk.Application.Quit();
	}

	/// <summary>
	/// Initializes the kinect sensor.
	/// </summary>
	private void InitializeKinect(){
		// if device is present
		if (freenect.Kinect.DeviceCount > 0){
			this._sensor   = new OpenKinectSensor(new freenect.Kinect(0));
			this._sensor.DepthFrameReady += (s, e) => HandleFrameReady<DepthFrame>(e, depthImage);
			this._sensor.RGBFrameReady += (s, e) => HandleFrameReady<RGBFrame>(e, rgbImage);
		}
	}

	/// <summary>
	/// Displays the framedata of the sensor to the given image
	/// </summary>
	/// <param name='e'>
	/// E.
	/// </param>
	/// <param name='img'>
	/// Image.
	/// </param>
	/// <typeparam name='T'>
	/// The 1st type parameter.
	/// </typeparam>
	void HandleFrameReady<T>(FrameReadyEventArgs<T> e, Gtk.Image img) where T : Touchdown.SensorAbstraction.Frame {
		using (var imgStream = new System.IO.MemoryStream()){
			e.FrameData.CreateBitmap().Save(imgStream, System.Drawing.Imaging.ImageFormat.Bmp);
			img = new Gtk.Image(imgStream);
		}
	}
}
