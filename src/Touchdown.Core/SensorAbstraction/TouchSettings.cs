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
			this.FrameCountForAverageBackgroundModel 	= 100;
			this.MaxDistanceFromBackground 	= 20;
			this.MinDistanceFromBackround 	= 7;
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
		
		/// <summary>
		/// Gets or sets the max distance from background that is still recognized as "touch".
		/// </summary>
		/// <value>
		/// The max distance from background.
		/// </value>
		public uint MaxDistanceFromBackground {get; set;}
		
		/// <summary>
		/// Gets or sets the minimum distance that must a touchpoint have to be recognized.
		/// Used to ignore noise and should be a little less than a finger height. 
		/// </summary>
		/// <value>
		/// The minimum distance from backround threshold.
		/// </value>
		public uint MinDistanceFromBackround {get; set;}
	}
}
