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
	
	private int rotator = 0;
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		this.Title = "Touchdown DEMO App - Technikerarbeit Philipp Grathwohl - 2012/2013";
		
		// default settings
		this._settings = new TouchSettings();
		InitializeKinect();
		
		// observed area
		Rectangle area = new Rectangle(0,0,640,480);
		_observer = new SimpleTouchAreaObserver(_sensor, _settings, area);
		_observer.TouchFrameReady += HandleTouchFrameReady;
	}

	void HandleTouchFrameReady (object sender, FrameReadyEventArgs<SimpleTouchFrame> e){
		rotator = (rotator + 3) % 4;
		Console.Write("Touchpoints: ");
		Console.Write(rotator);
		Console.Write (" ");
		Console.WriteLine(e.FrameData.TouchPoints.Count);
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
			// this._sensor.DepthFrameReady += (s, e) => HandleFrameReady<DepthFrame>(e, depthImage);
			// this._sensor.RGBFrameReady += (s, e) => HandleFrameReady<RGBFrame>(e, rgbImage);
		}
		
		this._sensor.Start();
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
		 	img.Pixbuf = new Gdk.Pixbuf (imgStream);  
		}
	}

}
