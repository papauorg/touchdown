using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Touchdown.SensorAbstraction;

namespace Touchdown.Core.PatternRecognition {
	/// <summary>
	/// Event arguments for when a pattern was recognized.
	/// </summary>
	public class TouchPatternRecognizedEventArgs : System.EventArgs {

		#region Constructor
		/// <summary>
		/// Creates a new instance of the touchpattern recognized event.
		/// </summary>
		/// <param name="timestamp">Point in time when the pattern was recognized</param>
		/// <param name="recognizedPattern">Pattern that was recognized</param>
		/// <param name="originalPattern">original pattern</param>
		/// <param name="quality">average distance per point relative to the original pattern</param>
		/// <param name="duration"></param>
		/// <param name="startPoint"></param>
		public TouchPatternRecognizedEventArgs(	DateTime timestamp, 
												TouchPattern recognizedPattern, 
												TouchPattern originalPattern,
												double quality, 
												TimeSpan duration, 
												SensorAbstraction.TouchPoint startPoint){
			this.TimeStamp = timestamp;
			this.RecognizedPattern = recognizedPattern;
			this.OriginalPattern = originalPattern;
			this.RecognitionQuality = quality;
			this.Duration = duration;
			this.StartPoint = startPoint;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the point in time when the pattern was recognized
		/// </summary>
		public DateTime TimeStamp{get; private set;}
	
		/// <summary>
		/// Gets the pattern that was recognized.
		/// </summary>
		public TouchPattern RecognizedPattern{get; private set;}	

		/// <summary>
		/// Gets the original pattern of the one that was recognized.
		/// </summary>
		public TouchPattern OriginalPattern{get; private set;}	
		
		/// <summary>
		/// Gets the recognition quality (distance per point)
		/// </summary>
		public double RecognitionQuality{get; private set;}

		/// <summary>
		/// Gets the total duration of the recognized 
		/// </summary>
		public TimeSpan Duration{get; private set;}

		/// <summary>
		/// Start point of the touchpattern relative to the touchframe in that it was recognized.
		/// </summary>
		public TouchPoint StartPoint{get; private set;}
		#endregion
	}
}
