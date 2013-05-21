using System;

namespace Touchdown.SensorAbstraction {
	/// <summary>
	/// Defines a recognized touch point as coordinates of the TouchArea.
	/// </summary>
	public class TouchPoint {
		private int x, y;
		
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
			this.x = xPosition;
			this.y = yPosition;
		}
		
		/// <summary>
		/// Gets the x position.
		/// </summary>
		/// <value>
		/// The x position.
		/// </value>
		public int X {
			get {return this.x; }
		}
		
		/// <summary>
		/// Gets the y position.
		/// </summary>
		/// <value>
		/// The y.
		/// </value>
		public int Y {
			get {return this.y; }
		}
	}
}

