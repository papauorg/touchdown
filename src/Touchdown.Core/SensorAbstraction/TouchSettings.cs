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
			this.MaxDistanceFromBackground 	= 20;
			this.MinDistanceFromBackround 	= 7;
			this.MaxContourLength = 300;
			this.MinContourLength = 50;
		}
		
		#endregion
		
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
		
		/// <summary>
		/// Gets or sets the max contour lenth.
		/// </summary>
		/// <value>
		/// The max contour lenth.
		/// </value>
		public int MaxContourLength{get; set;}
		
		/// <summary>
		/// Gets or sets the minimum length of the contour.
		/// </summary>
		/// <value>
		/// The minimum length of the contour.
		/// </value>
		public int MinContourLength{get; set;}
		
	}
}
