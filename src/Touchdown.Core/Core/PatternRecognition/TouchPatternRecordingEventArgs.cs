using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Touchdown.Core;
using Touchdown.SensorAbstraction;

namespace Touchdown.Core.PatternRecognition {
	/// <summary>
	/// Event arguments for when a pattern is currently recorded. Fired when a frame was added to
	/// the patterns. 
	/// </summary>
	public class TouchPatternRecordingEventArgs : System.EventArgs{

		#region Constructors
		/// <summary>
		/// Creates a new instance of the touchpattern recording event.
		/// </summary>
		/// <param name="timestamp">Point in time when the pattern was recognized</param>
		/// <param name="recorded">Pattern that is currently recorded</param>
		/// <param name="startPoint">start point of the pattern.</param>
		public TouchPatternRecordingEventArgs(	DateTime timestamp, 
												TouchPattern recordedPattern,
												SimpleTouchFrame recordedFrame) {		
												
			this.TimeStamp= timestamp;
			this.Pattern = recordedPattern;
			this.Frame = recordedFrame;							
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the point in time when the frame was added to the pattern
		/// </summary>
		public DateTime TimeStamp{get; private set;}

		/// <summary>
		/// Gets the current recording pattern.
		/// </summary>
		public TouchPattern Pattern{get; private set;}	

		/// <summary>
		/// Gets the recorded frame.
		/// </summary>
		public SimpleTouchFrame Frame {get; private set;}
		#endregion
	}
}
