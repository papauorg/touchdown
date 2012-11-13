using System;
using System.Collections.Generic;
using System.Text;

namespace Touchdown.SensorAbstraction {
	/// <summary>
	/// Contains general settings that are used throughout the application.
	/// </summary>
	public class TouchSettings {
		
		#region Constructors / Destructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Touchdown.SensorAbstraction.TouchSettings"/> class with default
		/// values.
		/// </summary>
		public TouchSettings(){
			this.FrameCountForAverageBackgroundModel = 100;
		}
		
		#endregion
		
		/// <summary>
		/// Gets or sets the frame count for calculating the average distances for the background model.
		/// This value is used by the <see cref="Touchdown.Core.SimpleTouchAreaObserver" />. Defines the number of depth
		/// frames that are used to calculate the average distance to the background (i.e. the table)
		/// </summary>
		/// <value>
		/// The frame count for average background model.
		/// </value>
		public uint FrameCountForAverageBackgroundModel {get; set;}
		
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
