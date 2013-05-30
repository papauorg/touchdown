using System;
using System.Collections.Generic;
using System.Drawing;
using Touchdown.SensorAbstraction;
using System.Linq;


namespace Touchdown.Core {
	/// <summary>
	/// Contour. List of points that represent a contour around a <see cref="TouchPoint"/>
	/// </summary>
	public class Contour : List<ContourPoint>{
		
		/// <summary>Internally used to search for the contour</summary>
		public enum ContourDirection {
			/// <summary>
			/// Search for next point in y+1
			/// </summary>
			South = 0,
			
			/// <summary>
			/// Search for next point in x+1
			/// </summary>
			East  = 1, 
			
			/// <summary>
			/// Search for next point in y-1
			/// </summary>
			North = 2,
			
			/// <summary>
			/// Search for next point in x-1
			/// </summary>
			West  = 3
		}
	
		public Contour() : base() {
		}
		
		#region public methods
		/// <summary>
		/// Returns the touch point that is located in the middle of the countour.
		/// </summary>
		/// <returns>
		/// The middle.
		/// </returns>
		public TouchPoint GetMiddle(){
			TouchPoint result;
			
			// topmost point
			int minY = this.Min(x=> x.Y);
			
			// lowest point
			int maxY = this.Max(x=> x.Y);
			
			// leftmost point
			int minX = this.Min(x=> x.X);
			
			// rightmost point
			int maxX = this.Max(x=> x.X);
			
			// calculate middle
			int deltaY = maxY - minY;
			int deltaX = maxX - minX;
			
			
			result = new TouchPoint(minX + deltaX / 2, minY + deltaY / 2 );
			
			return result;
		}
		
		/// <summary>
		/// Finds the contours of possible touchpoints.
		/// </summary>
		/// <returns>
		/// The contours.
		/// </returns>
		/// <param name="isTouched">
		/// matrix with the information if a pixel is considered as touched.
		/// </param>
		/// <param name="settings">settings</param>
		public static List<Contour> FindContours(ref bool[,] isTouched, TouchSettings settings){
			List<Contour> result = new List<Contour>();
			
			
			int width = isTouched.GetLength(0);
			int height = isTouched.GetLength(1);
			
			// holds the information if the contour points were already used 
			// by the turtle algorithm (later on)
			bool[,] contourArray; 
			contourArray = new bool[width,height];
			
			// holds the ordered list of contourpoints also for turtle algorithm
			List<ContourPoint> sortedContourList = new List<ContourPoint>();
			
			// remember all inside points
			List<Point> insidePoints = new List<Point>();
			
			// loop through the depthmap but leave out the borders so the check can be made more easy.
			for(int x = 1; x < width -1; ++x){
				for(int y = 1; y < height -1; ++y){
					// include all points that have a value
					if(isTouched[x,y]){
						int neighborCount = 0;
						
						// left
						if (isTouched[x-1,y]) ++neighborCount;
						
						// right 
						if (isTouched[x+1,y]) ++neighborCount;
						
						// above
						if (isTouched[x,y-1]) ++neighborCount;
						
						// under
						if (isTouched[x,y+1]) ++neighborCount;
						
						// all four pixels neighbours: point that is sorrounded
						if (neighborCount == 4){
							insidePoints.Add(new Point(x,y));
						} else {
							contourArray[x,y] = true;
							sortedContourList.Add(new ContourPoint(x, y));
						}
					}
				}
			}
			
			// loop through the contourpoints and try to find contours
			foreach(ContourPoint possibleContourPoint in sortedContourList){
				// check if the current point is already used by another contour:
				if(contourArray[possibleContourPoint.X, possibleContourPoint.Y]){
					Contour current = Contour.FindContour(possibleContourPoint, ref contourArray, ref isTouched, settings);
					if (current != null){
						result.Add(current);
					}
				}
			}
			return result;
		}
		#endregion
		
		#region private method
		/// <summary>
		/// Tries to find the contour using the turtle algorithm
		/// </summary>
		/// <returns>
		/// The contour.
		/// </returns>
		/// <param name='startPoint'>
		/// Start point.
		/// </param>
		/// <param name='contourArr'>
		/// Contour arr.
		/// </param>
		/// <param name='isTouched'>
		/// Is touched.
		/// </param>
		/// <param name='settings'>
		/// Settings.
		/// </param>
		private static Contour FindContour(	ContourPoint startPoint, 
											ref bool[,] contourArr,  
											ref bool[,] isTouched,
											TouchSettings settings){
			
			ContourPoint current 	= new ContourPoint(startPoint.X, startPoint.Y);
			ContourPoint next 		= new ContourPoint(int.MinValue, int.MinValue); // first run 
			ContourPoint last 		= new ContourPoint(int.MinValue, int.MinValue); // first run 
			
			// result
			Contour result = new Contour();
			
			
			// find contour point that isn't the last one
			do{
				// find next from current
				for (int i = 0; i < 8; ++i){
					next = new ContourPoint(current);
					
					switch (i){
						case 0: 
							next.Move(ContourDirection.North);
							next.Move(ContourDirection.West);
							break;
						case 1:
							next.Move(ContourDirection.North);
							break;
						case 2:
							next.Move(ContourDirection.North);
							next.Move(ContourDirection.East);
							break;
						case 3:
							next.Move(ContourDirection.East);
							break;
						case 4:
							next.Move(ContourDirection.East);
							next.Move(ContourDirection.South);
							break;
						case 5:
							next.Move(ContourDirection.South);
							break;
						case 6:
							next.Move(ContourDirection.South);
							next.Move(ContourDirection.West);
							break;
						case 7:
							next.Move(ContourDirection.West);
							break;
					}
					
					if (contourArr[next.X, next.Y] && next != last){
						contourArr[next.X, next.Y] = false;
						last = new ContourPoint(current);
						current = next;
						result.Add(current);
						break;
					} else if (i == 7) {
						// when all positions around current have been searched (i=7) and
						// next wasnt a valid position. then it's not a valid contour --> return null;
						return null;
					}
				}
			} while (current != startPoint);
			
			// apply constraints for the length of the contour, to avoid noise interpreted as touch point
			if(result.Count < settings.MinContourLength || result.Count > settings.MaxContourLength) {
				result = null;
			}
			
			return result;
		}
		#endregion
	}
}

