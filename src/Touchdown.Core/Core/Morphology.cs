using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Touchdown.Core {
	/// <summary>
	/// provides morphological operators
	/// </summary>
	public class Morphology {
	
		/// <summary>
		/// Performs morphological closing on the given image by appling the given
		/// structuring element.
		/// </summary>
		/// <param name="image">binary image that should be closed</param>
		/// <param name="structElement">structuring element that is applied</param>
		/// <returns>closed image</returns>
		public static bool[,] Close(bool[,] image, bool[,] structElement){
			var result = Dilate(image, structElement);
			result = Erode(result, structElement);
			return result;
		}

		/// <summary>
		/// Performs morphological closing on the given image by appling the given
		/// structuring element.
		/// </summary>
		/// <param name="image">binary image that should be closed</param>
		/// <param name="radius">radius of the disk shaped structured element that is used</param>
		/// <returns>closed image</returns>
		public static bool[,] Close(bool[,] image, int radius){
			var structuringElement = GetDiskStructuringElement(radius);
			return Close(image, structuringElement);
		}

		/// <summary>
		/// Performs morphological opening on the given image by appling the given
		/// structuring element.
		/// </summary>
		/// <param name="image">binary image that should be opened</param>
		/// <param name="structElement">structuring element that is applied</param>
		/// <returns>opened image</returns>
		public static bool[,] Open(bool[,] image, bool[,] structElement){
			var result = Erode(image, structElement);
			result = Dilate(result, structElement);
			return result;
		}

		/// <summary>
		/// Performs morphological opening on the given image by appling the given
		/// structuring element.
		/// </summary>
		/// <param name="image">binary image that should be opened</param>
		/// <param name="radius">radius of the disk shaped structured element that is used</param>
		/// <returns>opened image</returns>
		public static bool[,] Open(bool[,] image, int radius){
			var structuringElement = GetDiskStructuringElement(radius);
			return Open(image, structuringElement);
		}

		/// <summary>
		/// Performs morphological erosion on the given image by appling the given
		/// structuring element.
		/// </summary>
		/// <param name="image">binary image that should be eroded</param>
		/// <param name="structElement">structuring element that is applied</param>
		/// <returns>eroded image</returns>
		public static bool[,] Erode(bool[,] image, bool[,] structElement){
			int imageWidth  = image.GetLength(0);
			int imageHeight = image.GetLength(1);
			int structWidth = structElement.GetLength(0);
			int structHeight = structElement.GetLength(1);
			
			bool[,] result = new bool[image.GetLength(0), image.GetLength(1)];

			// dilate the image
			Parallel.For(0, imageHeight, y=>{
			//for(int y = 0; y < imageHeight; ++y){
				for(int x = 0; x < imageWidth; ++x){
					// only consider foreground pixels
					if (image[x, y]) { 
						// apply structuring element
						bool allNeigboursAreForeground = true;

						for (int structY = 0; structY < structHeight; ++structY) {
							if (allNeigboursAreForeground) {
								for (int structX = 0; structX < structWidth; ++structX) {
									if (allNeigboursAreForeground && structElement[structX, structY]) {
										int neighbourX = x + (structX - structWidth / 2);
										int neighbourY = y + (structY - structHeight / 2);
										if (neighbourX >= 0 && neighbourX < imageWidth) {
											if (neighbourY >= 0 && neighbourY < imageHeight) {
												allNeigboursAreForeground = allNeigboursAreForeground && image[neighbourX, neighbourY];
											}
										}
									} else { 
										break;
									}
								}
							} else { 
								break;
							}

						}

						result[x,y] = allNeigboursAreForeground;
					}
				}
			//}
			});
			return result;
		}

		/// <summary>
		/// Performs morphological erosion on the given image by appling the given
		/// structuring element.
		/// </summary>
		/// <param name="image">binary image that should be eroded</param>
		/// <param name="radius">radius of the disk shaped structured element that is used</param>
		/// <returns>eroded image</returns>
		public static bool[,] Erode(bool[,] image, int radius){
			bool[,] structuringElement = GetDiskStructuringElement(radius);
			return Erode(image, structuringElement);
		}

		/// <summary>
		/// Performs morphological dilation on the given image by appling the given
		/// structuring element.
		/// </summary>
		/// <param name="image">binary image that should be dilated</param>
		/// <param name="structElement">structuring element that is applied</param>
		/// <returns>dilated image</returns>
		public static bool[,] Dilate(bool[,] image, bool[,] structElement){
			bool[,] result = new bool[image.GetLength(0), image.GetLength(1)];

			int imageWidth  = image.GetLength(0);
			int imageHeight = image.GetLength(1);
			int structWidth = structElement.GetLength(0);
			int structHeight = structElement.GetLength(1);

			// dilate the image
			Parallel.For(0, imageHeight, y=>{
			//for(int y = 0; y < imageHeight; ++y){
				for(int x = 0; x < imageWidth; ++x){
					if (image[x, y]) {
						for (int structY = 0; structY < structHeight; ++structY) {
							for (int structX = 0; structX < structWidth; ++structX) {
								if (structElement[structX, structY]) {
									int neighbourX = x + (structX - structWidth / 2);
									int neighbourY = y + (structY - structHeight / 2);
									if (neighbourX >= 0 && neighbourX < imageWidth) {
										if (neighbourY >= 0 && neighbourY < imageHeight) { 
											result[neighbourX,neighbourY] = true;
										}
									}
								}
							}
						}
					}
				}
			//}
			});

			return result;
		}

		///// <summary>
		///// Performs morphological dilation on the given image by appling the given
		///// structuring element.
		///// </summary>
		///// <param name="image">binary image that should be dilated</param>
		///// <param name="structElement">structuring element that is applied</param>
		///// <returns>dilated image</returns>
		//public static bool[,] Dilate(bool[,] image, bool[,] structElement){
		//	bool[,] result = new bool[image.GetLength(0), image.GetLength(1)];

		//	int imageWidth  = image.GetLength(0);
		//	int imageHeight = image.GetLength(1);
		//	int structWidth = structElement.GetLength(0);
		//	int structHeight = structElement.GetLength(1);

		//	// dilate the image
		//	Parallel.For(0, imageHeight, y=>{
		//	//for(int y = 0; y < imageHeight; ++y){
		//		for(int x = 0; x < imageWidth; ++x){
		//			// only consider background pixels (false)
		//			if (!image[x, y]) {
		//				// apply structuring element
		//				bool oneNeighbourIsForeGround = false;

		//				for (int structY = 0; structY < structHeight; ++structY) {
		//					if (!oneNeighbourIsForeGround) {
		//						for (int structX = 0; structX < structWidth; ++structX) {
		//							if (structElement[structX, structY]) {
		//								int neighbourX = x + (structX - structWidth / 2);
		//								int neighbourY = y + (structY - structHeight / 2);
		//								if (neighbourX >= 0 && neighbourX < imageWidth) {
		//									if (neighbourY >= 0 && neighbourY < imageHeight) {
		//										oneNeighbourIsForeGround = oneNeighbourIsForeGround || image[neighbourX, neighbourY];
		//									}
		//								}
		//							}
		//						}
		//					}
		//				}
		//				result[x, y] = oneNeighbourIsForeGround;
		//			} else { 
		//				result[x, y] = true;
		//			}
		//		}
		//	//}
		//	});

		//	return result;
		//}

		/// <summary>
		/// Performs morphological dilation on the given image by appling a disk shaped
		/// structuring element with the given size.
		/// </summary>
		/// <param name="image">binary image that should be dilated</param>
		/// <param name="radius">radius of the disk shaped structured element that is used</param>
		/// <returns>dilated image</returns>
		public static bool[,] Dilate(bool[,] image, int radius){
			bool[,] structuringElement = GetDiskStructuringElement(radius);
			return Dilate(image, structuringElement);
		}

		/// <summary>
		/// creates a disk shaped structuring element with the given radius
		/// </summary>
		/// <param name="radius">radius</param>
		/// <returns>disk shaped structuring element</returns>
		public static bool[,] GetDiskStructuringElement(int radius){
			int size = radius*2+1;
			bool[,] result = new bool[size, size];
			Point origin = new Point(radius, radius);

			for (int y = 0; y < size; ++y) {
				for (int x = 0; x < size; ++x) { 
					int deltaX = Math.Abs(origin.X - x);
					int deltaY = Math.Abs(origin.Y - y);
					double distanceToOrigin = Math.Sqrt((deltaX*deltaX)+(deltaY*deltaY));
					result[x,y] = (distanceToOrigin <= radius);
				}
			}

			return result;
		}
	}
}
