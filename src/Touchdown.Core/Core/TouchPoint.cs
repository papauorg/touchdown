using System;
using System.Runtime.Serialization;

namespace Touchdown.SensorAbstraction {
	/// <summary>
	/// Defines a recognized touch point as coordinates of the TouchArea.
	/// </summary>
	[DataContract]
	public class TouchPoint {

		/// <summary>
		/// Initializes a new instance of the <see cref="Touchdown.SensorAbstraction.TouchPoint"/> class.
		/// </summary>
		/// <param name='xPosition'>
		/// X position.
		/// </param>
		/// <param name='yPosition'>
		/// Y position.
		/// </param>
		public TouchPoint(int xPosition, int yPosition) {
			this.X = xPosition;
			this.Y = yPosition;
		}

		#region Properties
		/// <summary>
		/// Gets the x position.
		/// </summary>
		/// <value>
		/// The x position.
		/// </value>
		[DataMember]
		public int X {get; private set;}
		
		/// <summary>
		/// Gets the y position.
		/// </summary>
		/// <value>
		/// The y.
		/// </value>
		[DataMember]
		public int Y {get; private set;}

		/// <summary>
		/// Gets or sets the ID of the touchpoint.
		/// </summary>
		[DataMember]
		public Guid ID {get; set;}
		#endregion
	}
}

