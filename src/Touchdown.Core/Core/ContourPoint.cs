using System;
using System.Drawing;

namespace Touchdown.Core {
	/// <summary>
	/// defines one point in a contour.
	/// </summary>
	public class ContourPoint{
		private Point _internalPoint;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Touchdown.Core.ContourPoint"/> class.
		/// </summary>
		/// <param name='x'>
		/// X position.
		/// </param>
		/// <param name='y'>
		/// Y position.
		/// </param>
		public ContourPoint(int x, int y){
			this._internalPoint = new Point(x, y);
		}
		
		/// <summary>
		/// copies the given instance of the <see cref="Touchdown.Core.ContourPoint"/> class.
		/// </summary>
		/// <param name='point'>
		/// Point.
		/// </param>
		public ContourPoint(ContourPoint point) : this(point.X, point.Y){
		}

		#region public methods
		/// <param name='orig'>
		/// If set to <c>true</c> original.
		/// </param>
		/// <param name='compare'>
		/// If set to <c>true</c> compare.
		/// </param>
		public static bool operator ==(ContourPoint orig, ContourPoint compare){
			return (orig.X == compare.X && orig.Y == compare.Y);
		}	
		
		/// <param name='orig'>
		/// If set to <c>true</c> original.
		/// </param>
		/// <param name='compare'>
		/// If set to <c>true</c> compare.
		/// </param>
		public static bool operator !=(ContourPoint orig, ContourPoint compare){
			return (orig.X != compare.X || orig.Y != compare.Y);
		}
		
		/// <summary>
		/// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="Touchdown.Core.ContourPoint"/>.
		/// </summary>
		/// <param name='obj'>
		/// The <see cref="System.Object"/> to compare with the current <see cref="Touchdown.Core.ContourPoint"/>.
		/// </param>
		/// <returns>
		/// <c>true</c> if the specified <see cref="System.Object"/> is equal to the current
		/// <see cref="Touchdown.Core.ContourPoint"/>; otherwise, <c>false</c>.
		/// </returns>
		public override bool Equals(object obj) {
			if (obj.GetType() == typeof(ContourPoint)){
				return (this == (ContourPoint)obj);
			}
			
			return base.Equals (obj);
		}
		
		/// <summary>
		/// Serves as a hash function for a <see cref="Touchdown.Core.ContourPoint"/> object.
		/// </summary>
		/// <returns>
		/// A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a hash table.
		/// </returns>
		public override int GetHashCode() {
			return base.GetHashCode ();
		}
		
		/// <summary>
		/// Move the point to specified direction.
		/// </summary>
		/// <param name='direction'>
		/// Direction.
		/// </param>
		public void Move(Contour.ContourDirection direction){
			switch(direction){
				case Contour.ContourDirection.North:
					this.Y--;
					break;
				
				case Contour.ContourDirection.East:
					this.X++;
					break;
					
				case Contour.ContourDirection.South:
					this.Y++;
					break;
					
				case Contour.ContourDirection.West:
					this.X--;
					break;
			}
		}
		#endregion
		
		/// <summary>
		/// Gets or sets the x.
		/// </summary>
		/// <value>
		/// The x.
		/// </value>
		public int X{get{return _internalPoint.X;} set {_internalPoint.X = value;}}
		
		/// <summary>
		/// Gets or sets the y.
		/// </summary>
		/// <value>
		/// The y.
		/// </value>
		public int Y{get{return _internalPoint.Y;} set {_internalPoint.Y = value;}}
		
	}
}

