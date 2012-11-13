using System;
using System.Collections.Generic;
using System.Text;

namespace Touchdown.SensorAbstraction {
	/// <summary>
	/// Contains general settings that are used throughout the application.
	/// </summary>
	public class TouchSettings {
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Touchdown.SensorAbstraction.TouchSettings"/> first frame
		/// should be considered as empty area.
		/// </summary>
		/// <value>
		/// <c>true</c> if first frame should be considered as empty area; otherwise, <c>false</c>.
		/// if set to <c>false</c> a depthframe representing the empty area must be set to <see cref="TouchSettings.EmptyRecognitionArea" />
		/// </value>
		public bool FirstFrameIsEmptyArea{get;set;}
		
		/// <summary>
		/// Gets or sets the definition for the empty recognition area. Based on this the recognizer calculates the 
		/// background model.
		/// </summary>
		/// <value>
		/// The empty recognition area.
		/// </value>
		public DepthFrame EmptyRecognitionArea{get;set;}
		 
//		public TouchAreaDefinition TouchArea {
//			get {
//					throw new NotImplementedException ();
//			}
//			set {
//					throw new NotImplementedException ();
//			}
//		}
//
//		public SensorMode SensorMode {
//			get {
//					throw new NotImplementedException ();
//			}
//			set {
//					throw new NotImplementedException ();
//			}
//		}
	}
}
