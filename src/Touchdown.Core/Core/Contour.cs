using System;
using System.Collections.Generic;
using System.Drawing;
using Touchdown.SensorAbstraction;

namespace Touchdown.Core {
	/// <summary>
	/// Contour. List of points that represent a contour around a <see cref="TouchPoint"/>
	/// </summary>
	public class Contour : List<Point>{
		
		private enum ContourDirection {
			North = 0,
			East  = 1, 
			South = 2,
			West  = 3
		}
	
		public Contour() : base() {
		}
		
		#region public methods
		/// <summary>
		/// Finds the contours of possible touchpoints.
		/// </summary>
		/// <returns>
		/// The contours.
		/// </returns>
		/// <param name='rawPoints'>
		/// Raw points.
		/// </param>
		public static List<Contour> FindContours(short[][] depthMatrix, TouchSettings settings){
			List<Contour> result = new List<Contour>();
			
			
			int width = this._settings.DepthFrameResolution.Width;
			int height = this._settings.DepthFrameResolution.Height;
			
			// holds the information if the contour points were already used 
			// by the turtle algorithm (later on
			bool[][] alreadyUsed; 
			alreadyUsed = new bool[width][height];
			
			for(int x = 1; x < width -1; ++x){
				for(int y = 1; y < height -1; ++y){
					// include all points that have a value
					if(depthMatrix[x][y] > 0){
						int neighborCount = 0;
						
						// left
						if (depthMatrix[x-1][y] > this._settings.ContourThreshold) ++neighborCount;
						
						// right 
						if (depthMatrix[x+1][y] > this._settings.ContourThreshold) ++neighborCount;
						
						// above
						if (depthMatrix[x][y-1] > this._settings.ContourThreshold) ++neighborCount;
						
						// under
						if (depthMatrix[x][y+1] > this._settings.ContourThreshold) ++neighborCount;
					}
				}
			}
			
			return result;
		}
		#endregion
		
		#region private method
		/// <summary>
		/// Finds the contour from the given startpoint.
		/// </summary>
		/// <returns>
		/// The contour.
		/// </returns>
		/// <param name='startPoint'>
		/// Start point.
		/// </param>
		/// <param name='depthMatrix'>
		/// Depth matrix.
		/// </param>
		/// <param name='alreadyUsed'>
		/// Already used.
		/// </param>
		/// <param name='settings'>
		/// Settings.
		/// </param>
		private static Contour FindContour(	Point startPoint, 
											short[][] depthMatrix, 
											bool[][] alreadyUsed, 
											TouchSettings settings){
			Contour result = null;
			
			int height = settings.DepthFrameResolution.Height;
			int width  = settings.DepthFrameResolution.Width;
			
			// differ between points that are sourrounded by other valid pixels = innerPoints
			// and points that are not entirely sorrounded by other valid pixels = contourPoints
			bool[][] innerPoints = new bool[width][height];
			
			// beginning at the start point first search in east direction for other points (clockwise)
			ContourDirection = ContourDirection.East;
			
			// s
			
			int count = 0;
			
			return result;
		}
		#endregion
	}
}

